using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BrightIdeasSoftware;
using Goman_Plugin.Model;
using GoPlugin;
using GoPlugin.Extensions;

namespace Goman_Plugin.Modules.PokemonManager
{
    public partial class PokemonManagerUserControl : UserControl
    {
        public PokemonManagerUserControl()
        {
            InitializeComponent();

            this.fastObjectListViewLogs.PrimarySortColumn = this.olvColumnDate;
            this.fastObjectListViewLogs.PrimarySortOrder = SortOrder.Descending;
            this.fastObjectListViewLogs.ListFilter = new TailFilter(200);
        }

        internal void SetControls()
        {
            cbkEnabled.Checked = Plugin.PokemonManagerModule.Settings.Enabled;
            fastObjectListViewLogs.SetObjects(Plugin.PokemonManagerModule.Logs);
            fastObjectListViewPokemon.SetObjects(Plugin.PokemonManagerModule.Settings.Extra.Pokemons.Values.ToList());
           // Plugin.PokemonManagerModule.LogEvent += (o, model) => fastObjectListViewLogs.AddObject(model);
        }

        private async void cbkEnabled_CheckedChanged(object sender, EventArgs e)
        {
            Plugin.PokemonManagerModule.Settings.Enabled = cbkEnabled.Checked;
            await Plugin.PokemonManagerModule.SaveSettings();
            if (!Plugin.PokemonManagerModule.Settings.Enabled)
                await Plugin.PokemonManagerModule.Disable(true);
            else if(!Plugin.PokemonManagerModule.IsEnabled)
                await Plugin.PokemonManagerModule.Enable(true);
        }

        private void fastObjectListViewLogs_FormatCell(object sender, FormatCellEventArgs e)
        {
            LogModel log = e.Model as LogModel;
            if (log != null)
            {
                e.SubItem.ForeColor = log.GetLogColor();
            }
        }

        private void fastObjectListViewPokemon_FormatCell(object sender, FormatCellEventArgs e)
        {
            PokemonManager pokemon = e.Model as PokemonManager;
            if (pokemon != null)
            {
               if (e.Column == this.olvColumnAutoEvolve)
                    e.SubItem.ForeColor = (pokemon.AutoEvolve) ? Color.Green : Color.Red;
                else if (e.Column == this.olvColumnAutoFavorite)
                    e.SubItem.ForeColor = (pokemon.AutoFavorite) ? Color.Green : Color.Red;
                else if (e.Column == this.olvColumnAutoUpgrade)
                    e.SubItem.ForeColor = (pokemon.AutoUpgrade) ? Color.Green : Color.Red;
                else if (e.Column == this.olvColumnAutoRenameWithIv)
                    e.SubItem.ForeColor = (pokemon.AutoRenameWithIv) ? Color.Green : Color.Red;

            }

           //if (e.Column == this.olvColumnPokemonId)
           //    e.SubItem.ForeColor = Color.Purple;
           //else if (e.Column == olvColumnIvAboveOrEqualTo)
           //    e.SubItem.ForeColor = Color.Blue;
           //else
        }

        private async void setIVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string data = Prompt.ShowDialog("Set IV", "Minimum IV", "50");
            int value;

            if (!int.TryParse(data, out value)) return;
            foreach (PokemonManager pokemonManager in fastObjectListViewPokemon.SelectedObjects)
                Plugin.PokemonManagerModule.Settings.Extra.Pokemons[pokemonManager.PokemonId].MinimumIv =
                    value;

            fastObjectListViewPokemon.RefreshObjects(Plugin.PokemonManagerModule.Settings.Extra.Pokemons.Values.ToList());
            await Plugin.PokemonManagerModule.SaveSettings();
        }

        private async void setCPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string data = Prompt.ShowDialog("Set Cp", "Minimum Cp", "1000");
            int value;

            if (!int.TryParse(data, out value)) return;
            foreach (PokemonManager pokemonManager in fastObjectListViewPokemon.SelectedObjects)
                Plugin.PokemonManagerModule.Settings.Extra.Pokemons[pokemonManager.PokemonId].MinimumCp =
                    value;

