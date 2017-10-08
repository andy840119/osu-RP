// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Framework.Graphics;

namespace osu.Game.Rulesets.RP.Objects.RpEffect.Point
{
    /// <summary>
    /// single point of RpEffect
    /// </summary>
    public abstract class EffectPoint
    {
        /// <summary>
        /// Time
        /// </summary>
        public double Time { get; set; }


        /// <summary>
        /// EastingType
        /// </summary>
        /// <value>The easing types.</value>
        public Easing EasingTypes { get; set; }

        /// <summary>
        /// Gets or sets the process time.
        /// </summary>
        /// <value>The process time.</value>
        public double ProcessTime { get; set; }
    }
}
