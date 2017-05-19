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
using BrightIdeasSoftware;

namespace Goman_Plugin.Modules.AutoStratTechnique
{
    public class AutoStratTechniqueModule : AbstractModule
    {
        public new BaseSettings<AutoStratTechniqueSettings> Settings { get; }
        public Munger LastLogMessageMunger { get; set; }

        public AutoStratTechniqueModule()
        {
            Settings = new BaseSettings<AutoStratTechniqueSettings> { Enabled = false };
            LastLogMessageMunger = new Munger("LastLogMessage");
        }
        public override async Task<MethodResult> Disable(bool forceUnubscribe = false)
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

        public override async Task<MethodResult> Enable(bool forceSubscribe = false)
        {
            await LoadSettings();
            // Settings.Extra.MyAwesomeSetting //acccess it like this
            if (!Settings.Enabled) return new MethodResult {Success = true};
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
            return new MethodResult { Success = true };
        }

        public async Task<MethodResult> LoadSettings()
        {
            var loadSettingsResult = await Settings.Load(ModuleName);

            if (!loadSettingsResult.Success)
            {
                Settings.Extra = new AutoStratTechniqueSettings();
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

        private async Task DoStrat(IManager manager, PokemonData lastCaught)
        {
            if (lastCaught.PokemonId == POGOProtos.Enums.PokemonId.Gastly)
            {
                if (GomanHttpHelper.GetPokemonLevel(manager, lastCaught) <= 2.5)
                {
                    if (manager.CalculateIVPerfection(lastCaught).Data < 30)
                    {
                        if (lastCaught.Move1 == POGOProtos.Enums.PokemonMove.AstonishFast)
                        {
                            int totalCandy =
                            manager.PokemonCandy
                                .FirstOrDefault(x => x.FamilyId == POGOProtos.Enums.PokemonFamilyId.FamilyGastly).Candy_;
                            if(totalCandy<4)
                            {
                                await manager.TransferPokemon(new List<PokemonData>() { lastCaught });
                                OnLogEvent(this, GetLog(new MethodResult() { Message = "Transfered Stratted because not enough candy" + lastCaught.PokemonId.ToString(), MethodName = "Trasnfer" }));
                                return;
                            }
                            string LastLog = "fuckletas";
                            while (GomanHttpHelper.GetPokemonLevel(manager, lastCaught) <= 2.5&&!LastLog.Contains("UpgradeNotAvailable") && !LastLog.Contains("InsufficientResources"))
                            {
                                await manager.UpgradePokemon(new List<PokemonData>() { lastCaught }, 1);
                                LastLog = this.LastLogMessageMunger.GetValue(manager).ToString();
                                await Task.Delay(500);
                            }
                            await manager.FavoritePokemon(new List<PokemonData>() { lastCaught });
                            OnLogEvent(this, GetLog(new MethodResult() { Message = "Favorited STRAT" + lastCaught.PokemonId.ToString(), MethodName = "Favorite" }));
                            return;
                        }
                    }
                }
            }
            else if (lastCaught.PokemonId == POGOProtos.Enums.PokemonId.Abra || lastCaught.PokemonId == POGOProtos.Enums.PokemonId.Kadabra)
            {
                if (GomanHttpHelper.GetPokemonLevel(manager, lastCaught) == 1)
                {
                    if (manager.CalculateIVPerfection(lastCaught).Data < 30)
                    {
                        if (lastCaught.PokemonId == POGOProtos.Enums.PokemonId.Abra)
                        {
                            var id = lastCaught.Id;
                            await manager.EvolvePokemon(new List<PokemonData>() { lastCaught });
                            await Task.Delay(500);                            
                        }                    
                        var evolve = manager.Pokemon.Where(x => x.Move1 == POGOProtos.Enums.PokemonMove.ConfusionFast && x.Favorite == Convert.ToInt32(false));
                        foreach(PokemonData poke in evolve)
                        {
                            int totalCandy =
                            manager.PokemonCandy
                                .FirstOrDefault(x => x.FamilyId == POGOProtos.Enums.PokemonFamilyId.FamilyAbra).Candy_;
                            if(totalCandy<25)
                            {
                                await manager.TransferPokemon(new List<PokemonData>() { poke });
                                OnLogEvent(this, GetLog(new MethodResult() { Message = "Transfered Stratted because not enough candy" + lastCaught.PokemonId.ToString(), MethodName = "Trasnfer" }));
                                return;
                            }
                            await manager.FavoritePokemon(new List<PokemonData>() { poke });
                            OnLogEvent(this, GetLog(new MethodResult() { Message = "Favorited STRAT" + poke.PokemonId.ToString(), MethodName = "Favorite" }));                            
                        }
                        return;
                    }
                }
            }

            await manager.TransferPokemon(new List<PokemonData>() { lastCaught });
        }
        private async void OnPokemonCaught(object sender, PokemonCaughtEventArgs e)
        {            
            var manager = (IManager)sender;
            if (manager.Pokemon.Count() > 10)
            {
                //var strattedPoke = manager.Pokemon.Where(x => x.PokemonId == POGOProtos.Enums.PokemonId.Abra || x.PokemonId == POGOProtos.Enums.PokemonId.Kadabra || x.PokemonId == POGOProtos.Enums.PokemonId.Gastly).OrderBy(x => manager.CalculateIVPerfection(x).Data);                    
                List<PokemonData> list_poke = new List<PokemonData>(manager.Pokemon); 
                foreach (PokemonData pokemon in list_poke)
                {
                    await DoStrat(manager, pokemon);
                }
                return;
            }
            if (e.CatchResponse.Status == POGOProtos.Networking.Responses.CatchPokemonResponse.Types.CatchStatus.CatchSuccess)
            {
                PokemonData lastCaught = Helpers.GomanHttpHelper.getPokemonCaught(manager.Pokemon, e.Pokemon);
                await DoStrat(manager, lastCaught);
            }
        }
    }
}

