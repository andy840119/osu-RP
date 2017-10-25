// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Framework.Graphics;
using osu.Game.Rulesets.Judgements;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.RP.Judgements;
using osu.Game.Rulesets.RP.SkinManager;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.CommonDwawablePiece;
using OpenTK;

namespace osu.Game.Rulesets.RP.Objects.Drawables.RpDrawableJudgement
{
    public class SlideDrawableJudgement : DrawableJudgement
    {

        /// <summary>
        ///     白色十字
        /// </summary>
        private readonly ImagePicec _effectPicec;

        /// <summary>
        ///     有音樂形狀那個icon
        /// </summary>
        private readonly ImagePicec _onpuPicec;

        public SlideDrawableJudgement(RpJudgement judgement) : base(judgement)
        {
            Origin = Anchor.Centre;

            Children = new Drawable[]
            {
                _effectPicec = new ImagePicec(RpTexturePathManager.GetRPHitEffect(HitResult.Meh, "Slide_effect"))
                {
                    Position = new Vector2(0, 0)
                },
                _onpuPicec = new ImagePicec(RpTexturePathManager.GetRPHitEffect(HitResult.Meh, "RP"))
                {
                    Position = new Vector2(0, 0)
                }
            };
        }

        protected override void LoadComplete()
        {
            //透明度
            _effectPicec.FadeTo(1.0f, 0);
            _effectPicec.FadeTo(0.8f, 200);
            _effectPicec.FadeTo(0f, 300);
            //scale
            _effectPicec.Scale = new Vector2(0.4f);
            _effectPicec.ScaleTo(2.0f, 200);
            _effectPicec.ScaleTo(2.2f, 220);

            //透明度
            _onpuPicec.FadeTo(0.7f, 0);
            _onpuPicec.FadeTo(0.7f, 250);
            _onpuPicec.FadeTo(0f, 300);
            //scale
            _onpuPicec.Scale = new Vector2(1f);
            _onpuPicec.ScaleTo(1.8f, 200);
            _onpuPicec.ScaleTo(1.8f, 220);
        }
    }
}
