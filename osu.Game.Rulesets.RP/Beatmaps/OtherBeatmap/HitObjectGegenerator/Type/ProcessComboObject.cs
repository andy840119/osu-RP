// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator.Parameter;
using osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.Parameter;
using osu.Game.Rulesets.RP.Objects;

namespace osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator.Type
{
    /// <summary>
    ///     處理combo時的狀慁E
    /// </summary>
    internal class ProcessComboObject
    {
        public bool FisrtConbo;
        private ConvertParameter _singleSlideParameter;

        private bool convert;

        //上一個群絁E��物件
        private SingleHitObjectConvertParameter _lastHitObjectTuple;

        internal void Process(SingleHitObjectConvertParameter singleTuple, int nowIndex)
        {
            //上一個群絁E��物件
            _lastHitObjectTuple = _singleSlideParameter.HitObjectConvertParameter.ListSingleHitObjectConvertParameter[nowIndex - 1];

            if (FisrtConbo)
            {
                OptimizeBetterHitExperiance();
                FisrtConbo = false;
            }

            if (convert)
            {
                for (var i = 0; i < singleTuple.ListBaseHitObject.Count; i++)
                    if (_lastHitObjectTuple.ListBaseHitObject.Count > i)
                    {
                        (singleTuple.ListBaseHitObject[i] as RpHitObject).Direction = FindNext((_lastHitObjectTuple.ListBaseHitObject[i] as RpHitObject).Direction);
                    }
                convert = false;
            }
            else
            {
                for (var i = 0; i < singleTuple.ListBaseHitObject.Count; i++)
                    if (_lastHitObjectTuple.ListBaseHitObject.Count > i)
                    {
                        (singleTuple.ListBaseHitObject[i] as RpHitObject).Direction = FindPrevious((_lastHitObjectTuple.ListBaseHitObject[i] as RpHitObject).Direction);
                    }
                convert = true;
            }
        }

        internal void SetConvertParameter(ConvertParameter singleSlideParameter)
        {
            _singleSlideParameter = singleSlideParameter;
        }

        /// <summary>
        ///     if first combo Object comes to up down left right
        ///     it will assign the priority that is better to hit
        /// </summary>
        protected void OptimizeBetterHitExperiance()
        {
            RpHitObject hitObject = _lastHitObjectTuple.ListBaseHitObject[0] as RpHitObject;

            if (hitObject != null)
            {
                switch (hitObject.Direction)
                {
                    case Direction.Up:
                        convert = false;
                        break;
                    case Direction.Down:
                        convert = true;
                        break;
                    case Direction.Left: //因為左邊真皁E��夠難打，乾脁E��要讓宁E�E現好亁E
                        //_lastHitObjectTuple.ListBaseHitObject[0].Shape = Shape.Right;
                        convert = false;
                        break;
                    case Direction.Right:
                        convert = true;
                        break;
                }
            }
        }

        /// <summary>
        ///     Up>>Left>>Down>>Right
        /// </summary>
        /// <param name="nowShape"></param>
        /// <returns></returns>
        protected Direction FindNext(Direction nowShape)
        {
            switch (nowShape)
            {
                case Direction.Up:
                    return Direction.Left;
                case Direction.Left:
                    return Direction.Down;
                case Direction.Down:
                    return Direction.Right;
                case Direction.Right:
                    return Direction.Up;
            }
            return Direction.Down;
        }

        protected Direction FindPrevious(Direction nowShape)
        {
            switch (nowShape)
            {
                case Direction.Up:
                    return Direction.Right;
                case Direction.Left:
                    return Direction.Up;
                case Direction.Down:
                    return Direction.Left;
                case Direction.Right:
                    return Direction.Down;
            }
            return Direction.Down;
        }
    }
}
