// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using osu.Game.Rulesets.Objects.Types;
using osu.Game.Rulesets.RP.Input;

namespace osu.Game.Rulesets.RP.Objects
{
    /// <summary>
    ///     可以往左邊�E是右邊長壓滑動
    /// </summary>
    public class RpContainerLineHoldObject : BaseRpHitableObject, IHasEndTime
    {
        //end time
        public double EndTime { get; set; }

        //Duration
        public double Duration => EndTime - StartTime;

        //ObjectType
        public override ObjectType ObjectType => ObjectType.ContainerHold;

        public RpContainerLineHoldObject(RpContainerLine parent, double startTime)
            : base(parent, startTime)
        {
        }

        //InitialDefaultValue
        public override bool CanHitBy(RpAction action)
        {
            //isMatch
            bool left = action == RpAction.Left_Press;
            bool right = action == RpAction.Right_Press;

            if (Coop == Coop.LeftOnly)
                return left;
            if (Coop == Coop.RightOnly)
                return right;

            return left && right;
        }

        public override List<RpAction> GetListCompareKeys()
        {
            List<RpAction> listKey = new List<RpAction>();

            if (Coop == Coop.Both || Coop == Coop.LeftOnly)
                listKey.Add(RpAction.Left_Press);
            if (Coop == Coop.Both || Coop == Coop.RightOnly)
                listKey.Add(RpAction.Right_Press);
            return listKey;
        }

        protected override void InitialDefaultValue()
        {
            base.InitialDefaultValue();
        }
    }
}
