using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Goman_Plugin.Helpers;
using Goman_Plugin.Wrapper;
using GoPlugin.Events;
using Newtonsoft.Json;
using MethodResult = Goman_Plugin.Model.MethodResult;
using Timer = System.Timers.Timer;

namespace Goman_Plugin.Modules.AccountMap
{
    public class AccountMapModule : AbstractModule
    {
        public new BaseSettings<AccountMapSettings> Settings { get; }
        public event Action<object, LocationUpdateEventArgs> LocationUpdate;
        public AccountMapModule()
        {
            Settings = new BaseSettings<AccountMapSettings>() { Enabled = true };
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

            return new MethodResult() { Success = Settings.Enabled };
        }
        public override async Task<MethodResult> Disable(bool forceUnsubscribe = false)
        {
            Plugin.ManagerAdded -= PluginOnManagerAdded;
            Plugin.ManagerRemoved -= PluginOnManagerRemoved;

            await Settings.Save(ModuleName);

            if (forceUnsubscribe)
            {
                foreach (var account in Plugin.Accounts)
                {
                    PluginOnManagerRemoved(this, account);
                }
            }
            OnModuleEvent(this, Modules.ModuleEvent.Disabled);
            return new MethodResult() { Success = true };
        }
        public async Task<MethodResult> LoadSettings()
        {
            var loadSettingsResult = await Settings.Load(ModuleName);
          
            if (!loadSettingsResult.Success)
            {
                Settings.Extra = new AccountMapSettings();
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
            manager.Bot.OnLocationUpdate += BotOnOnLocationUpdate;
        }

        private void BotOnOnLocationUpdate(object sender, LocationUpdateEventArgs locationUpdateEventArgs)
        {
            OnLocationUpdate(sender, locationUpdateEventArgs);
        }
        protected virtual void OnLocationUpdate(object arg1, LocationUpdateEventArgs arg2)
        {
            LocationUpdate?.Invoke(arg1, arg2);
        }

        private void PluginOnManagerRemoved(object o, Manager manager)
        {
            //OnLogEvent(this, new LogModel(LoggerTypes.Info, $"Unsubscribing to account {manager.Bot.AccountName}"));
            manager.Bot.OnLocationUpdate -= BotOnOnLocationUpdate;
        }
    }
}
