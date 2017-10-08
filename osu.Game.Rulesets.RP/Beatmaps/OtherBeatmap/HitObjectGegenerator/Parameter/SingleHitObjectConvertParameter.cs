// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using osu.Game.Rulesets.RP.Objects;

namespace osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator.Parameter
{
    public class SingleHitObjectConvertParameter
    {
        /// <summary>
        ///     this object is in combo or not
        /// </summary>
        public bool IsCombo = false;

        public double StartTime;

        public double EndTime;

        public int MultiNumber = 1;

        /// <summary>
        ///     all of the the hitObject in this moment
        /// </summary>
        public List<BaseRpHitableObject> ListBaseHitObject = new List<BaseRpHitableObject>();
    }
}
