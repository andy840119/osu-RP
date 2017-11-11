// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using NUnit.Framework;

namespace osu.Game.Rulesets.Karaoke.Tools.Translator
{
    public class GoogleTranslator : TranslateorBase
    {
        protected override Dictionary<TranslateCode, string> LangToCodeDictionary
        {
            get
            {
                Dictionary<TranslateCode, string> returnDic= new Dictionary<TranslateCode, string>()
                {
                    {TranslateCode.Default, ""},
                    {TranslateCode.Afrikaans, "af"},
                    {TranslateCode.Albanian, "sq"},
                    {TranslateCode.Amharic, "am"},
                    {TranslateCode.Arabic, "ar"},
                    {TranslateCode.Armenian, "hy"},
                    {TranslateCode.Azeerbaijani, "az"},
                    {TranslateCode.Basque, "eu"},
                    {TranslateCode.Belarusian, "be"},
                    {TranslateCode.Bengali, "bn"},
                    {TranslateCode.Bosnian, "bs"},
                    {TranslateCode.Catalan, "ca"},
                    {TranslateCode.Cebuano, "ceb"},
                    {TranslateCode.Chinese_Simplified, "zh-CN"},
                    {TranslateCode.Chinese_Traditional, "zh-TW"},
                    {TranslateCode.Corsican, "co"},
                    {TranslateCode.Croatian, "hr"},
                    {TranslateCode.Czech, "cs"},
                    {TranslateCode.Danish, "da"},
                    {TranslateCode.Dutch, "nl"},
                    {TranslateCode.English, "en"},
                    {TranslateCode.Esperanto, "eo"},
                    {TranslateCode.Estonian, "et"},
                    {TranslateCode.Finnish, "fi"},
                    {TranslateCode.French, "fr"},
                    {TranslateCode.Frisian, "fy"},
                    {TranslateCode.Galician, "gl"},
                    {TranslateCode.Georgian, "ka"},
                    {TranslateCode.German, "de"},
                    {TranslateCode.Greek, "el"},
                    {TranslateCode.Gujarati, "gu"},
                    {TranslateCode.Haitian, "Creole"},
                    {TranslateCode.Hausa, "ha"},
                    {TranslateCode.Hawaiian, "haw"},
                    {TranslateCode.Hebrew, "iw"},
                    {TranslateCode.Hindi, "hi"},
                    {TranslateCode.Hmong, "hmn"},
                    {TranslateCode.Hungarian, "hu"},
                    {TranslateCode.Icelandic, "is"},
                    {TranslateCode.Igbo, "ig"},
                    {TranslateCode.Indonesian, "id"},
                    {TranslateCode.Irish, "ga"},
                    {TranslateCode.Italian, "it"},
                    {TranslateCode.Japanese, "ja"},
                    {TranslateCode.Javanese, "jw"},
                    {TranslateCode.Kannada, "kn"},
                    {TranslateCode.Kazakh, "kk"},
                    {TranslateCode.Khmer, "km"},
                    {TranslateCode.Korean, "ko"},
                    {TranslateCode.Kurdish, "ku"},
                    {TranslateCode.Kyrgyz, "ky"},
                    {TranslateCode.Lao, "lo"},
                    {TranslateCode.Latin, "la"},
                    {TranslateCode.Latvian, "lv"},
                    {TranslateCode.Lithuanian, "lt"},
                    {TranslateCode.Luxembourgish, "lb"},
                    {TranslateCode.Macedonian, "mk"},
                    {TranslateCode.Malagasy, "mg"},
                    {TranslateCode.Malay, "ms"},
                    {TranslateCode.Malayalam, "ml"},
                    {TranslateCode.Maltese, "mt"},
                    {TranslateCode.Maori, "mi"},
                    {TranslateCode.Marathi, "mr"},
                    {TranslateCode.Mongolian, "mn"},
                    {TranslateCode.Myanmar ,"my"},
                    {TranslateCode.Nepali, "ne"},
                    {TranslateCode.Norwegian, "no"},
                    {TranslateCode.Nyanja , "ny"},
                    {TranslateCode.Pashto, "ps"},
                    {TranslateCode.Persian, "fa"},
                    {TranslateCode.Polish, "pl"},
                    {TranslateCode.Portuguese , "pt"},
                    {TranslateCode.Punjabi, "pa"},
                    {TranslateCode.Romanian, "ro"},
                    {TranslateCode.Russian, "ru"},
                    {TranslateCode.Samoan, "sm"},
                    {TranslateCode.Scots , "gd"},
                    {TranslateCode.Serbian, "sr"},
                    {TranslateCode.Sesotho, "st"},
                    {TranslateCode.Shona, "sn"},
                    {TranslateCode.Sindhi, "sd"},
                    {TranslateCode.Sinhala , "si"},
                    {TranslateCode.Slovak, "sk"},
                    {TranslateCode.Slovenian, "sl"},
                    {TranslateCode.Somali, "so"},
                    {TranslateCode.Spanish, "es"},
                    {TranslateCode.Sundanese, "su"},
                    {TranslateCode.Swahili, "sw"},
                    {TranslateCode.Swedish, "sv"},
                    {TranslateCode.Tagalog , "tl"},
                    {TranslateCode.Tajik, "tg"},
                    {TranslateCode.Tamil, "ta"},
                    {TranslateCode.Telugu, "te"},
                    {TranslateCode.Thai, "th"},
                    {TranslateCode.Turkish, "tr"},
                    {TranslateCode.Ukrainian, "uk"},
                    {TranslateCode.Urdu, "ur"},
                    {TranslateCode.Uzbek, "uz"},
                    {TranslateCode.Vietnamese, "vi"},
                    {TranslateCode.Welsh, "cy"},
                    {TranslateCode.Xhosa, "xh"},
                    {TranslateCode.Yiddish, "yi"},
                    {TranslateCode.Yoruba, "yo"},
                    {TranslateCode.Zulu, "zu"},
                };

                return returnDic;
            }

        }

