// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

namespace osu.Game.Rulesets.RP.Objects.Drawables.Template.Calculator
{
    /// <summary>
    ///     用來計算物件寬度，還有相對應該出現的位置等等
    /// </summary>
    internal class ContainerLayoutHeightCalculator
    {
        public int LayoutCount { get; set; }

        private const float LAYOUT_HEIGHT = 40;

        private const float LAYOUT_INTERVAL_HEIGHT = 45;

        private const float CONTAINER_TO_FIRST_LAYOUT_HEIGHT = 5;


        /// <summary>
        ///     ContainerGroup 寬度
        /// </summary>
        public float GetContainerHeight()
        {
            return LAYOUT_INTERVAL_HEIGHT * LayoutCount + CONTAINER_TO_FIRST_LAYOUT_HEIGHT * 2;
        }

        /// <summary>
        ///     Layout應該出現的位置
        /// </summary>
        public float GetLayoutPosition(int layoutIndex)
        {
            return LAYOUT_INTERVAL_HEIGHT * layoutIndex;
        }

        /// <summary>
        ///     取得
        /// </summary>
        /// <returns></returns>
        public float GetLayoutHeight()
        {
            return LAYOUT_HEIGHT;
        }
    }
}
