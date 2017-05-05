using System;
using System.IO;
using System.Windows.Forms;
using BrightIdeasSoftware;
using Goman_Plugin.Model;
using GoPlugin;
using GoPlugin.Extensions;

namespace Goman_Plugin.Modules.AutoRename100IVOnCaught
{
    public partial class AutoRename100IVOnCaughtUserControl : UserControl
    {
        public AutoRename100IVOnCaughtUserControl()
        {
            InitializeComponent();

            this.fastObjectListViewLogs.PrimarySortColumn = this.olvColumnDate;
            this.fastObjectListViewLogs.PrimarySortOrder = SortOrder.Descending;
            this.fastObjectListViewLogs.ListFilter = new TailFilter(200);
        }

        internal void SetControls()
        {
            cbkEnabled.Checked = Plugin.AutoRename100IVOnCaughtModule.Settings.Enabled;
            fastObjectListViewLogs.SetObjects(Plugin.AutoRename100IVOnCaughtModule.Logs);
            //Plugin.AutoRename100IVOnCaughtModule.LogEvent += (o, model) =>
            //{
             //   fastObjectListViewLogs.AddObject(model);
            //};
        }

        private async void cbkEnabled_CheckedChanged(object sender, EventArgs e)
        {
            Plugin.AutoRename100IVOnCaughtModule.Settings.Enabled = cbkEnabled.Checked;
            await Plugin.AutoRename100IVOnCaughtModule.SaveSettings();
            if (!Plugin.AutoRename100IVOnCaughtModule.Settings.Enabled)
                await Plugin.AutoRename100IVOnCaughtModule.Disable(true);
            else if(!Plugin.AutoRename100IVOnCaughtModule.IsEnabled)
                await Plugin.AutoRename100IVOnCaughtModule.Enable(true);
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
