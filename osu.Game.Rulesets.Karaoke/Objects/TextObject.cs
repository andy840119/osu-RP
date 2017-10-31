using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osu.Game.Rulesets.Objects.Types;
using OpenTK;

namespace osu.Game.Rulesets.Karaoke.Objects
{
    public class TextObject : IHasPosition
    {
        /// <summary>
        /// position
        /// </summary>
        public Vector2 Position { get; set; }

        /// <summary>
        /// X position
        /// </summary>
        public float X => Position.X;

        /// <summary>
        /// Y position
        /// </summary>
        public float Y => Position.Y;

        /// <summary>
        /// text
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// size of the font
        /// </summary>
        public int FontSize { get; set; } = 13;//default subText size is 13
    }
}
