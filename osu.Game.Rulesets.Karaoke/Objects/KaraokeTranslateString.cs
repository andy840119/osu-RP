// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

namespace osu.Game.Rulesets.Karaoke.Objects
{
    /// <summary>
    /// to record the string ,and which language
    /// </summary>
    public class KaraokeTranslateString : TextObject
    {
        public KaraokeTranslateString()
        {

        }

        /// <summary>
        /// Lang code
        /// </summary>
        public string LangCode { get; set; }

        /// <summary>
        /// TODO : get the language Code
        /// </summary>
        /// <value>The lang.</value>
        public string Lang { get; set; }

        /// <summary>
        /// user cannot override the fint size
        /// </summary>
        /// <value>The size of the font.</value>
        public override int FontSize => 30;
    }
}
