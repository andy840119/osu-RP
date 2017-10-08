// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System;
using osu.Game.Beatmaps;
using osu.Game.Rulesets.RP.Objects;

namespace osu.Game.Rulesets.RP.Beatmaps.RPBeatmap
{
    /// <summary>
    ///     RP譜面轉成物件
    /// </summary>
    internal class RpBeatmapProcessor : BeatmapProcessor<BaseRpObject>
    {
        public override void PostProcess(Beatmap<BaseRpObject> beatmap)
        {
            if (beatmap.HitObjects.Count == 0)
                throw new ArgumentNullException();
        }
    }
}
