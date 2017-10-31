using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osu.Game.Rulesets.Karaoke.Objects
{
    /// <summary>
    /// record what time the 
    /// </summary>
    public class ProgressPoint
    {
        /// <summary>
        /// relative to word's strt time
        /// </summary>
        public double RelativeTime { get; set; }

        /// <summary>
        /// position at that time
        /// </summary>
        public float X { get; set; }
    }
}
