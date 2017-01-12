﻿using System;
using System.Collections.Generic;
using System.IO;
using GoPlugin;
using GoPlugin.Events;

namespace GoManCaptcha
{
    public class ManagerHandler
    {
        public IManager Manager { get; }
        public int SuccessCount { get; set; }
        public int FailedCount { get; set; }
        private bool SolvingCaptcha { get; set; }
        public string Log { get; set; } = "";

        public List<LogModel> EventLog = new List<LogModel>();

        public ManagerHandler(IManager manager)
        {
            Manager = manager;
            manager.OnCaptcha += OnCaptcha;
        }

        public async void OnCaptcha(object sender, CaptchaRequiredEventArgs captchaRequiredEventArgs)
        {
            if (SolvingCaptcha || !Manager.CaptchaRequired) return;

            if (!ApplicationModel.Settings.Enabled)
            {
                Manager.Stop();
                return;
            }

            SolvingCaptcha = true;

            var results = await CaptchaHandler.Handle(this);

            SuccessCount += results.Success ? 1 : 0;
            FailedCount += results.Success ? 0 : 1;

            if (!results.Success) Manager.Stop();

            SolvingCaptcha = false;
        }

        public void AddLog(LoggerTypes type, string message)
        {
            LogModel newLog = new LogModel(type, message);
            EventLog.Add(newLog);
            this.Log = newLog.ToString();
            Manager.LogCallerPlugin(newLog);

            if (ApplicationModel.Settings.SaveLogs)
                LogMessageToFile($"./Plugins/GoManLogs/{Manager.AccountName}_log.txt", message);
        }

        public static void LogMessageToFile(string path, string msg)
        {
            if (!Directory.Exists("./Plugins/GoManLogs")) Directory.CreateDirectory("./Plugins/GoManLogs");

            try
            {
                using (var sw = File.AppendText(path))
                    sw.WriteLine($"{DateTime.Now:G}: {msg}.");
            }
            catch (Exception)
            {
                //ignore
            }
        }
    }
}