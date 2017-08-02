using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Goman_Plugin.Model;
using Goman_Plugin.Wrapper;
using GoPlugin;
using GoPlugin.Enums;
using MethodResult = Goman_Plugin.Model.MethodResult;

namespace Goman_Plugin.Modules.Captcha
{
    class CaptchaHandler
    {
        private static readonly Func<string, string, IManager, Task<MethodResult>> SolveCaptchaAction = async (captchaKey, captchaUrl, manager) => await SolveCaptcha(captchaKey, captchaUrl, manager);
        private static readonly HashSet<string> CaptchaExceptions = new HashSet<string>()
        {

            "ERROR_WRONG_USER_KEY",
            "ERROR_KEY_DOES_NOT_EXIST",
            "ERROR_ZERO_BALANCE"
        };

        public static async Task<MethodResult> Handle(Manager managerHandler)
        {

            if (managerHandler?.Bot == null) return new MethodResult() {Success = false};
            var manager = managerHandler.Bot;

            while (manager.State == BotState.Pausing)
                await Task.Delay(250);

            var solveCaptchaRetryActionResults = await RetryAction(
                SolveCaptchaAction,
                Plugin.CaptchaModule.Settings.Extra.CaptchaKey,
                manager.CaptchaURL,
                manager, Plugin.CaptchaModule.Settings.Extra.SolveAttemptsBeforeStop);

            if (!solveCaptchaRetryActionResults.Success)
            {
                var captchaError = CaptchaExceptions.Any(x => x.Contains(x));
                if (captchaError)
                {
                    Plugin.CaptchaModule.Settings.Enabled = false;
                    solveCaptchaRetryActionResults.Message = $"2Captcha {solveCaptchaRetryActionResults.Message}";
                }
            }

            if (solveCaptchaRetryActionResults.Success) solveCaptchaRetryActionResults.Message = "Success";

            return solveCaptchaRetryActionResults;
        }

        private static async Task<MethodResult> SolveCaptcha(string captchaKey, string captchaUrl, IManager manager)
        {
            var captchaResponse = await CaptchaHttp.GetCaptchaResponse(captchaKey, captchaUrl);
            if (!captchaResponse.Success) return captchaResponse;
            var result = await manager.VerifyCaptcha(captchaResponse.Data);

            return new MethodResult() {Message = result.Message, Success = result.Success};
        }

        private static async Task<MethodResult> RetryAction(Func<string, string, IManager, Task<MethodResult>> action,
            string captchaKey, string captchaUrl, IManager manager, int tryCount)
        {
            var tries = 1;
            var methodResult = new MethodResult();

            while (tries < tryCount)
            {
                methodResult = await action(captchaKey, captchaUrl, manager);

                if (!methodResult.Success)
                    tries++;

                if (methodResult.Success) break;
                await Task.Delay(1000);
            }
            return methodResult;
        }
    }
}
