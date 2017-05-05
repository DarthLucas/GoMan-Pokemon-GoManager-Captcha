using System;
using System.IO;
using System.Windows.Forms;
using BrightIdeasSoftware;
using Goman_Plugin.Model;
using GoPlugin;
using GoPlugin.Extensions;

namespace Goman_Plugin.Modules.AutoFavoriteShiny
{
    public partial class AutoFavoriteShinyUserControl : UserControl
    {
        public AutoFavoriteShinyUserControl()
        {
            InitializeComponent();

            this.fastObjectListViewLogs.PrimarySortColumn = this.olvColumnDate;
            this.fastObjectListViewLogs.PrimarySortOrder = SortOrder.Descending;
            this.fastObjectListViewLogs.ListFilter = new TailFilter(200);
        }

        internal void SetControls()
        {
            cbkEnabled.Checked = Plugin.AutoFavoriteShinyModule.Settings.Enabled;
            fastObjectListViewLogs.SetObjects(Plugin.AutoFavoriteShinyModule.Logs);
            //Plugin.AutoFavoriteShinyModule.LogEvent += (o, model) =>
            //{
             //   fastObjectListViewLogs.AddObject(model);
            //};
        }

        private async void cbkEnabled_CheckedChanged(object sender, EventArgs e)
        {
            Plugin.AutoFavoriteShinyModule.Settings.Enabled = cbkEnabled.Checked;
            await Plugin.AutoFavoriteShinyModule.SaveSettings();
            if (!Plugin.AutoFavoriteShinyModule.Settings.Enabled)
                await Plugin.AutoFavoriteShinyModule.Disable(true);
            else if(!Plugin.AutoFavoriteShinyModule.IsEnabled)
                await Plugin.AutoFavoriteShinyModule.Enable(true);
        }

        private void fastObjectListViewLogs_FormatCell(object sender, FormatCellEventArgs e)
        {
            LogModel log = e.Model as LogModel;
            if (log != null)
            {
                e.SubItem.ForeColor = log.GetLogColor();
            }
        }
    }
}
