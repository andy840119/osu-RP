// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Game.Rulesets.RP.Objects.Interface;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Component.Extension
{
    public static class TimeExtension
    {
        /// <summary>
        ///     取得間隔時間
        /// </summary>
        /// <returns></returns>
        public static double GetDeltaBeatTime(this IHasBPM bmp)
        {
            return 1000 * 60 / bmp.BPM;
        }
    }
}
