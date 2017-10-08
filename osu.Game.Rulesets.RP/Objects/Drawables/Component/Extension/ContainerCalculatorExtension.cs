// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Game.Rulesets.RP.Objects.Drawables.Component.Interface;
using osu.Game.Rulesets.RP.Objects.Interface;
using OpenTK;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Component.Extension
{
    /// <summary>
    /// calculate all the position and Hight of the Container
    /// </summary>
    public static class ContainerCalculatorExtension
    {
        private static float LAYOUT_HEIGHT = 40;

        private static float LAYOUT_INTERVAL_HEIGHT = 10;

        private static float CONTAINER_TO_FIRST_LAYOUT_HEIGHT = 5;

        private static float MULTIPLE = 0.2f;

        /// <summary>
        /// Height of single Layer
        /// </summary>
        /// <param name="componentSingleLayer"></param>
        /// <returns></returns>
        public static float SingleLayerHeight(this IHasLayerIndex componentSingleLayer)
        {
            return LAYOUT_HEIGHT;
        }

        public static float TotalHeight(this IContainListTemplate containListTemplate)
        {
            int layerCount = containListTemplate.ListTemplate.Count;
            if (layerCount > 0)
                return CONTAINER_TO_FIRST_LAYOUT_HEIGHT * 2 + LAYOUT_HEIGHT * layerCount + LAYOUT_INTERVAL_HEIGHT * layerCount - 1;

            return CONTAINER_TO_FIRST_LAYOUT_HEIGHT * 2 + 20;
        }

        /// <summary>
        /// position of layer
        /// </summary>
        /// <returns></returns>
        public static Vector2 PositionOfLayer(this IHasLayerIndex componentSingleLayer)
        {
            //TODO : 
            return new Vector2(0, 0);
        }

        public static float XPositionOfTime(this IHasVelocity velocity, double time)
        {
            float positionX = (float)time / 1000 * velocity.Velocity * MULTIPLE;
            //positionX = positionX % Width;
            //inverse
            //position_x = -position_x + screenWidth + 10;
            //return positionX;
            return positionX;
        }

        public static Vector2 PositionOfTime(this IHasVelocity velocity, double time)
        {
            return new Vector2(XPositionOfTime(velocity, time), 0);
        }
    }
}
