// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.Component;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.Interface;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.CommonDwawablePiece;
using OpenTK;
using System;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Template.RpHitObject.Component.Common
{
    /// <summary>
    ///     „âêªùfä¥
    /// </summary>
    internal class SliderBody : Container,IComponentBase, IComponentUpdateEachFrame
    {
        public float PathWidth
        {
            get { return slider.PathWidth; }
            set { slider.PathWidth = value; }
        }

        public BaseRpObject HitObject { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private readonly Slider slider;

        private readonly BaseRpHitableObject sliderHitObject;

        public SliderBody(BaseRpHitableObject s)
        {
            sliderHitObject = s;

            slider = new Slider();
            //èCê≥Ë˚é¶ç¿ïW
            //slider.Position = -path.PositionInBoundingBox(sliderHitObject.Curve.PositionAt(0) - sliderHitObject[0]);
            slider.Position = new Vector2(); //-sliderHitObject.Curve.PositionAt(0);
            Children = new Drawable[]
            {
                slider
            };
        }

        /// <summary>
        ///     únîáÁ≤ãéçXêVË˚é¶îÕö°
        /// </summary>
        /// <param name="progress">0~1</param>
        /// <param name="repeat">îáó°óaê›ê•0</param>
        public void UpdateProgress(double progress, double endProgress = 1)
        {
            var start = progress;
            var end = endProgress;
            var currentCurve = new List<Vector2>();
            if (start > end)
                MathHelper.Swap(ref start, ref end);
            //sliderHitObject.Curve.GetPathToProgress(currentCurve, start, end);

            slider.SetRange(currentCurve);
        }

        public void Initial()
        {
            
        }

        public void FadeIn(double time = 0)
        {
            
        }

        public void FadeOut(double time = 0)
        {
           
        }
    }
}
