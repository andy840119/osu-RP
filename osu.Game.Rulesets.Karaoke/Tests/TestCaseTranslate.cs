
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using osu.Game.Tests.Visual;
using osu.Game.Graphics.Sprites;
using NUnit.Framework;
using osu.Framework.Graphics;
using System.Net;

namespace osu.Game.Rulesets.Karaoke.Tests
{
    /// <summary>
    /// test case for translate string to 
    /// </summary>
    public class TestCaseTranslate : OsuTestCase
    {
        public TestCaseTranslate()
        {
            //Run();

            Translate("en", "zh-TW", "Hello world!!");


        }

        
        public void Translate(string sourceLangCode, string targetLangCode, string message)
        {
            string url = "https://translation.googleapis.com/language/translate/";
            url += "v2?key=" + "AIzaSyB9tomdvp8WmySkEWIhjhVYO3rkhzKOPMc";
            url += "&source=" + sourceLangCode;
            url += "&target=" + targetLangCode;
            url += "&q=" + message;
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;
            string json = client.DownloadString(url);
            //JsonData jsonData = (new JavaScriptSerializer()).Deserialize<JsonData>(json);
            //txtTarget.Text = jsonData.Data.Translations[0].TranslatedText;

            Add(new OsuSpriteText
            {
                Text = json,
                //Font = @"Venera",
                UseFullGlyphHeight = false,
                Anchor = Anchor.TopLeft,
                Origin = Anchor.TopLeft,
                TextSize = 20,
                Alpha = 1,
                //ShadowColour = _textColor,
                Position = new OpenTK.Vector2(100, 100),
                //BorderColour = _textColor,
            });
        }
        

        /*
        private async void Run()
        {
            // Create the service.
            var service = new TranslateService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyB9tomdvp8WmySkEWIhjhVYO3rkhzKOPMc",
                ApplicationName = "Translate API Sample"
            });

            string[] srcText = new[] { "Hello world!" };
            var response = await service.Translations.List(srcText, "en").ExecuteAsync();
            var translations = new List<string>();

            response = service.Translations.List(translations, "tw").Execute();

            string totalTranslate = "";
            foreach (var translation in response.Translations)
            {
                totalTranslate = totalTranslate + translation.TranslatedText;
            }

            Add(new OsuSpriteText
            {
                Text = totalTranslate,
                //Font = @"Venera",
                UseFullGlyphHeight = false,
                Anchor = Anchor.TopLeft,
                Origin = Anchor.TopLeft,
                TextSize = 20,
                Alpha = 1,
                //ShadowColour = _textColor,
                Position = new OpenTK.Vector2(100, 100),
                //BorderColour = _textColor,
            });
        }
        */
    }
}
