using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Timers;
using System.Windows.Forms;
using BrightIdeasSoftware;
using Goman_Plugin.Model;
using GoPlugin;
using GoPlugin.Enums;
using GoPlugin.Events;
using Timer = System.Timers.Timer;

namespace Goman_Plugin.Wrapper
{
    public class Manager
    {
        public IManager Bot { get; }
        private static readonly Munger LevelMunger = new Munger("Level");
        private static readonly Munger LogMunger = new Munger("Logs");
        private static readonly Munger LastLogMessageMunger = new Munger("LastLogMessage");
        private static readonly Munger ExpPerHourMunger = new Munger("ExpPerHour");
        private static readonly Munger RunTimeMunger = new Munger("RunningTime");
        private static readonly Munger TillLevelUpMunger = new Munger("TillLevelUp");

        public event Action<object, EventArgs> ManagerChanged;
        public int SuccessCount { get; set; }
        public int FailedCount { get; set; }
        public bool SolvingCaptcha { get; set; }
        public bool AutoFavoriting { get; set; }
        public bool AutoUpgrading { get; set; }
        public bool AutoEvolving { get; set; }
        public bool AutoNaming { get; set; }        

        public LogModel Log { get; set; }
        public string ExpPerHour => ExpPerHourMunger.GetValue(Bot).ToString();
        public string Level
        {
            get
            {
                try
                {
                    var level = LevelMunger.GetValue(Bot).ToString(); ;
                    return level;
                }
                catch
                {
                    return "0";
                }
            }
        }
        public List<Log> Logs
        {
            get
            {
                var logs = LogMunger.GetValue(Bot) as List<Log>;
                if (logs == null || logs.Count == 0) return null;
                return logs;
            }
        }

        public string LastLog => LastLogMessageMunger.GetValue(Bot).ToString();
        public string RunTime => RunTimeMunger.GetValue(Bot).ToString();
        public string TillLevelUp => TillLevelUpMunger.GetValue(Bot).ToString();

        private string _lastName;
        private AccountState _lastAccountState;
        private BotState _lasBotState;
        private string _lastExpPerHour;
        private string _lastLevel;
        private string _lastLastLog;
        private string _lastRunTime;
        private string _lastTillLevelUp;
        private string _settings;

        public Timer ChangeTimer;
        public Timer RunningTimeTimer;
        public Manager(IManager bot)
        {
            Bot = bot;

            _lastName = Bot.AccountName;
            _lastAccountState = Bot.AccountState;
            _lasBotState = Bot.State;
            _lastExpPerHour = ExpPerHour;
            _lastLastLog = LastLog;
            _lastRunTime = RunTime;
            _lastTillLevelUp = TillLevelUp;
            _lastLevel = Level;

            ChangeTimer = new Timer(1000);
            ChangeTimer.Elapsed += _changeTimer_Elapsed;
            ChangeTimer.Enabled = true;

            bot.OnCaptcha += OnCaptcha;
        }
        public event Action<object, CaptchaRequiredEventArgs> OnCaptchaEvent;
        private void OnCaptcha(object sender, CaptchaRequiredEventArgs captchaRequiredEventArgs)
        {
            OnOnCaptchaEvent(this, captchaRequiredEventArgs);
        }

        private void _changeTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if(Bot.State == BotState.Stopped && Bot.AccountState == AccountState.CaptchaRequired)
                OnOnCaptchaEvent(this, null);

            if (!StateChanged()) return;
            OnManagerChanged(this);
            _lastName = Bot.AccountName;
            _lastAccountState = Bot.AccountState;
            _lasBotState = Bot.State;
            _lastExpPerHour = ExpPerHour;
            _lastLastLog = LastLog;
            _lastRunTime = RunTime;
            _lastTillLevelUp = TillLevelUp;
            _lastLevel = Level;
        }
        private bool StateChanged()
        {
            return !_lastName.Equals(Bot.AccountName) ||
                   !_lastAccountState.Equals(Bot.AccountState) ||
                   !_lasBotState.Equals(Bot.State) ||
                   !_lastExpPerHour.Equals(ExpPerHour) ||
                   !_lastLastLog.Equals(LastLog) ||
                   !_lastRunTime.Equals(RunTime) ||
                   !_lastTillLevelUp.Equals(TillLevelUp) ||
                   !_lastLevel.Equals(Level);
        }
        private bool Equals(Manager other)
        {
            return Bot.Username.Equals(other.Bot.Username);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((Manager) obj);
        }
        public override int GetHashCode()
        {
            return Bot?.Username.GetHashCode() ?? 0;
        }
        protected void OnManagerChanged(object arg1)
        {
            ManagerChanged?.Invoke(arg1, EventArgs.Empty);
        }
        protected virtual void OnOnCaptchaEvent(object arg1, CaptchaRequiredEventArgs arg2)
        {
            OnCaptchaEvent?.Invoke(arg1, arg2);
        }
    }
}
