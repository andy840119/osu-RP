// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

namespace osu.Game.Rulesets.RP.Objects.Interface
{
    public interface IHasEndTime //: osu.Game.Rulesets.Objects.Types.IHasEndTime
    {
        /// <summary>
        /// The time at which the HitObject ends.
        /// </summary>
        double EndTime { get; set; }

        /// <summary>
        /// The duration of the HitObject.
        /// </summary>
        double Duration { get; set; }
    }
}
