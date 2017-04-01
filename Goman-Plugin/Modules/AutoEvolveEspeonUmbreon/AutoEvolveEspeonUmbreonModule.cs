using System;
using System.Linq;
using System.Threading.Tasks;
using Goman_Plugin.Wrapper;
using GoPlugin;
using GoPlugin.Enums;
using MethodResult = Goman_Plugin.Model.MethodResult;
using Goman_Plugin.Model;
using GoPlugin.Events;
using POGOProtos.Enums;

namespace Goman_Plugin.Modules.AutoEvolveEspeonUmbreon
{
    public class AutoEvolveEspeonUmbreonModule : AbstractModule
    {
        public new BaseSettings<AutoEvolveEspeonUmbreonSettings> Settings { get; }

        public AutoEvolveEspeonUmbreonModule()
        {
            Settings = new BaseSettings<AutoEvolveEspeonUmbreonSettings>() { Enabled = true };
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
            await SaveSettings();
            Plugin.ManagerAdded -= PluginOnManagerAdded;
            Plugin.ManagerRemoved -= PluginOnManagerRemoved;

            if (forceUnsubscribe)
            {
                foreach (var account in Plugin.Accounts)
                {
                    PluginOnManagerRemoved(this, account);
                }
            }
            OnModuleEvent(this, Modules.ModuleEvent.Disabled);
            return new MethodResult { Success = true };
        }

        public async Task<MethodResult> LoadSettings()
        {
            var loadSettingsResult = await Settings.Load(ModuleName);

            if (!loadSettingsResult.Success)
            {
                Settings.Extra = new AutoEvolveEspeonUmbreonSettings();
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
            OnLogEvent(this, new LogModel(LoggerTypes.Success, $"OnLocationUpdateEvent Eevee Buddy on account {wrappedManager.Bot.AccountName}"), null);
            Execute(arg1);
        }

        private void OnPokemonCaughtEvent(object arg1, PokemonCaughtEventArgs arg2)
        {
            var wrappedManager = (Manager)arg1;
            OnLogEvent(this, new LogModel(LoggerTypes.Success, $"OnPokemonCaughtEvent Eevee Buddy on account {wrappedManager.Bot.AccountName}"), null);
            Execute(arg1);
        }

        private void OnPokestopFarmedEvent(object arg1, EventArgs arg2)
        {
            var wrappedManager = (Manager)arg1;
            OnLogEvent(this, new LogModel(LoggerTypes.Success, $"OnPokestopFarmedEvent Eevee Buddy on account {wrappedManager.Bot.AccountName}"), null);
            Execute(arg1);
        }

        private async void Execute(object arg1)
        {
            var wrappedManager = (Manager) arg1;
            var manager = wrappedManager.Bot;
            if (manager.State != BotState.Running) return;

            var pokemonToHandle =
                manager.Pokemon.Where(poke => poke.PokemonId == PokemonId.Eevee && poke.BuddyTotalKmWalked > 0)
                    .OrderByDescending(poke => poke.Cp)
                    .ToList();

            if (pokemonToHandle.Count == 0) return;

            var pokemonToEvolve = pokemonToHandle.Where(poke => poke.BuddyTotalKmWalked >= 10).Take(1).ToList();

            if (pokemonToEvolve.Count > 0)
            {
                var result = await manager.EvolvePokemon(pokemonToEvolve);
                OnLogEvent(this, new LogModel(LoggerTypes.Success, result.Message + $" Evolved Eevee Buddy on account {manager.AccountName}"), null);
            }
            else
            {
                var result = await manager.SetBuddyPokemon(pokemonToHandle.ElementAt(0));
                OnLogEvent(this, new LogModel(LoggerTypes.Success, result.Message + $" Set Buddy Eevee on account {manager.AccountName}"), null);
            }
        }
    }
}