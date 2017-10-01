// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using osu.Framework.Graphics;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.Component;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.CommonDwawablePiece;
using OpenTK;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Template.RpContainer.Component
{
    /// <summary>
    ///     Container背景
    /// </summary>
    internal class ContainerBackground : ComponentBaseContainer, IChangeableContainerComponent ,IComponentBase
    {
        /// <summary>
        ///     背景
        /// </summary>
        private RectanglePiece _rpRectangleComponent;


        /// <summary>
        /// </summary>
        public ContainerBackground(RpContainerLineGroup hitObject)
            : base(hitObject)
        {
        }

        /// <summary>
        ///     開始特效
        /// </summary>
        public void FadeIn(double time = 0)
        {
            //RP FadeIn 動畫特效
            _rpRectangleComponent.ScaleTo(new Vector2(1, 1), time, Easing.InOutElastic);
        }

        /// <summary>
        ///     結束
        /// </summary>
        public void FadeOut(double time = 0)
        {
            //RP FadeIn 動畫特效
            _rpRectangleComponent.ScaleTo(new Vector2(1, 0), time * 3, Easing.OutElastic);
        }

        /// <summary>
        ///     修改物件高度
        /// </summary>
        /// <param name="newHeight"></param>
        public void ChangeHeight(float newHeight)
        {
            _rpRectangleComponent.Height = newHeight;
        }

        /// <summary>
        ///     初始化顯示
        /// </summary>
        protected override void InitialObject(int layerCount = 0)
        {
            _rpRectangleComponent = new RectanglePiece(2000, 60)
            {
                Scale = new Vector2(1, 0), //new OpenTK.Vector2(1, 0.13f * layerCount),
                Alpha = 0.5f,
                Position = new Vector2(0, 0.13f / 2 * layerCount),
                //Colour = HitObject.Colour
            };
        }

        protected override void InitialChild()
        {
            var listDrawable = new List<Drawable>();
            listDrawable.Add(_rpRectangleComponent);
            Children = listDrawable;
        }
    }
}
