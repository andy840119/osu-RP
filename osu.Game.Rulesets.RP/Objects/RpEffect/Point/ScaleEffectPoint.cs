// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using OpenTK;

namespace osu.Game.Rulesets.RP.Objects.RpEffect.Point
{
    /// <summary>
    /// define single Scale effect point.
    /// </summary>
    public class ScaleEffectPoint : EffectPoint
    {
        public ScaleEffectPoint()
        {
            //Set default effect ProcessTime is 200ms
            ProcessTime = 200;
        }

        /// <summary>
        /// New Scale
        /// </summary>
        /// <value>The new scale.</value>
        public Vector2 NewScale { get; set; }
    }
}