        /// <summary>
        /// Translate : 
        /// https://www.aspsnippets.com/Articles/Using-Google-Translation-Translate-API-in-ASPNet-using-C-and-VBNet.aspx
        /// converto to unicode : 
        /// https://msdn.microsoft.com/zh-tw/library/kdcak6ye(v=vs.110).aspx
        /// </summary>
        /// <param name="sourceLangeCode"></param>
        /// <param name="targetLangCode"></param>
        /// <param name="translateString"></param>
        public override void Translate(TranslateCode sourceLangeCode, TranslateCode targetLangCode, string translateString)
        {
            try
            {
                //TODO : add try catch

                string url = "https://translation.googleapis.com/language/translate/";
                url += "v2?key=" + "AIzaSyB9tomdvp8WmySkEWIhjhVYO3rkhzKOPMc";
                url += "&source=" + LangToCodeDictionary[sourceLangeCode];
                url += "&target=" + LangToCodeDictionary[targetLangCode];
                url += "&q=" + translateString;
                WebClient client = new WebClient();
                client.Encoding = System.Text.Encoding.UTF8;
                string json = client.DownloadString(url);
                RootObject rootObject = JsonConvert.DeserializeObject<RootObject>(json);
                string returnTranslateResult = rootObject?.data?.translations?.FirstOrDefault().translatedText;
                OnTranslateSuccess?.Invoke(this, returnTranslateResult);
            }
            catch (Exception e)
            {
                OnTranslateFail?.Invoke(this, e.Message);
            }
        }

        public override void Translate(TranslateCode sourceLangeCode, TranslateCode targetLangCode, List<string> translateString)
        {
            //throw new NotImplementedException();
        }


        [Ignore("getting CI working")]
        public class RootObject
        {
            public Data data { get; set; }

            public class Data
            {
                public List<Translation> translations { get; set; }

                public class Translation
                {
                    public string translatedText { get; set; }
                }
            }
        }
    }
}
