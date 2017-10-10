// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System;
using System.Collections.Generic;
using osu.Game.Beatmaps;
using osu.Game.Rulesets.Objects;
using osu.Game.Rulesets.Objects.Types;
using osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.ContainerGegenerator;
using osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator;
using osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.PostConvert;
using osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.Slicing;
using osu.Game.Rulesets.RP.Objects;

namespace osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap
{
    /// <summary>
    ///     can convert any beatmap from any other beatmap
    /// </summary>
    public class BeatmapConvertor : BeatmapConverter<BaseRpObject>
    {
        //
        private readonly SliceProcessor sliceProcessor = new SliceProcessor();

        //
        private readonly ContainerProcessor containerProcessor = new ContainerProcessor();

        //
        private readonly HitObjectProcessor hitObjectProcessor = new HitObjectProcessor();

        //
        private readonly PostConvertor postConvertor = new PostConvertor();


        protected override IEnumerable<Type> ValidConversionTypes { get; } = new[] { typeof(IHasPosition) };

        /// <summary>
        /// this method does not in use
        /// </summary>
        /// <param name="original"></param>
        /// <param name="beatmap"></param>
        /// <returns></returns>
        protected override IEnumerable<BaseRpObject> ConvertHitObject(HitObject original, Beatmap beatmap)
        {
            IHasCurve curveData = original as IHasCurve;
            IHasEndTime endTimeData = original as IHasEndTime;
            IHasPosition positionData = original as IHasPosition;
            IHasCombo comboData = original as IHasCombo;

            /*
            if (curveData != null)
            {
                yield return new RpSlider
                {
                    StartTime = original.StartTime,
                    Samples = original.Samples,
                    CurveObject = curveData,
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

                    Position = positionData?.Position ?? OsuPlayfield.BASE_SIZE / 2,
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
           */

            yield return (BaseRpObject)original;
        }

        /// <summary>
        /// Performs the conversion of a Beatmap using this Beatmap Converter.
        /// </summary>
        /// <param name="original">The un-converted Beatmap.</param>
        /// <returns>The converted Beatmap.</returns>
        protected override Beatmap<BaseRpObject> ConvertBeatmap(Beatmap original)
        {
            
            //TODO : ・ｽﾒ考Mania・ｽ・ｽ・ｽ・ｽ・ｽ・ｽ・ｽ
            var newBratmaps= new Beatmap<BaseRpObject>()
            {
                BeatmapInfo = original.BeatmapInfo,
                ControlPointInfo = original.ControlPointInfo,
                HitObjects = convertHitObjects(original, original.BeatmapInfo?.StackLeniency ?? 0.7f),

            };
            //newBratmaps.HitObjects.BindingAll();
            return newBratmaps;
        }


        /// <summary>
        ///     ????????????E???E?E?E???OsuHitObject
        ///     ????????????ERPHitObject
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private List<BaseRpObject> convertHitObjects(Beatmap originalBeatmap, float stackLeniency)
        {
            //??????listObject???E?E?E???E
            var listComvertParameter = sliceProcessor.GetListConvertParameter(originalBeatmap);
            //??????E?E?EContainer
            listComvertParameter = containerProcessor.Convert(listComvertParameter);
            //??????E?E?EHitObjects
            listComvertParameter = hitObjectProcessor.Convert(listComvertParameter);
            //???????????????E?E??E????
            return postConvertor.Convert(listComvertParameter);
        }
    }
}
