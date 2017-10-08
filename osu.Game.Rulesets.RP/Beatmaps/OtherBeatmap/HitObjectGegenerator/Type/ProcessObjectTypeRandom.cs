// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator.Parameter;
using osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.Parameter;
using osu.Game.Rulesets.RP.Objects;

namespace osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator.Type
{
    internal class ProcessObjectTypeRandom
    {
        //單一一段皁E�E��E�件
        private ConvertParameter _singleSlideParameter;


        internal void SetConvertParameter(ConvertParameter singleSlideParameter)
        {
            _singleSlideParameter = singleSlideParameter;
        }


        internal void Process(SingleHitObjectConvertParameter singleTuple)
        {
            for (var i = 0; i < singleTuple.ListBaseHitObject.Count; i++)
            {
                (singleTuple.ListBaseHitObject[i] as RpHitObject).Direction = CalRandomShape(singleTuple, i);
            }
        }

        /// <summary>
        ///     計算隨機形狀
        /// </summary>
        /// <returns></returns>
        private Direction CalRandomShape(SingleHitObjectConvertParameter singleTuple, int index)
        {
            var randNum = CalRandNumber(singleTuple, index);
            switch (randNum % 4)
            {
                case 0:
                    return Direction.Up;
                case 1:
                    return Direction.Left;
                case 2:
                    return Direction.Down;
                case 3:
                    return Direction.Right;
            }
            return Direction.Down;
        }

        /// <summary>
        ///     產生隨機參數
        /// </summary>
        /// <returns></returns>
        private int CalRandNumber(SingleHitObjectConvertParameter singleTuple, int index)
        {
            var addNumber = 0;
            if (index == 1) //第二個物件
                addNumber = 2;
            if (index == 2) //第三個物件
                addNumber = 1;
            if (index == 2) //第四個物件
                addNumber = 3;

            return singleTuple.MultiNumber + (int)singleTuple.StartTime + singleTuple.ListBaseHitObject.Count + addNumber;

            //BPM�E�E�E�為亁E�E��E�免BPM 200 皁E�E��E�特別簡單
            var periodTime = (int)(60 / (double)(int)_singleSlideParameter.SliceConvertParameter.BPM) * 1000;
            //
            return singleTuple.MultiNumber + (int)singleTuple.StartTime % periodTime + singleTuple.ListBaseHitObject.Count;
        }

        /// <summary>
        ///     產生隨機參數
        ///     目前�E保存下侁E
        /// </summary>
        /// <returns></returns>
        private int OLD_CalRandNumber(SingleHitObjectConvertParameter singleTuple)
        {
            return singleTuple.MultiNumber + (int)singleTuple.StartTime + singleTuple.ListBaseHitObject.Count;
        }
    }
}
