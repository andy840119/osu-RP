﻿// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Game.Rulesets.RP.Objects.Drawables.Component.Interface;
using osu.Game.Rulesets.RP.Objects.Interface;
using osu.Game.Rulesets.RP.SkinManager;
using osu.Game.Rulesets.RP.UI.Piece;
using OpenTK;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Component
{
    public class ApproachCircle : Container, IHasDirection, IHasPreemptTime, IComponentBase
    {
        /// <summary>
        ///     像osu! approach circle 那樣
        /// </summary>
        private ImagePicec _approachHitPicec;

        private Direction _dircetion;

        public float PreemptTime { get; set; }

        public Direction Direction
        {
            get { return _dircetion; }
            set
            {
                _dircetion = value;

                //create drawable
                Children = new Drawable[]
                {
                    _approachHitPicec = new ImagePicec(RpTexturePathManager.GetStartObjectImageNameByType(ObjectType.Hit, Special.Normal, Direction))
                    {
                    },
                };
                _approachHitPicec.Alpha = 0;
                _approachHitPicec.Scale = new Vector2(3);
            }
        }

        public ApproachCircle()
        {
        }

        /// <summary>
        ///     開始特效
        /// </summary>
        public void FadeIn(double time = 0)
        {
            _approachHitPicec.Delay(PreemptTime / 5 * 4).Then().FadeTo(1, PreemptTime / 5 * 4).ScaleTo(0.5f, PreemptTime / 5 * 1);

            return;

            _approachHitPicec.Delay(PreemptTime / 5 * 4);
            _approachHitPicec.FadeTo(1, PreemptTime / 5 * 4);
            //ApproachHitPicec.FadeIn(Math.Min(BaseHitObject.FadeInTime * 2, BaseHitObject.PreemptTime));
            _approachHitPicec.ScaleTo(0.5f, PreemptTime / 5 * 1);
        }

        /// <summary>
        ///     結束
        /// </summary>
        public void FadeOut(double time = 0)
        {
            _approachHitPicec.FadeOut(time);
        }
    }
}
