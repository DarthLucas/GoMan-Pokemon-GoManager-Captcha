using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Goman_Plugin.Model;
using Goman_Plugin.Modules;
using Goman_Plugin.Wrapper;

namespace Goman_Plugin.View
{
    public partial class MainForm : Form
    {
        private readonly ConcurrentHashSet<Manager> _accounts;
        public MainForm(ConcurrentHashSet<Manager> managers)
        {
            InitializeComponent();
            _accounts = managers;
            this.Text = "GoMan Plugin - v" + VersionModel.CurrentVersion;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            cbkSaveLogs.Checked = Plugin.GlobalSettings.Extra.SaveLogs;
            cbkAutoUpdate.Checked = Plugin.GlobalSettings.Extra.AutoUpdate;
            numericUpDownMaximumLogs.Value = Plugin.GlobalSettings.Extra.MaximumLogs;

            captchaUserControl1.Opening();
            _accountMapUserControl1.Opening();
            pokemonManagerUserControl1.Opening();
            autoEvolveEspeonUmbreonControl1.Opening();
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            captchaUserControl1.Closing();
            _accountMapUserControl1.Closing();
            pokemonManagerUserControl1.Closing();
            autoEvolveEspeonUmbreonControl1.Closing();
        }
        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
           var ctlTab = (BorderlessTabControl)sender;
            var g = e.Graphics;
            var sText = ctlTab.TabPages[e.Index].Text;
            var sizeText = g.MeasureString(sText, ctlTab.Font);
            var iX = e.Bounds.Left + 6;
            var iY = (int) (e.Bounds.Top + (e.Bounds.Height - sizeText.Height) / 2);
            g.DrawString(sText, ctlTab.Font, Brushes.Black, iX, iY);
        }

        private async void cbkSaveLogs_CheckedChanged(object sender, EventArgs e)
        {
            Plugin.GlobalSettings.Extra.SaveLogs = cbkSaveLogs.Checked;
            await Plugin.GlobalSettings.Save("PluginModule");
        }
        private async void ckAutoUpdate_CheckedChanged(object sender, EventArgs e)
        {
            Plugin.GlobalSettings.Extra.AutoUpdate = cbkAutoUpdate.Checked;
            await Plugin.GlobalSettings.Save("PluginModule");
        }
        private async void numericUpDownMaximumLogs_ValueChanged(object sender, EventArgs e)
        {
            Plugin.GlobalSettings.Extra.MaximumLogs = (int)numericUpDownMaximumLogs.Value;
            await Plugin.GlobalSettings.Save("PluginModule");
        }

        private void toolStripStatusLabelAccountCreator_Click(object sender, EventArgs e)
        {
            Process.Start("https://goman.io/product/goman-account-creator-beta/");
        }
        private void toolStripStatusLabelDonate_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.paypal.me/GoMan/");
        }
        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            Process.Start("https://goman.io");
        }

        private void toolStripStatusLabelDiscord_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/2ZBB53e");
        }
    }
}
