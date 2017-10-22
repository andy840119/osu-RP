// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Game.Rulesets.RP.Objects;
using osu.Game.Rulesets.RP.SkinManager;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.CommonDwawablePiece
{
    /// <summary>
    ///     RP指針
    /// </summary>
    public class Pointer : Container
    {
        public const float TIME_FADEIN = 100;
        public const float TIME_PREEMPT = 2000;
        public const float TIME_FADEOUT = 100;

        private readonly BaseRpObject baseRpObject;


        private readonly Sprite approachCircle;

        public Pointer(BaseRpObject baseRpObject)
        {
            this.baseRpObject = baseRpObject;

            //TIME_FADEIN = _baseRPObject.FadeInTime;
            //TIME_PREEMPT = _baseRPObject.PreemptTime;
            //TIME_FADEOUT = _baseRPObject.FadeOutTime;

            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;

            AutoSizeAxes = Axes.Both;

            Children = new Drawable[]
            {
                approachCircle = new Sprite()
            };
        }

        /// <summary>
        ///     初始化顯示
        /// </summary>
        public void Initial()
        {
            Alpha = 1;
            //this.Scale = new Vector2(1);
        }

        /// <summary>
        ///     開始特效
        /// </summary>
        public void StartEffect()
        {
            this.FadeIn(Math.Min(TIME_FADEIN * 2, TIME_PREEMPT));
            //轉一圈
            this.RotateTo(360.0f, TIME_PREEMPT);
        }

        /// <summary>
        ///     結束
        /// </summary>
        public void FadeOut()
        {
            //base.FadeOut();
        }

        /// <summary>
        ///     載入物件
        /// </summary>
        /// <param name="textures"></param>
        [BackgroundDependencyLoader]
        private void load(TextureStore textures)
        {
            var textureName = RpTexturePathManager.RPPointer;
            approachCircle.Texture = textures.Get(textureName);
        }
    }
}
