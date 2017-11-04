using System;
namespace osu.Game.Rulesets.Karaoke.Objects
{
    /// <summary>
    /// to record the string ,and which language
    /// </summary>
    public class KaraokeTranslateString
    {
        public KaraokeTranslateString()
        {
            
        }

        /// <summary>
        /// TODO : get the language Code
        /// </summary>
        /// <value>The lang.</value>
        public string Lang { get; set; }

        /// <summary>
        /// translate of single sentence
        /// </summary>
        /// <value>The context.</value>
        public string Context { get; set; }
    }
}
