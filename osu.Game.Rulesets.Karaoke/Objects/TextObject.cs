// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

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
        public virtual int FontSize { get; set; } = 20; //default subText size is 30
    }
}
