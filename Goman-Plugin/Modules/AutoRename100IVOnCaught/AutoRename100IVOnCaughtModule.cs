using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Goman_Plugin.Helpers;
using Goman_Plugin.Model;
using Goman_Plugin.Wrapper;
using GoPlugin;
using GoPlugin.Events;
using Newtonsoft.Json;
using MethodResult = Goman_Plugin.Model.MethodResult;
using POGOProtos.Data;
using System.Linq;

namespace Goman_Plugin.Modules.AutoRename100IVOnCaught
{
    public class AutoRename100IVOnCaughtModule : AbstractModule
    {
        public new BaseSettings<AutoRename100IVOnCaughtSettings> Settings { get; }

        public AutoRename100IVOnCaughtModule()
        {
            Settings = new BaseSettings<AutoRename100IVOnCaughtSettings> { Enabled = true };
        }
        public async override Task<MethodResult> Disable(bool forceUnubscribe = false)
        {
            Plugin.ManagerAdded -= PluginOnManagerAdded;
            Plugin.ManagerRemoved -= PluginOnManagerRemoved;
            await SaveSettings();
            if (forceUnubscribe)
            {
                foreach (var account in Plugin.Accounts)
                {
                    PluginOnManagerRemoved(this, account);
                }
            }
            OnModuleEvent(this, Modules.ModuleEvent.Disabled);
            return new MethodResult() { Success = true }; //Login();
        }

        public async override Task<MethodResult> Enable(bool forceSubscribe = false)
        {
            await LoadSettings();
            // Settings.Extra.MyAwesomeSetting //acccess it like this
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
            return new MethodResult { Success = true };
        }

        public async Task<MethodResult> LoadSettings()
        {
            var loadSettingsResult = await Settings.Load(ModuleName);

            if (!loadSettingsResult.Success)
            {
                Settings.Extra = new AutoRename100IVOnCaughtSettings();
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
            manager.Bot.OnPokemonCaught += OnPokemonCaught;
        }

        private void PluginOnManagerRemoved(object o, Manager manager)
        {
            // OnLogEvent(this, new LogModel(LoggerTypes.Info, $"Unsubscribing to account {manager.Bot.AccountName}"));
            manager.Bot.OnPokemonCaught -= OnPokemonCaught;
        }

        private async void OnPokemonCaught(object sender, PokemonCaughtEventArgs e)
        {
            var manager = (IManager)sender;            
            if (e.CatchResponse.Status == POGOProtos.Networking.Responses.CatchPokemonResponse.Types.CatchStatus.CatchSuccess)
            {
                
                PokemonData lastCaught = Helpers.GomanHttpHelper.getPokemonCaught(manager.Pokemon, e.Pokemon);
                if(manager.CalculateIVPerfection(lastCaught).Data­>99)
                { 
                await manager.RenameAllPokemonToIV(new List<PokemonData>() { lastCaught });
               }
                OnLogEvent(this, GetLog(new MethodResult() { Message = "Renamed Pokemon" + lastCaught.PokemonId.ToString(), MethodName = "RenameWithIv" }));
            }
        }
    }
}

