// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using osu.Game.Rulesets.RP.Objects;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Externsion
{
    public static class HitObjectRelationBindingExtension
    {
        public static int MaxIdOfObject()
        {
            return 0;
        }

        /// <summary>
        /// resign the new id of each object,sort by time and priprity
        /// </summary>
        public static void ReSignId()
        {
        }

        public static void BindingAll(this List<BaseRpObject> ilstObjects)
        {
            foreach (var single in ilstObjects)
            {
                BindingSingle(ilstObjects, single);
            }
        }

        public static void BindingSingle(this List<BaseRpObject> ilstObjects, BaseRpObject single)
        {
            if (single is RpContainerLine rpContainerLine)
            {
                BindingRpContainerLine(ilstObjects, single);
            }
            //TODO ...
        }

        public static void BindingRpContainerLine(this List<BaseRpObject> ilstObjects, BaseRpObject single)
        {
        }
    }
}
