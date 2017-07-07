using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using Goman_Plugin.Model;
using Goman_Plugin.Modules;
using Goman_Plugin.Modules.AccountMap;
using Goman_Plugin.Modules.Authentication;
using Goman_Plugin.Modules.Captcha;
using Goman_Plugin.Modules.PokemonFeeder;
using Goman_Plugin.Modules.PokemonManager;
using Goman_Plugin.Modules.AutoFavoriteShiny;
using Goman_Plugin.Modules.AutoEvolveEspeonUmbreon;
using Goman_Plugin.Modules.AutoRename100IVOnCaught;
using Goman_Plugin.Modules.AutoStratTechnique;
using Goman_Plugin.View;
using Goman_Plugin.Wrapper;
using GoPlugin;
using Newtonsoft.Json;

namespace Goman_Plugin
{
    public class Plugin : IPlugin
    {

        public static ConcurrentHashSet<Manager> Accounts = new ConcurrentHashSet<Manager>();
        internal static BaseSettings<GlobalSettings> GlobalSettings = new BaseSettings<GlobalSettings>();
        internal static AccountMapModule AccountMapModule = new AccountMapModule();
        internal static AuthenticationModule AuthenticationModule = new AuthenticationModule();
        internal static PokemonFeederModule PokemonFeederModule = new PokemonFeederModule();
        internal static CaptchaModule CaptchaModule = new CaptchaModule();
        internal static AutoFavoriteShinyModule AutoFavoriteShinyModule = new AutoFavoriteShinyModule();
        internal static AutoEvolveEspeonUmbreonModule AutoEvolveEspeonUmbreonModule = new AutoEvolveEspeonUmbreonModule();
        internal static AutoRename100IVOnCaughtModule AutoRename100IVOnCaughtModule = new AutoRename100IVOnCaughtModule();
        internal static AutoStratTechniqueModule AutoStratTechniqueModule = new AutoStratTechniqueModule();

        internal static PokemonManagerModule PokemonManagerModule;
        public override string PluginName { get; set; } = "Goman Plugin";
        public override IEnumerable<PluginDropDownItem> MenuItems { get; set; }
        public static event Action<object, Manager> ManagerAdded;
        public static event Action<object, Manager> ManagerRemoved;

        public override async Task Run(IEnumerable<IManager> managers)
        {
            var captchaSettingsFrom = new MainForm(Accounts);
            captchaSettingsFrom.Show();
        }
        public override async Task<bool> Save()
        {
            var disableResult = await AuthenticationModule.Disable();
            return disableResult.Success;
        }
        public override async Task<bool> Load(IEnumerable<IManager> managers)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            await base.Load(managers);
            var globalSettingsLoadResult = await GlobalSettings.Load("PluginModule");
            if (!globalSettingsLoadResult.Success)
            {
                GlobalSettings.Extra = new GlobalSettings();
                var globalSettingsSaveResult = await GlobalSettings.Save("PluginModule");
            }

            PokemonManagerModule = new PokemonManagerModule(this);

            if (GlobalSettings.Extra.AutoUpdate)
                await Update();

            AuthenticationModule.ModuleEvent += AuthenticationModuleEvent;
            var enableResults = await AuthenticationModule.Enable();

            return enableResults.Success;
        }
        private async Task Update()
        {
            using (var wc = new WebClient())
            {
                var result = await wc.DownloadStringTaskAsync(VersionModel.Uri);
                var version = JsonConvert.DeserializeObject<VersionModel>(result);

                if (!version.Version.Equals(VersionModel.CurrentVersion))
                {
                    var updateQuestionResults =
                        MessageBox.Show("GoMan Plugin has been updated! Would you like to download the update?",
                            "GoMan Plugin Updated!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (updateQuestionResults == DialogResult.Yes)
                    {
                        await wc.DownloadFileTaskAsync(version.UpdateUrl, VersionModel.SavePath);
                        MessageBox.Show("GoMan Plugin has been updated! Restart to use updated version!",
                            "GoMan Plugin Updated!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        private async void AuthenticationModuleEvent(object o, ModuleEvent moduleEvent)
        {
            if (moduleEvent == ModuleEvent.Enabled)
            {
                await AutoFavoriteShinyModule.Enable();
                //await PokemonFeederModule.Enable();
                await AccountMapModule.Enable();
                await CaptchaModule.Enable();
                await PokemonManagerModule.Enable();
                await AutoEvolveEspeonUmbreonModule.Enable();
                await AutoRename100IVOnCaughtModule.Enable();
                await AutoStratTechniqueModule.Enable();

                foreach (var manager in _uniqueManagers)
                {
                    var wrappedManager = new Manager(manager);
                    Accounts.Add(wrappedManager);
                    OnManagerAdded(this, wrappedManager);
                }
            }
            else
            {
                foreach (var manager in _uniqueManagers)
                {
                    var wrappedManager = new Manager(manager);
                    Accounts.Add(wrappedManager);
                    OnManagerRemoved(this, wrappedManager);
                }
                await AutoFavoriteShinyModule.Disable();
                //await PokemonFeederModule.Disable();
                await AccountMapModule.Disable();
                await CaptchaModule.Disable();
                await PokemonManagerModule.Disable();
                await AutoEvolveEspeonUmbreonModule.Disable();
                await AutoRename100IVOnCaughtModule.Disable();
                await AutoStratTechniqueModule.Disable();
            }
        }

        public override void AddManager(IManager manager)
        {
            var wrappedManager = new Manager(manager);
            Accounts.Add(wrappedManager);
            OnManagerAdded(this, wrappedManager);
            base.AddManager(manager);
        }
        private void OnManagerAdded(object arg1, Manager arg2)
        {
            
            ManagerAdded?.Invoke(arg1, arg2);
        }
        public override void RemoveManager(IManager manager)
        {
            var wrappedManager = new Manager(manager);
            Accounts.Remove(wrappedManager);
            OnManagerRemoved(this, wrappedManager);
            base.RemoveManager(manager);
        }
        private void OnManagerRemoved(object arg1, Manager arg2)
        {
            ManagerRemoved?.Invoke(arg1, arg2);
        }

        public IEnumerable<IManager> GetUniqueManagers()
        {
            return _uniqueManagers;
        }
    }
}