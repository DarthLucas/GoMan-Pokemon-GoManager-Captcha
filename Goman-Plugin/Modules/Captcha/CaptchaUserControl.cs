using System;
using System.Drawing;
using System.Linq;
using System.Timers;
using System.Windows.Forms;
using BrightIdeasSoftware;
using Goman_Plugin.Model;
using Goman_Plugin.Wrapper;
using GoPlugin;
using GoPlugin.Enums;
using Timer = System.Timers.Timer;

namespace Goman_Plugin.Modules.Captcha
{
    public partial class CaptchaUserControl : UserControl
    {
        private readonly Timer _timer;
        public CaptchaUserControl()
        {
           InitializeComponent();
            _timer = new Timer(1000);
            _timer.Elapsed += _timer_Elapsed;
            _timer.Enabled = true;

            this.fastObjectListViewLogs.PrimarySortColumn = this.olvColumnDate;
            this.fastObjectListViewLogs.PrimarySortOrder = SortOrder.Descending;
            this.fastObjectListViewLogs.ListFilter = new TailFilter(200);
        }
        internal void Opening()
        {
            this.fastObjecttListViewAccounts.PrimarySortColumn = this.olvBotState;
            this.fastObjecttListViewAccounts.PrimarySortOrder = SortOrder.Descending;

            fastObjecttListViewAccounts.SetObjects(Plugin.Accounts);

            textBox2CaptchaApiKey.Text = Plugin.CaptchaModule.Settings.Extra.CaptchaKey;
            numericUpDownSolveAttempts.Value = Plugin.CaptchaModule.Settings.Extra.SolveAttemptsBeforeStop;
            cbkEnabled.Checked = Plugin.CaptchaModule.Settings.Enabled;

            fastObjectListViewLogs.SetObjects(Plugin.CaptchaModule.Logs);
            Plugin.CaptchaModule.LogEvent += LogEvent;
        }

        internal void Closing()
        {
            Plugin.CaptchaModule.LogEvent -= LogEvent;
        }
        private void LogEvent(object arg1, LogModel arg2)
        {
            fastObjectListViewLogs.AddObject(arg2);
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            fastObjecttListViewAccounts.RefreshObject(Plugin.Accounts.First());
        }

        private void fastObjecttListViewAccounts_FormatCell(object sender, BrightIdeasSoftware.FormatCellEventArgs e)
        {
            
            var managerWrapper = (Manager)e.Model;
            var manager = managerWrapper.Bot;

            if (manager != null)
            {
                if (e.Column == this.olvAccountState)
                {
                    switch (manager.AccountState)
                    {
                        case AccountState.Good:
                            e.SubItem.ForeColor = Color.Green;
                            break;
                        case AccountState.PermAccountBan:
                        case AccountState.NotVerified:
                            e.SubItem.ForeColor = Color.Red;
                            break;
                        case AccountState.AccountWarning:
                        case AccountState.PokemonBanAndPokestopBanTemp:
                        case AccountState.PokestopBanTemp:
                        case AccountState.PokemonBanTemp:
                            e.SubItem.ForeColor = Color.Yellow;
                            break;
                        case AccountState.CaptchaRequired:
                            e.SubItem.ForeColor = Color.MediumAquamarine;
                            break;
                    }
                }
                else if (e.Column == this.olvBotState)
                {
                    switch (manager.State)
                    {
                        case BotState.Stopped:
                            e.SubItem.ForeColor = Color.Red;
                            break;
                        case BotState.Stopping:
                            e.SubItem.ForeColor = Color.OrangeRed;
                            break;
                        case BotState.Starting:
                            e.SubItem.ForeColor = Color.LightGreen;
                            break;
                        case BotState.Running:
                            e.SubItem.ForeColor = Color.Green;
                            break;
                        case BotState.Pausing:
                            e.SubItem.ForeColor = Color.MediumAquamarine;
                            break;
                        case BotState.Paused:
                            e.SubItem.ForeColor = Color.MediumAquamarine;
                            break;
                    }
                }
                else if (e.Column == olvLastLog)
                {
                    if (managerWrapper.Log == null)
                    {
                        return;
                    }

                    e.SubItem.ForeColor = managerWrapper.Log.GetLogColor();
                }
            }
        }
        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Manager selectedObject in fastObjecttListViewAccounts.SelectedObjects)
            {
                selectedObject.Bot.Start();
            }
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Manager selectedObject in fastObjecttListViewAccounts.SelectedObjects)
            {
                selectedObject.Bot.Restart();
            }
        }

        private void togglePauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Manager selectedObject in fastObjecttListViewAccounts.SelectedObjects)
            {
                selectedObject.Bot.TogglePause();
            }
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Manager selectedObject in fastObjecttListViewAccounts.SelectedObjects)
            {
                selectedObject.Bot.Stop();
            }
        }
        private async void textBox2CaptchaApiKey_TextChanged(object sender, EventArgs e)
        {
            Plugin.CaptchaModule.Settings.Extra.CaptchaKey = textBox2CaptchaApiKey.Text;
            await Plugin.CaptchaModule.SaveSettings();
        }

        private async void numericUpDownSolveAttempts_ValueChanged(object sender, EventArgs e)
        {
            Plugin.CaptchaModule.Settings.Extra.SolveAttemptsBeforeStop = (int)numericUpDownSolveAttempts.Value;
            await Plugin.CaptchaModule.SaveSettings();
        }

        private async void cbkEnabled_CheckedChanged(object sender, EventArgs e)
        {
            Plugin.CaptchaModule.Settings.Enabled = cbkEnabled.Checked;
            await Plugin.CaptchaModule.SaveSettings();
            if (!Plugin.CaptchaModule.Settings.Enabled)
                await Plugin.CaptchaModule.Disable(true);
            else if (!Plugin.CaptchaModule.IsEnabled)
                await Plugin.CaptchaModule.Enable(true);
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
