// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

namespace osu.Game.Rulesets.Karaoke.Objects
{
    /// <summary>
    /// record what time the 
    /// </summary>
    public class ProgressPoint
    {
        public ProgressPoint()
        {
            
        }

        public ProgressPoint(double time,float charIndex)
        {
            RelativeTime = time;
            CharIndex = charIndex;
        }
        /// <summary>
        /// relative to word's strt time
        /// </summary>
        public double RelativeTime { get; set; }

        /// <summary>
        /// position at that time
        /// </summary>
        public float CharIndex { get; set; }
    }
}
