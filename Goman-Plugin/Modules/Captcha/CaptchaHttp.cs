using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Goman_Plugin.Model;
using MethodResult = Goman_Plugin.Model.MethodResult;

namespace Goman_Plugin.Modules.Captcha
{
    public class CaptchaHttp
    {
        private const string RecaptchaSiteKey = "6LeeTScTAAAAADqvhqVMhPpr_vB9D364Ia-1dSgK";
        private const string CaptchaIn = "http://2captcha.com/in.php?";
        private const string CaptchaOut = "http://2captcha.com/res.php?";

        public static async Task<MethodResult<string>> GetCaptchaResponse(string captchaKey, string captchaUrl)
        {
            MethodResult<string> startSolveCaptchaTaskResults = await StartSolveCaptchaTask(captchaKey, captchaUrl);

            if (!startSolveCaptchaTaskResults.Success) return startSolveCaptchaTaskResults;

            return await GetSolvedCaptchaTask(captchaKey, startSolveCaptchaTaskResults.Data);

        }

        private static async Task<MethodResult<string>> StartSolveCaptchaTask(string captchaKey, string captchaUrl)
        {
            var methodResult = new MethodResult<string>();
            var postData =
                $"key={captchaKey}&method=userrecaptcha&googlekey={RecaptchaSiteKey}&proxy=0&proxytype=SOCKS4&pageurl={captchaUrl}";
            try
            {
                string result = await SendRecaptchav2RequestTask(CaptchaIn, postData);

                if (result.Contains("OK|"))
                {
                    methodResult.Data = result.Substring(3, result.Length - 3);
                    methodResult.Success = true;
                }
                else
                {
                    methodResult.Message = result;
                    methodResult.Success = false;
                }
            }
            catch (Exception ex)
            {
                methodResult.Message = ex + "\n\t" + ex.StackTrace;
                methodResult.Success = false;
            }

            return methodResult;
        }

        private static async Task<MethodResult<string>> GetSolvedCaptchaTask(string captchaKey, string captchaId)
        {
            var methodResult = new MethodResult<string>();
            var postData = $"key={captchaKey}&action=get&id={captchaId}";

            try
            {
                string result = await SendRecaptchav2RequestTask(CaptchaOut, postData);
                while (result.Contains("CAPCHA_NOT_READY"))
                {
                    await Task.Delay(750);
                    result = await SendRecaptchav2RequestTask(CaptchaOut, postData);
                }

                if (result.Contains("OK|"))
                {
                    methodResult.Data = result.Substring(3, result.Length - 3);
                    methodResult.Success = true;
                }
                else
                {
                    methodResult.Message = result;
                    methodResult.Success = false;
                }
            }
            catch (Exception ex)
            {
                methodResult.Message = ex + "\n\t" + ex.StackTrace;
                methodResult.Success = false;
            }

            return methodResult;
        }

        private static async Task<string> SendRecaptchav2RequestTask(string url, string post)
        {
            //POST

            return await Task.Run(() =>
            {
                ServicePointManager.Expect100Continue = false;
                var request = (HttpWebRequest)WebRequest.Create(url + post + "&soft_id = 1877");
                var data = Encoding.ASCII.GetBytes(post);

                request.Method = "POST";
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                    return responseString;
                }
            });
        }
    }
}
