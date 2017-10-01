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
