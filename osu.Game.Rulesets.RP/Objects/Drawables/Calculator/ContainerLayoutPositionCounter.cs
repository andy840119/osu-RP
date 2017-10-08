// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using OpenTK;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Calculator
{
    class ContainerLayoutPositionCounter
    {
        /// <summary>
        ///     寬度
        /// </summary>
        public float Width = 1000; //512;

        /// <summary>
        ///     倍率
        /// </summary>
        private readonly float MULTIPLE = 300;


        /// <summary>
        ///     指標位置(X軸)
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public float GetPosition(double time, double volocity)
        {
            var positionX = (float)time / 1000 * (float)volocity * MULTIPLE;
            positionX = positionX % Width;
            //inverse
            //position_x = -position_x + screenWidth + 10;
            return positionX;
        }

        /// <summary>
        ///     根據縮放比例和傾斜角度修改位置
        /// </summary>
        /// <returns></returns>
        public Vector2 GetfixedPosition(double time, float rotation, float scale)
        {
            return new Vector2();
        }
    }
}
