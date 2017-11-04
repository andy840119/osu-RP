using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace osu.Game.Rulesets.Karaoke.Tools.Translator
{
    public class GoogleTranslator
    {
        /// <summary>
        /// Translate : 
        /// https://www.aspsnippets.com/Articles/Using-Google-Translation-Translate-API-in-ASPNet-using-C-and-VBNet.aspx
        /// converto to unicode : 
        /// https://msdn.microsoft.com/zh-tw/library/kdcak6ye(v=vs.110).aspx
        /// </summary>
        /// <param name="sourceLangCode"></param>
        /// <param name="targetLangCode"></param>
        /// <param name="message"></param>
        public void Translate(string sourceLangCode,string targetLangCode,string message)
        {

            string url = "https://translation.googleapis.com/language/translate/v2?key=YOUR_API_KEY";
            url += "&source=" + sourceLangCode;
            url += "&target=" + targetLangCode;
            url += "&q=" + message;
            WebClient client = new WebClient();
            string json = client.DownloadString(url);
            //JsonData jsonData = (new JavaScriptSerializer()).Deserialize<JsonData>(json);
            //txtTarget.Text = jsonData.Data.Translations[0].TranslatedText;
        }
    }
}
