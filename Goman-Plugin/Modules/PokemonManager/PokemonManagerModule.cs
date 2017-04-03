using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using Goman_Plugin.Model;
using Goman_Plugin.Modules.PokemonFeeder;
using Goman_Plugin.Wrapper;
using GoPlugin;
using GoPlugin.Enums;
using GoPlugin.Events;
using POGOProtos.Data;
using MethodResult = Goman_Plugin.Model.MethodResult;

namespace Goman_Plugin.Modules.PokemonManager
{
    public class PokemonManagerModule : AbstractModule
    {
        public PokemonManagerModule()
        {
            Settings = new BaseSettings<PokemonManagerSettings> {Enabled = true};
        }

        public new BaseSettings<PokemonManagerSettings> Settings { get; }


        public async void Execute(Manager wrappedManager)
        {

            var manager = wrappedManager.Bot;
            if (manager.State != BotState.Running) return;
            await manager.UpdateDetails();

            var pokesToFavorite = new List<PokemonData>();
            var pokesToRename = new List<PokemonData>();
            var pokesToUpgrade = new List<PokemonData>();
            var pokesToEvolve = new List<PokemonData>();

            var pokemonToHandle = GetPokemonToHandle(wrappedManager);
            if (pokemonToHandle.Count == 0) return;


            UpdateStarDustAndCandy(wrappedManager, pokemonToHandle);

            foreach (var pokemonData in pokemonToHandle)
                if (PokemonDataMeetsAutoEvolveCriteria(manager, pokemonData))
                {
                    pokesToEvolve.Add(pokemonData);
                }
                else
                {
                    if (PokemonDataMeetsAutoFavoriteCriteria(pokemonData))
                        pokesToFavorite.Add(pokemonData);

                    if (PokemonDataMeetsAutoRenameCriteria(pokemonData))
                        pokesToRename.Add(pokemonData);

                    if (PokemonDataMeetsAutoUpgradeCriteria(wrappedManager, pokemonData))
                        pokesToUpgrade.Add(pokemonData);
                }

            EvolvePokemon(wrappedManager, pokesToEvolve);
            UpgradePokemon(wrappedManager, pokesToUpgrade);
            SetFavorites(wrappedManager, pokesToFavorite);
            RenameWithIv(wrappedManager, pokesToRename);
            
        }

        public List<PokemonData> GetPokemonToHandle(Manager wrappedManager)
        {
            var pokemonToHandle = new List<PokemonData>();
            var manager = wrappedManager.Bot;

            foreach (var pokemonManager in Settings.Extra.Pokemons.Values)
                pokemonToHandle
                    .AddRange(
                        manager.Pokemon
                            .Where(
                                poke =>
                                    poke.PokemonId == pokemonManager.PokemonId &&
                                    PokemonDataMeetsAutoCriteria(manager, poke, pokemonManager))
                            .OrderByDescending(poke => manager.CalculateIVPerfection(poke).Data)
                            .ThenBy(poke => poke.Cp)
                            .Take(pokemonManager.Quantity));

            return pokemonToHandle;
        }

        public bool PokemonDataMeetsAutoCriteria(IManager manager, PokemonData poke, PokemonManager pokemonManager)
        {
            var settingConfiguredForPokemon = 
                   pokemonManager.AutoEvolve
                || pokemonManager.AutoFavorite
                || pokemonManager.AutoUpgrade
                || pokemonManager.AutoRenameWithIv
                || pokemonManager.AutoFavoriteShiny;

            if (!settingConfiguredForPokemon)
                return false;

            var meetsMinimumIvAndCp = manager.CalculateIVPerfection(poke).Data >= pokemonManager.MinimumIv
                                      && poke.Cp >= pokemonManager.MinimumCp;

            var isConfiguredForShinyAndIsShiny = (pokemonManager.AutoFavoriteShiny && poke.PokemonDisplay.Shiny);

            return meetsMinimumIvAndCp || isConfiguredForShinyAndIsShiny;
        }

