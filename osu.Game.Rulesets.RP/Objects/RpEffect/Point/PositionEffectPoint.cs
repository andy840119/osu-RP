// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using OpenTK;

namespace osu.Game.Rulesets.RP.Objects.RpEffect.Point
{
    public class PositionEffectPoint : EffectPoint
    {
        public PositionEffectPoint()
        {
        }

        /// <summary>
        /// New Position
        /// </summary>
        /// <value>The new scale.</value>
        public Vector2 NewPotition { get; set; }
    }
}
