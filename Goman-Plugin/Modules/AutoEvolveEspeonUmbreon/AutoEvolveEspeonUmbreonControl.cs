using System;
using System.IO;
using System.Windows.Forms;
using BrightIdeasSoftware;
using Goman_Plugin.Model;
using GoPlugin;
using GoPlugin.Extensions;

namespace Goman_Plugin.Modules.AutoEvolveEspeonUmbreon
{
    public partial class AutoEvolveEspeonUmbreonControl : UserControl
    {
        public AutoEvolveEspeonUmbreonControl()
        {
            InitializeComponent();

            this.fastObjectListViewLogs.PrimarySortColumn = this.olvColumnDate;
            this.fastObjectListViewLogs.PrimarySortOrder = SortOrder.Descending;
            this.fastObjectListViewLogs.ListFilter = new TailFilter(200);            
        }

        internal void SetControls()
        {
            cbkEnabled.Checked = Plugin.AutoEvolveEspeonUmbreonModule.Settings.Enabled;
            textBox1.Text = Plugin.AutoEvolveEspeonUmbreonModule.Settings.Extra.IntervalMilliseconds.ToString();
            fastObjectListViewLogs.SetObjects(Plugin.AutoEvolveEspeonUmbreonModule.Logs);
            //Plugin.AutoEvolveEspeonUmbreonModule.LogEvent += (o, model) =>
            //{
            //    fastObjectListViewLogs.AddObject(model);
            //};
        }

        private async void cbkEnabled_CheckedChanged(object sender, EventArgs e)
        {
            Plugin.AutoEvolveEspeonUmbreonModule.Settings.Enabled = cbkEnabled.Checked;
            await Plugin.AutoEvolveEspeonUmbreonModule.SaveSettings();
            if (!Plugin.AutoEvolveEspeonUmbreonModule.Settings.Enabled)
                await Plugin.AutoEvolveEspeonUmbreonModule.Disable(true);
            else if(!Plugin.AutoEvolveEspeonUmbreonModule.IsEnabled)
                await Plugin.AutoEvolveEspeonUmbreonModule.Enable(true);
        }

        private void fastObjectListViewLogs_FormatCell(object sender, FormatCellEventArgs e)
        {
            LogModel log = e.Model as LogModel;
            if (log != null)
            {
                e.SubItem.ForeColor = log.GetLogColor();
            }
        }

        private async void textBox1_TextChanged(object sender, EventArgs e)
        {
            int value;
            if(Int32.TryParse(textBox1.Text, out value))
            {
                Plugin.AutoEvolveEspeonUmbreonModule.Settings.Extra.IntervalMilliseconds = value;
                await Plugin.AutoEvolveEspeonUmbreonModule.SaveSettings();
            }
        }

        private void fastObjectListViewLogs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