        public void UpdateStarDustAndCandy(Manager wrappedManager, List<PokemonData> pokemonToHandle)
        {
            if (wrappedManager.AutoEvolving ||
                    wrappedManager.AutoFavoriting ||
                    wrappedManager.AutoNaming ||
                    wrappedManager.AutoUpgrading) return;

            var manager = wrappedManager.Bot;

            foreach (var pokemonData in pokemonToHandle)
            {
                var pokeSetting = Settings.Extra.Pokemons[pokemonData.PokemonId];
                var pokemonSettings = manager.GetPokemonSetting(pokemonData.PokemonId).Data;

                int totalCandy;
                if (int.TryParse((manager.PokemonCandy.FirstOrDefault(x => x.FamilyId == pokemonSettings.FamilyId)?.Candy_) .ToString(),out totalCandy))
                    pokeSetting.TotalCandy = totalCandy;

                var candyToEvolve = pokemonSettings.CandyToEvolve;

                pokeSetting.CandyToEvolve = candyToEvolve;

            }

            int totalStardust;
            if (int.TryParse((manager.PlayerData.Currencies.FirstOrDefault(x => x.Name == "STARDUST")?.Amount).ToString(),out totalStardust))
                wrappedManager.TotalStardust = totalStardust;


        }

        public bool PokemonDataMeetsAutoEvolveCriteria(IManager manager, PokemonData pokemonData)
        {
            var pokeSetting = Settings.Extra.Pokemons[pokemonData.PokemonId];
            if (!pokeSetting.AutoEvolve || pokeSetting.CandyToEvolve <= 0 ||
                pokeSetting.TotalCandy < pokeSetting.CandyToEvolve) return false;

            pokeSetting.TotalCandy -= pokeSetting.CandyToEvolve;
            return true;
        }

        public bool PokemonDataMeetsAutoFavoriteCriteria(PokemonData pokemonData)
        {
            var pokeSetting = Settings.Extra.Pokemons[pokemonData.PokemonId];
            return (pokeSetting.AutoFavorite || pokemonData.PokemonDisplay.Shiny == pokeSetting.AutoFavoriteShiny) &&
                   pokemonData.Favorite == 0;
        }

        public bool PokemonDataMeetsAutoRenameCriteria(PokemonData pokemonData)
        {
            var pokeSetting = Settings.Extra.Pokemons[pokemonData.PokemonId];
            return pokeSetting.AutoRenameWithIv && string.IsNullOrEmpty(pokemonData.Nickname);
        }

        public bool PokemonDataMeetsAutoUpgradeCriteria(Manager wrappedManager, PokemonData pokemonData)
        {
            var manager = wrappedManager.Bot;
            var pokeSetting = Settings.Extra.Pokemons[pokemonData.PokemonId];
            if (!pokeSetting.AutoUpgrade || wrappedManager.TotalStardust == 0) return false;
            var pokeLevel = GetPokemonLevel(manager, pokemonData);
            if (pokeLevel.Equals(double.Parse(wrappedManager.Level) + 2)) return false;
            var powerUpReq = PowerUpTable.Table[pokeLevel];
            if (wrappedManager.TotalStardust < powerUpReq.Stardust || pokeSetting.TotalCandy < powerUpReq.Candy)
                return false;


            pokeSetting.TotalCandy -= powerUpReq.Candy;
            wrappedManager.TotalStardust -= powerUpReq.Stardust;

            return true;
        }

