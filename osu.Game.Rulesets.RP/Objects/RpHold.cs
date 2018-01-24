// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Game.Rulesets.RP.Objects.Interface;
using IHasEndTime = osu.Game.Rulesets.Objects.Types.IHasEndTime;

namespace osu.Game.Rulesets.RP.Objects
{
    /// <summary>
    ///     RPí∑ï®åè
    /// </summary>
    public class RpHold : RpHit, IHasEndTime, IHasHoldToEarnExtraPoint
    {
        //end time
        public double EndTime { get; set; }

        //Duration
        public double Duration => EndTime - StartTime;

        //ObjectType
        public override ObjectType ObjectType => ObjectType.Hold;

        //Hold to add extra point
        public bool IsHold { get; set; }

        //Hold to add extra point
        public int ExtraPointParBeat { get; set; }

        //Constructor
        public RpHold(RpContainerLine parent, double startTime)
            : base(parent, startTime)
        {
        }

        //InitialDefaultValue
        protected override void InitialDefaultValue()
        {
            base.InitialDefaultValue();
        }
    }
}
