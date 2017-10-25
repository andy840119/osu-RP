// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using osu.Game.Beatmaps;
using osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.Parameter;
using osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.Slicing.DiffStarCalculator;
using osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.Slicing.Parameter;
using osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.Slicing.TimeSliceCalculator;
using osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.Slicing.VolocityCalculator;

namespace osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.Slicing
{
    public class SliceProcessor
    {
        private readonly ContainerVolocityCalculator _containerVolocityCalculator = new ContainerVolocityCalculator();

        /// <summary>
        ///     Difficulty Calculator
        /// </summary>
        private readonly OriginalBeatmapDifficultyCalculator _originalBeatmapDifficultyCalculator = new OriginalBeatmapDifficultyCalculator();

        /// <summary>
        ///     回傳時間篁E��內皁Endex
        /// </summary>
        private readonly TimeSlicingCalculator _timeSlicingCalculator = new TimeSlicingCalculator();

        private double _diffStar;

        private Beatmap _originalBeatmap;

        /// <summary>
        ///     回傳刁E��結果
        /// </summary>
        /// <returns>The list comvert parameter.</returns>
        public List<ConvertParameter> GetListConvertParameter(Beatmap originalBeatmap)
        {
            var list = new List<ConvertParameter>();
            _originalBeatmap = originalBeatmap;
            //Get The Diff of beatmap;
            _diffStar = _originalBeatmapDifficultyCalculator.CalculateBeatmapDifficulty(_originalBeatmap);

            _timeSlicingCalculator.SetBeatmap(_originalBeatmap);

            var nowSlidingIndex = 0;

            //collect ComvertParameter and return list<ComvertParameter>
            while (nowSlidingIndex < originalBeatmap.HitObjects.Count)
            {
                _containerVolocityCalculator.UpdateCalculateVolocity();
                //set the slicing time
                _timeSlicingCalculator.SetSliceTime(_containerVolocityCalculator.GetTime());
                //calculate by BPM to devide by TimeSliceCalculator
                var endindex = _timeSlicingCalculator.SlicingFrom(nowSlidingIndex);
                //follow the tiem to slice the beatmap and get the startTime and endTime
                var volicity = _containerVolocityCalculator.GetVolocity();
                list.Add(SlicingSingle(nowSlidingIndex, endindex, volicity));
                nowSlidingIndex = endindex + 1;
            }

            return list;
        }

        /// <summary>
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public SliceConvertParameter GetSliceConvertParameterResult(ConvertParameter result, float volicity)
        {
            //decide the number of container and layout
            var sliceConvertParameter = new SliceConvertParameter();

            //startTime
            sliceConvertParameter.StartTime = result.ListRefrenceObject[0].StartTime;

            //EndTime
            var endIndex = result.ListRefrenceObject.Count - 1;
            double lastHitObjectDuration = 0;
            sliceConvertParameter.EndTime = result.ListRefrenceObject[endIndex].StartTime + lastHitObjectDuration;

            //TODO : get the BGM by startTime
            //BPM
            sliceConvertParameter.BPM = 60000 / _originalBeatmap.ControlPointInfo.TimingPointAt(sliceConvertParameter.StartTime).BeatLength;
            sliceConvertParameter.Volocity = volicity;

            return sliceConvertParameter;
        }

        /// <summary>
        ///     use startTime and Endtime to grab the object and return ComvertParameter
        ///     And calculate number of ContainerGroup and Layout
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        private ConvertParameter SlicingSingle(int startIndex, int endIndex, float volicity)
        {
            var single = new ConvertParameter();

            //Get Physical Refrence Object
            single.ListRefrenceObject = _originalBeatmap.HitObjects.GetRange(startIndex, endIndex - startIndex);

            //難度
            single.Difficulty = _diffStar;

            //Generate Parameter
            single.SliceConvertParameter = GetSliceConvertParameterResult(single, volicity);
            return single;
        }
    }
}
