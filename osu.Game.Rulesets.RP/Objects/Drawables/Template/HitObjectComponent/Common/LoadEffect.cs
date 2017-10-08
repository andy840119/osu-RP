// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.Component;
using osu.Game.Rulesets.RP.SkinManager;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.CommonDwawablePiece;
using OpenTK;
using System;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Template.RpHitObject.Component.Common
{
    /// <summary>
    ///     載入效果
    /// </summary>
    public class LoadEffect : Container,IComponentBase
    {
        /// <summary>
        ///     外框
        /// </summary>
        private readonly ImagePicec _effectPicec;

        public BaseRpObject HitObject { get; set; }


        /// <summary>
        ///     建構
        /// </summary>
        public LoadEffect(BaseRpObject h)
        {
            HitObject = h;

            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;

            Children = new Drawable[]
            {
                _effectPicec = new ImagePicec(RpTexturePathManager.GetRPLoadEffect())
                {
                    Scale = new Vector2(1, 1),
                    Alpha = 0
                }
            };
        }

        /// <summary>
        ///     初始化顯示
        /// </summary>
        public void Initial()
        {

        }

        /// <summary>
        ///     開始特效
        /// </summary>
        public void FadeIn(double time = 0)
        {
            _effectPicec.FadeTo(0.9f, 0);
            _effectPicec.ScaleTo(2.5f,  100);
            _effectPicec.FadeTo(0.7f,  150);
            _effectPicec.FadeTo(0,  200);
        }

        /// <summary>
        ///     結束
        /// </summary>
        public void FadeOut(double time = 0)
        {
        }
    }
}
