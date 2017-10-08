// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

namespace osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.Slicing.Parameter
{
    /// <summary>
    ///     Slice convert parameter.
    /// </summary>
    public class SliceConvertParameter
    {
        /// <summary>
        ///     the time container shoule start
        /// </summary>
        public double StartTime;

        /// <summary>
        ///     the time container should stop
        /// </summary>
        public double EndTime;

        /// <summary>
        /// </summary>
        public float Volocity;

        /// <summary>
        ///     BPM
        /// </summary>
        internal double BPM = 180;
    }
}
