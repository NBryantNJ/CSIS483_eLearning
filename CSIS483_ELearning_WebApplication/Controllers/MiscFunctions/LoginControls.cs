using Nancy;
using Nancy.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace CSIS483_ELearning_WebApplication.Controllers.MiscFunctions
{
    public class LoginControls
    {
        //Check If Google ReCaptcha Was Done
        public bool checkRecaptcha(string reCaptcha)
        {
            try
            {
                var client = new System.Net.WebClient();
                string secretKey = "6LdQ_t8ZAAAAALvriy9dZoXXu1Ii-ag0UVOSLEw4";
                var GoogleReply = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, reCaptcha));

                var JObject = JsonConvert.DeserializeObject<dynamic>(GoogleReply);
                bool wasCaptchaSuccessful = false; 

                foreach (bool item in JObject)
                {
                    wasCaptchaSuccessful = item;
                    break;
                }
                if (wasCaptchaSuccessful == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
