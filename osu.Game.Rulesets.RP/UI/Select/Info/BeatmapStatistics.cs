// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System;
using System.Collections;
using System.Collections.Generic;
using osu.Game.Beatmaps;
using osu.Game.Graphics;
using System.Linq;
using osu.Game.Rulesets.RP.Objects;

namespace osu.Game.Rulesets.RP.UI.Select.Info
{
    /// <summary>
    ///     get some information of the beatmap
    /// </summary>
    internal class BeatmapStatistics : IEnumerable<BeatmapStatistic>
    {
        private WorkingBeatmap _beatmap;

        public BeatmapStatistics(WorkingBeatmap beatmap)
        {
            _beatmap = beatmap;
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public IEnumerator<BeatmapStatistic> GetEnumerator()
        {
            //RpHitObject
            yield return new BeatmapStatistic
            {
                Name = @"Hit",
                Content = _beatmap.Beatmap.HitObjects.Where(x=>x is RpHit).Count().ToString("N0"),
                Icon = FontAwesome.fa_dot_circle_o
            };

            //Hold
            yield return new BeatmapStatistic
            {
                Name = @"Hold",
                Content = _beatmap.Beatmap.HitObjects.Where(x => x is RpHold).Count().ToString("N0"),
                Icon = FontAwesome.fa_circle_o
            };

            //Hold
            yield return new BeatmapStatistic
            {
                Name = @"Press",
                Content = _beatmap.Beatmap.HitObjects.Where(x => x is RpRectangleHold).Count().ToString("N0"),
                Icon = FontAwesome.fa_circle_o
            };

            //Container
            yield return new BeatmapStatistic
            {
                Name = @"ContainerLine",
                Content = _beatmap.Beatmap.HitObjects.Where(x => x is RpContainerLine).Count().ToString("N0"),
                Icon = FontAwesome.fa_circle_o
            };
        }

        /// <summary>
        /// GetEnumerator
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
