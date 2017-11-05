// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System;
using System.Collections.Generic;
using osu.Game.Beatmaps;
using osu.Game.Rulesets.Karaoke.Objects;
using osu.Game.Rulesets.Karaoke.Osu_Objects;
using osu.Game.Rulesets.Karaoke.UI;
using osu.Game.Rulesets.Objects;
using osu.Game.Rulesets.Objects.Types;
using OpenTK;

namespace osu.Game.Rulesets.Karaoke.Beatmaps
{
    internal class KaraokeBeatmapConverter : BeatmapConverter<KaraokeObject>
    {
        protected override IEnumerable<Type> ValidConversionTypes { get; } = new[] { typeof(IHasPosition) };

        protected override IEnumerable<KaraokeObject> ConvertHitObject(HitObject original, Beatmap beatmap)
        {
            var curveData = original as IHasCurve;
            var endTimeData = original as IHasEndTime;
            var positionData = original as IHasPosition;
            var comboData = original as IHasCombo;

            if (curveData != null)
            {
                yield return new Slider
                {
                    StartTime = original.StartTime,
                    Samples = original.Samples,
                    ControlPoints = curveData.ControlPoints,
                    CurveType = curveData.CurveType,
                    Distance = curveData.Distance,
                    RepeatSamples = curveData.RepeatSamples,
                    RepeatCount = curveData.RepeatCount,
                    Position = positionData?.Position ?? Vector2.Zero,
                    NewCombo = comboData?.NewCombo ?? false
                };
            }
            else if (endTimeData != null)
            {
                yield return new Spinner
                {
                    StartTime = original.StartTime,
                    Samples = original.Samples,
                    EndTime = endTimeData.EndTime,

                    Position = positionData?.Position ?? KaraokePlayfield.BASE_SIZE / 2,
                };
            }
            else
            {
                yield return new HitCircle
                {
                    StartTime = original.StartTime,
                    Samples = original.Samples,
                    Position = positionData?.Position ?? Vector2.Zero,
                    NewCombo = comboData?.NewCombo ?? false
                };
            }
        }
    }
}
