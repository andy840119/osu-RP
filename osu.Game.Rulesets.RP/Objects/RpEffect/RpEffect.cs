// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System;
using System.Collections.Generic;
using System.Linq;
using osu.Game.Rulesets.RP.Objects.RpEffect.Point;

namespace osu.Game.Rulesets.RP.Objects.RpEffect
{
    /// <summary>
    /// define single effect point
    /// </summary>
    public class RpEffect
    {
        /// <summary>
        /// Effect ID
        /// </summary>
        public int ID;

        public bool Loop = false;

        //usually it can only set ,not recommand to read
        public List<EffectPoint> ListEffectPoint;

        //Get the filter effect
        public List<EffectPoint> GetFilterEffectPoint(Type[] IncompatibleMods)
        {
            List<EffectPoint> listFilterEffect = new List<EffectPoint>();

            //TODO filter list Type on the IncompatibleMods
            foreach (Type singleType in IncompatibleMods)
            {
                listFilterEffect.AddRange(ListEffectPoint.OfType<EffectPoint>());
            }
            return Sort(listFilterEffect);
        }

        //Get sorted effect
        List<EffectPoint> Sort(List<EffectPoint> unsortedEffect)
        {
            return unsortedEffect;
        }


        public ReRefrenecBy RefrenecBy;
    }

    public enum ReRefrenecBy
    {
        Beats,
        Time
    }
}
