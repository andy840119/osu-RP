// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Game.Rulesets.RP.Objects.Drawables.Component.Extension;
using osu.Game.Rulesets.RP.Objects.Drawables.Component.Interface;
using osu.Game.Rulesets.RP.Objects.Drawables.Interface;
using osu.Game.Rulesets.RP.Objects.Interface;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.CommonDwawablePiece;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Component
{
    /// <summary>
    /// Background of container 
    /// </summary>
    public class ContainerGroupBackground : Container, IContainListTemplate, IHasColor, IComponentBase
    {
        /// <summary>
        ///     背景
        /// </summary>
        private RectanglePiece _rpRectangleComponent;

        public List<IHasTemplate> ListTemplate { get; set; }

        //更新顏色
        public Color4 Color { get; set; }

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="template"></param>
        public void Add(IHasTemplate template)
        {
            ListTemplate.Add(template);
            createDrawable();
        }

        /// <summary>
        /// Remove
        /// </summary>
        /// <param name="template"></param>
        public void Remove(IHasTemplate template)
        {
            ListTemplate.Remove(template);
            createDrawable();
        }

        public ContainerGroupBackground()
        {
            ListTemplate = new List<IHasTemplate>();
        }

        public void Initial()
        {
           
        }

        private void createDrawable()
        {
            _rpRectangleComponent = new RectanglePiece(2000, this.TotalHeight())
            {
                Scale = new Vector2(1, 0), //new OpenTK.Vector2(1, 0.13f * layerCount),
                Alpha = 0.5f,
                //Position = new Vector2(0, 0.13f / 2 * ListContainObject.Count),
                //Colour = Color,
            };

            Children = new Drawable[]
            {
                _rpRectangleComponent,
            };
        }

        public void FadeIn(double time = 0)
        {
            //RP FadeIn Animation
            _rpRectangleComponent.ScaleTo(new Vector2(1, 1), time, Easing.InOutElastic);
        }

        public void FadeOut(double time = 0)
        {
            //Animation
            _rpRectangleComponent.ScaleTo(new Vector2(1, 0), time * 3, Easing.OutElastic);
        }
    }
}
