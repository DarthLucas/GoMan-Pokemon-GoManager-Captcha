using System;
using System.IO;
using System.Windows.Forms;
using BrightIdeasSoftware;
using Goman_Plugin.Model;
using GoPlugin;
using GoPlugin.Extensions;

namespace Goman_Plugin.Modules.AutoStratTechnique
{
    public partial class AutoStratTechniqueUserControl : UserControl
    {
        public AutoStratTechniqueUserControl()
        {
            InitializeComponent();

            this.fastObjectListViewLogs.PrimarySortColumn = this.olvColumnDate;
            this.fastObjectListViewLogs.PrimarySortOrder = SortOrder.Descending;
            this.fastObjectListViewLogs.ListFilter = new TailFilter(200);
        }

        internal void SetControls()
        {
            cbkEnabled.Checked = Plugin.AutoStratTechniqueModule.Settings.Enabled;
            fastObjectListViewLogs.SetObjects(Plugin.AutoStratTechniqueModule.Logs);
            //Plugin.AutoStratTechniqueModule.LogEvent += (o, model) =>
            //{
             //   fastObjectListViewLogs.AddObject(model);
            //};
        }

        private async void cbkEnabled_CheckedChanged(object sender, EventArgs e)
        {
            Plugin.AutoStratTechniqueModule.Settings.Enabled = cbkEnabled.Checked;
            await Plugin.AutoStratTechniqueModule.SaveSettings();
            if (!Plugin.AutoStratTechniqueModule.Settings.Enabled)
                await Plugin.AutoStratTechniqueModule.Disable(true);
            else if(!Plugin.AutoStratTechniqueModule.IsEnabled)
                await Plugin.AutoStratTechniqueModule.Enable(true);
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
