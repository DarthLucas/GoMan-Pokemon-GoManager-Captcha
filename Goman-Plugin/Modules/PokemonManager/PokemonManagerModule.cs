using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Goman_Plugin.Wrapper;
using GoPlugin;
using GoPlugin.Enums;
using POGOProtos.Data;
using MethodResult = Goman_Plugin.Model.MethodResult;
using Timer = System.Timers.Timer;

namespace Goman_Plugin.Modules.PokemonManager
{
    public class PokemonManagerModule : AbstractModule
    {
        public new BaseSettings<PokemonManagerSettings> Settings { get; }
        private static Timer _taskTimer;
        private Plugin _plugin;

        public PokemonManagerModule(Plugin plugin)
        {
            _plugin = plugin;
            Settings = new BaseSettings<PokemonManagerSettings>() {Enabled = true};
            _taskTimer = new Timer();
        }

        private void _taskTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Execute();
        }

        public void Execute()
        {
            foreach (var manager in Plugin.Accounts)
            {
                if (manager.Bot.State != BotState.Running) continue;


                var pokesToFavorite = new List<PokemonData>();
                var pokesToRename = new List<PokemonData>();
                var pokesToUpgrade = new List<PokemonData>();
                var pokesToEvolve = new List<PokemonData>();
                var pokemonToHandle = GetPokemonToHandle(manager.Bot);

                if(pokemonToHandle.Count == 0) continue;
                    manager.Bot.UpdateDetails();

                    var totalStardust = manager.Bot.PlayerData.Currencies.FirstOrDefault(x => x.Name == "STARDUST")?.Amount;

                    foreach (var pokemonData in pokemonToHandle)
                    {
                        var pokeSetting = Settings.Extra.Pokemons[pokemonData.PokemonId];
                        var pokemonSettings = manager.Bot.GetPokemonSetting(pokemonData.PokemonId).Data;

                        var totalCandy =
                            manager.Bot.PokemonCandy
                                .FirstOrDefault(x => x.FamilyId == pokemonSettings.FamilyId)?.Candy_;
                        var candyToEvolve = pokemonSettings.CandyToEvolve;

                        if (pokeSetting.AutoEvolve && candyToEvolve > 0 && totalCandy >= candyToEvolve)
                        {
                            pokesToEvolve.Add(pokemonData);
                        }
                        else
                        {
                            if (pokeSetting.AutoFavorite && pokemonData.Favorite == 0) pokesToFavorite.Add(pokemonData);
                            if (pokeSetting.AutoRenameWithIv)
                            {
                                if (string.IsNullOrEmpty(pokemonData.Nickname))
                                {
                                    pokesToRename.Add(pokemonData);
                                }
                            }
                            if (!pokeSetting.AutoUpgrade || totalStardust == null) continue;

                            var pokeLevel = GetPokemonLevel(manager.Bot, pokemonData);

                            if(pokeLevel.Equals(double.Parse(manager.Level)+2)) continue;

                            var powerUpReq = PowerUpTable.Table[pokeLevel];

                            if (totalStardust < powerUpReq.Stardust || totalCandy < powerUpReq.Candy) continue;

                            pokesToUpgrade.Add(pokemonData);
                            totalStardust -= powerUpReq.Stardust;
                        }
                    }

                EvolvePokemon(manager, pokesToEvolve);
                UpgradePokemon(manager, pokesToUpgrade);
                SetFavorites(manager, pokesToFavorite);
                RenameWithIv(manager, pokesToRename);
            }

            
        }

        public List<PokemonData> GetPokemonToHandle(IManager manager)
        {
            var pokemonToHandle = new List<PokemonData>();

            foreach (var pokemonManager in Settings.Extra.Pokemons.Values)
            {                
                pokemonToHandle
                    .AddRange(
                    manager.Pokemon
                        .Where(poke => poke.PokemonId == pokemonManager.PokemonId &&
                                (pokemonManager.AutoEvolve || pokemonManager.AutoFavorite || pokemonManager.AutoUpgrade || pokemonManager.AutoRenameWithIv) &&
                                manager.CalculateIVPerfection(poke).Data >= pokemonManager.MinimumIv &&
                                poke.Cp >= pokemonManager.MinimumCp)
                        .OrderByDescending(poke => manager.CalculateIVPerfection(poke).Data)
                        .ThenBy(poke => poke.Cp)
                        .Take(pokemonManager.Quantity));
            }

            return pokemonToHandle;
        }

