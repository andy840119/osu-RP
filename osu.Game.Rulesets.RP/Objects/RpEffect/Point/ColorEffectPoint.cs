// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using OpenTK.Graphics;

namespace osu.Game.Rulesets.RP.Objects.RpEffect.Point
{
    /// <summary>
    /// Sparkle effect point.
    /// </summary>
    public class ColorEffectPoint : EffectPoint
    {
        public ColorEffectPoint()
        {
            //Set default effect ProcessTime is 200ms
            ProcessTime = 200;
        }

        /// <summary>
        /// New Scale
        /// </summary>
        /// <value>The new scale.</value>
        public Color4 Color { get; set; }
    }
}