        public async void EvolvePokemon(Manager manager, List<PokemonData> pokesToEvolve)
        {
            if (pokesToEvolve.Count == 0 || manager.AutoEvolving) return;
            manager.AutoEvolving = true;
            await manager.Bot.EvolvePokemon(pokesToEvolve).ContinueWith(r =>
            {
                var results = r.Result;

                OnLogEvent(this,
                    GetLog(new MethodResult
                    {
                        Success = results.Success,
                        Message = results.Message,
                        MethodName = "EvolvePokemon"
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
                    GetLog(new MethodResult
                    {
                        Success = results.Success,
                        Message = results.Message,
                        MethodName = "UpgradePokemon"
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
                    GetLog(new MethodResult
                    {
                        Success = results.Success,
                        Message = results.Message,
                        MethodName = "FavoritePokemon"
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
                    GetLog(new MethodResult
                    {
                        Success = !(r.IsCanceled || r.IsFaulted),
                        Message = "Renamed Pokemon",
                        MethodName = "RenameWithIv"
                    }));
                manager.AutoNaming = false;
            });
        }

        public double GetPokemonLevel(IManager manager, PokemonData pokemon)
        {
            double cp = pokemon.AdditionalCpMultiplier + pokemon.CpMultiplier;

            for (var i = 0; i < manager.LevelSettings.CpMultiplier.Count; i++)
            {
                if (cp.Equals(manager.LevelSettings.CpMultiplier[i]))
                    return i + 1;

                if (i <= 0 || !(cp < manager.LevelSettings.CpMultiplier[i])) continue;

                if (cp > manager.LevelSettings.CpMultiplier[i - 1])
                    return i + 0.5;
            }

            return 0.0;
        }
        public override async Task<MethodResult> Enable(bool forceSubscribe = false)
        {
            await LoadSettings();

            if (Settings.Enabled)
            {
                if (forceSubscribe)
                {
                    foreach (var account in Plugin.Accounts)
                    {
                        PluginOnManagerAdded(this, account);
                    }
                }

                Plugin.ManagerAdded += PluginOnManagerAdded;
                Plugin.ManagerRemoved += PluginOnManagerRemoved;

                OnModuleEvent(this, Modules.ModuleEvent.Enabled);
            }

            return new MethodResult { Success = Settings.Enabled };
        }

        public override async Task<MethodResult> Disable(bool forceUnsubscribe = false)
        {
            Plugin.ManagerAdded -= PluginOnManagerAdded;
            Plugin.ManagerRemoved -= PluginOnManagerRemoved;

            await SaveSettings();
            if (forceUnsubscribe)
            {
                foreach (var account in Plugin.Accounts)
                {
                    PluginOnManagerRemoved(this, account);
                }
            }

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

        private void PluginOnManagerAdded(object o, Manager manager)
        {
            // OnLogEvent(this, new LogModel(LoggerTypes.Info, $"Subscribing to account {manager.Bot.AccountName}"));
            manager.OnPokestopFarmedEvent += OnPokestopFarmedEvent;
            manager.OnPokemonCaughtEvent += OnPokemonCaughtEvent;
            manager.OnLocationUpdateEvent += OnLocationUpdateEvent;
        }

        private void PluginOnManagerRemoved(object o, Manager manager)
        {
            // OnLogEvent(this, new LogModel(LoggerTypes.Info, $"Unsubscribing to account {manager.Bot.AccountName}"));
            manager.OnPokestopFarmedEvent -= OnPokestopFarmedEvent;
            manager.OnPokemonCaughtEvent -= OnPokemonCaughtEvent;
            manager.OnLocationUpdateEvent -= OnLocationUpdateEvent;
        }

        private void OnLocationUpdateEvent(object arg1, LocationUpdateEventArgs locationUpdateEventArgs)
        {
            var wrappedManager = (Manager)arg1;
            OnLogEvent(this, new LogModel(LoggerTypes.Success, $"OnLocationUpdateEvent poke manager on account {wrappedManager.Bot.AccountName}"), null);
            Execute(wrappedManager);
        }

        private async void OnPokemonCaughtEvent(object arg1, PokemonCaughtEventArgs arg2)
        {
           var wrappedManager = (Manager)arg1;
           var manager = wrappedManager.Bot;
           var pokemonData = arg2.Pokemon;
           OnLogEvent(this, new LogModel(LoggerTypes.Success, $"OnPokemonCaught Pokemon Manager on account {wrappedManager.Bot.AccountName}"), null);
           await manager.UpdateDetails();

           var pokemonToHandle = new List<PokemonData>() {pokemonData};
           UpdateStarDustAndCandy(wrappedManager, pokemonToHandle);
           
           
           if (PokemonDataMeetsAutoEvolveCriteria(manager, pokemonData))
           {
               await manager.EvolvePokemon(new[] {pokemonData});
           }
           else
           {
               if (PokemonDataMeetsAutoFavoriteCriteria(pokemonData))
               {
                   await manager.FavoritePokemon(new[] { pokemonData });
               }
           
           
               if (PokemonDataMeetsAutoRenameCriteria(pokemonData))
               {
                   await manager.RenameAllPokemonToIV(new[] {pokemonData});
               }
           
               if (PokemonDataMeetsAutoUpgradeCriteria(wrappedManager, pokemonData))
               {
                   await manager.UpgradePokemon(new[] {pokemonData}, 100);
               }
           }
        }

        private void OnPokestopFarmedEvent(object arg1, EventArgs arg2)
        {
            var wrappedManager = (Manager)arg1;
            OnLogEvent(this, new LogModel(LoggerTypes.Success, $"OnPokestopFarmedEvent poke manager  on account {wrappedManager.Bot.AccountName}"), null);
            Execute(wrappedManager);
        }
    }
}