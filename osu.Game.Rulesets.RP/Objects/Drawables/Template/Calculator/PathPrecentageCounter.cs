// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

namespace osu.Game.Rulesets.RP.Objects.Drawables.Template.Calculator
{
    /// <summary>
    ///     用來計算目前在曲線裡面的百分比
    /// </summary>
    public class PathPrecentageCounter
    {
        public double SpeedMultiple = 1.5f;
        private readonly BaseRpObject _baseHitObject;

        public PathPrecentageCounter(BaseRpObject baseHitObject)
        {
            _baseHitObject = baseHitObject;
        }

        /// <summary>
        ///     用來計算目前百分比
        ///     越接近目標(時間越大) 百分比越小
        ///     這邊是丟入到頂點所需要的剩餘時間
        /// </summary>
        /// <returns></returns>
        public double CalculatePrecentage(double remainToIndexPointerTime)
        {
            double precentage = 0;
            //TODO: implement 
            var totalLehgth = 512; // _baseHitObject.Curve.PathLength;
            precentage = _baseHitObject.Velocity * remainToIndexPointerTime / totalLehgth * SpeedMultiple;
            return precentage;
        }
    }
}