        public async void EvolvePokemon(Manager manager, List<PokemonData> pokesToEvolve)
        {
            if (pokesToEvolve.Count == 0 || manager.AutoEvolving) return;
            manager.AutoEvolving = true;
            await manager.Bot.EvolvePokemon(pokesToEvolve).ContinueWith(r =>
            {
                var results = r.Result;

                OnLogEvent(this,
                    GetLog(new MethodResult()
                    {
                        Success = results.Success,
                        Message = results.Message,
                        MethodName = "EvolvePokemon",
                    }));
                manager.AutoEvolving = false;
            });


        }

        public void UpgradePokemon(Manager manager, List<PokemonData> pokesToUpgrade)
        {
            if (pokesToUpgrade.Count == 0 || manager.AutoUpgrading) return;
            manager.AutoUpgrading = true;
            manager.Bot.UpgradePokemon(pokesToUpgrade, 100).ContinueWith(r =>
            {
                var results = r.Result;

                            OnLogEvent(this,
                GetLog(new MethodResult()
                {
                    Success = results.Success,
                    Message = results.Message,
                    MethodName = "UpgradePokemon",
                }));
                manager.AutoUpgrading = false;
            });
        }

        public void SetFavorites(Manager manager, List<PokemonData> pokesToFavorite)
        {
            if (pokesToFavorite.Count == 0 || manager.AutoFavoriting) return;
            manager.AutoFavoriting = true;
            manager.Bot.FavoritePokemon(pokesToFavorite).ContinueWith(r =>
            {
                var results = r.Result;

                OnLogEvent(this,
                    GetLog(new MethodResult()
                    {
                        Success = results.Success,
                        Message = results.Message,
                        MethodName = "FavoritePokemon",
                    }));
                manager.AutoFavoriting = false;
            });
        }
        public void RenameWithIv(Manager manager, List<PokemonData> pokesToRename)
        {
            if (pokesToRename.Count == 0 || manager.AutoNaming) return;
            manager.AutoNaming = true;
            manager.Bot.RenameAllPokemonToIV(pokesToRename).ContinueWith(r =>
            {
                OnLogEvent(this,
                    GetLog(new MethodResult()
                    {
                        Success = !(r.IsCanceled || r.IsFaulted),
                        Message = "Renamed Pokemon",
                        MethodName = "RenameWithIv",
                    }));
                manager.AutoNaming = false;
            });
        }
        public override async Task<MethodResult> Enable(bool forceSubscribe = false)
        {
            await LoadSettings();

            if (Settings.Enabled)
            {
                _taskTimer.Interval = Settings.Extra.IntervalMilliseconds;

                _taskTimer.Elapsed += _taskTimer_Elapsed;
                _taskTimer.Enabled = true;
                OnModuleEvent(this, Modules.ModuleEvent.Enabled);
                Execute();
            }

            return new MethodResult {Success = Settings.Enabled};
        }
        public double GetPokemonLevel(IManager manager, PokemonData pokemon)
        {

            double cp = pokemon.AdditionalCpMultiplier + pokemon.CpMultiplier;

            for (var i = 0; i < manager.LevelSettings.CpMultiplier.Count; i++)
            {
                if (cp.Equals(manager.LevelSettings.CpMultiplier[i]))
                {
                    return i + 1;
                }

                if (i <= 0 || !(cp < manager.LevelSettings.CpMultiplier[i])) continue;

                if (cp > manager.LevelSettings.CpMultiplier[i - 1])
                {
                    return i + 0.5;
                }
            }

            return 0.0;
        }
        public override async Task<MethodResult> Disable(bool forceUnsubscribe = false)
        {
            if (!_taskTimer.Enabled) return new MethodResult {Success = true};
            _taskTimer.Elapsed -= _taskTimer_Elapsed;
            _taskTimer.Enabled = false;
            await SaveSettings();
            OnModuleEvent(this, Modules.ModuleEvent.Disabled);
            return new MethodResult {Success = true};
        }

        public async Task<MethodResult> LoadSettings()
        {
            var loadSettingsResult = await Settings.Load(ModuleName);

            if (!loadSettingsResult.Success)
            {
                Settings.Extra = new PokemonManagerSettings(true);
                await SaveSettings();
            }

            loadSettingsResult.MethodName = "LoadSettings";
            OnLogEvent(this, GetLog(loadSettingsResult));
            return loadSettingsResult;
        }

        public async Task<MethodResult> SaveSettings()
        {
            var saveSettingsResult = await Settings.Save(ModuleName);
            saveSettingsResult.MethodName = "SaveSettings";
            OnLogEvent(this, GetLog(saveSettingsResult));
            return saveSettingsResult;
        }
    }
}