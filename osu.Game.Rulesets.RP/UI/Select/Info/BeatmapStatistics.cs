// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System;
using System.Collections;
using System.Collections.Generic;
using osu.Game.Beatmaps;
using osu.Game.Graphics;

namespace osu.Game.Rulesets.RP.UI.Select.Info
{
    /// <summary>
    ///     get some information of the beatmap
    /// </summary>
    internal class BeatmapStatistics : IEnumerable<BeatmapStatistic>
    {
        private Beatmap _beatmap;

        public BeatmapStatistics(WorkingBeatmap beatmap)
        {
            _beatmap = beatmap.Beatmap;
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
                Content = "10000", //beatmap.Beatmap.HitObjects.Count(h => h is HitCircle).ToString(),
                Icon = FontAwesome.fa_dot_circle_o
            };

            //RpSlider
            yield return new BeatmapStatistic
            {
                Name = @"Slider",
                Content = "10000", //beatmap.Beatmap.HitObjects.Count(h => h is Slider).ToString(),
                Icon = FontAwesome.fa_circle_o
            };

            //RpPress
            yield return new BeatmapStatistic
            {
                Name = @"Press",
                Content = "10000", //beatmap.Beatmap.HitObjects.Count(h => h is Slider).ToString(),
                Icon = FontAwesome.fa_circle_o
            };

            //RpContainer
            yield return new BeatmapStatistic
            {
                Name = @"ContainerGroup",
                Content = "10000", //beatmap.Beatmap.HitObjects.Count(h => h is Slider).ToString(),
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
