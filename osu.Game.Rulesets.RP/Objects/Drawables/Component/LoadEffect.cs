﻿// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Game.Rulesets.RP.Objects.Drawables.Component.Interface;
using osu.Game.Rulesets.RP.SkinManager;
using osu.Game.Rulesets.RP.UI.Piece;
using OpenTK;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Component
{
    /// <summary>
    ///     載入效果
    /// </summary>
    public class LoadEffect : Container, IComponentBase
    {
        /// <summary>
        ///     外框
        /// </summary>
        private readonly ImagePicec _effectPicec;


        /// <summary>
        ///     建構
        /// </summary>
        public LoadEffect()
        {
            //Anchor = Anchor.Centre;
            //Origin = Anchor.Centre;

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
        ///     開始特效
        /// </summary>
        public void FadeIn(double time = 0)
        {
            _effectPicec.FadeTo(0.9f, 0); //.ScaleTo(2.5f, 100).FadeTo(0.7f, 150).FadeTo(0, 200);
            _effectPicec.ScaleTo(2.5f, 100);
            _effectPicec.FadeTo(0.7f, 150);
            _effectPicec.FadeTo(0, 200);
        }

        /// <summary>
        ///     結束
        /// </summary>
        public void FadeOut(double time = 0)
        {
        }
    }
}