            fastObjectListViewPokemon.RefreshObjects(Plugin.PokemonManagerModule.Settings.Extra.Pokemons.Values.ToList());
            await Plugin.PokemonManagerModule.SaveSettings();
        }

        private async void setQuantityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string data = Prompt.ShowDialog("Set Quantity", "Quantity", "5");
            int value;

            if (!int.TryParse(data, out value)) return;
            foreach (PokemonManager pokemonManager in fastObjectListViewPokemon.SelectedObjects)
                Plugin.PokemonManagerModule.Settings.Extra.Pokemons[pokemonManager.PokemonId].Quantity =
                    value;

            fastObjectListViewPokemon.RefreshObjects(Plugin.PokemonManagerModule.Settings.Extra.Pokemons.Values.ToList());
            await Plugin.PokemonManagerModule.SaveSettings();
        }

        private bool blockSaving = false;
        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            blockSaving = true;
            ContextOptions contextOptions = GetContextOptions();

            autoEvolveToolStripMenuItem.Checked = contextOptions.AutoEvolveIsEnabled;
            autoFavoriteToolStripMenuItem.Checked = contextOptions.AutoFavoriteIsEnabled;
            autoUpgradeToolStripMenuItem.Checked = contextOptions.AutoUpgradeIsEnabled;
            autoRenameToIVToolStripMenuItem.Checked = contextOptions.AutoRenameIsEnabled;

            blockSaving = false;
        }

        private ContextOptions GetContextOptions()
        {
            ContextOptions contextOptions = new ContextOptions();
            foreach (PokemonManager pokemonManager in fastObjectListViewPokemon.SelectedObjects)
            {
                if (!pokemonManager.AutoEvolve)
                    contextOptions.AutoEvolveIsEnabled = false;
                if (!pokemonManager.AutoFavorite)
                    contextOptions.AutoFavoriteIsEnabled = false;
                if (!pokemonManager.AutoUpgrade)
                    contextOptions.AutoUpgradeIsEnabled = false;
                if (!pokemonManager.AutoRenameWithIv)
                    contextOptions.AutoRenameIsEnabled = false;
            }

            return contextOptions;
        }

        private async void autoFavoriteToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (blockSaving) return;
            foreach (PokemonManager pokemonManager in fastObjectListViewPokemon.SelectedObjects)
                Plugin.PokemonManagerModule.Settings.Extra.Pokemons[pokemonManager.PokemonId].AutoFavorite = autoFavoriteToolStripMenuItem.Checked;

            fastObjectListViewPokemon.RefreshObjects(Plugin.PokemonManagerModule.Settings.Extra.Pokemons.Values.ToList());
            await Plugin.PokemonManagerModule.SaveSettings();
        }

        private async void autoUpgradeToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (blockSaving) return;
            foreach (PokemonManager pokemonManager in fastObjectListViewPokemon.SelectedObjects)
                Plugin.PokemonManagerModule.Settings.Extra.Pokemons[pokemonManager.PokemonId].AutoUpgrade = autoUpgradeToolStripMenuItem.Checked;

            fastObjectListViewPokemon.RefreshObjects(Plugin.PokemonManagerModule.Settings.Extra.Pokemons.Values.ToList());
            await Plugin.PokemonManagerModule.SaveSettings();
        }

        private async void autoEvolveToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (blockSaving) return;
            foreach (PokemonManager pokemonManager in fastObjectListViewPokemon.SelectedObjects)
                Plugin.PokemonManagerModule.Settings.Extra.Pokemons[pokemonManager.PokemonId].AutoEvolve = autoEvolveToolStripMenuItem.Checked;
            
            fastObjectListViewPokemon.RefreshObjects(Plugin.PokemonManagerModule.Settings.Extra.Pokemons.Values.ToList());
            await Plugin.PokemonManagerModule.SaveSettings();
        }

        private async void autoRenameToIVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (blockSaving) return;
            foreach (PokemonManager pokemonManager in fastObjectListViewPokemon.SelectedObjects)
                Plugin.PokemonManagerModule.Settings.Extra.Pokemons[pokemonManager.PokemonId].AutoRenameWithIv = autoRenameToIVToolStripMenuItem.Checked;

            fastObjectListViewPokemon.RefreshObjects(Plugin.PokemonManagerModule.Settings.Extra.Pokemons.Values.ToList());
            await Plugin.PokemonManagerModule.SaveSettings();
        }
    }

    public class ContextOptions
    {
        public bool AutoEvolveIsEnabled { get; set; } = true;
        public bool AutoFavoriteIsEnabled { get; set; } = true;
        public bool AutoUpgradeIsEnabled { get; set; } = true;
        public bool AutoRenameIsEnabled { get; set; } = true;
    }
}
