// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Framework.Graphics;
using osu.Game.Rulesets.Judgements;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.RP.Judgements;
using osu.Game.Rulesets.RP.Objects.Drawables.Play;
using osu.Game.Rulesets.RP.SkinManager;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.CommonDwawablePiece;
using OpenTK;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.Judgement.HitExplosion.HitEffectTemplate
{
    public class FineDrawableJudgement : DrawableJudgement
    {
        /// <summary>
        ///     白色十字
        /// </summary>
        private readonly ImagePicec _crossPicec;

        /// <summary>
        ///     白色十字
        /// </summary>
        private readonly ImagePicec _effectPicec;

        /// <summary>
        ///     有音樂形狀那個icon
        /// </summary>
        private readonly ImagePicec _onpuPicec;

        public FineDrawableJudgement(RpJudgement judgement) : base(judgement)
        {
            Origin = Anchor.Centre;

            Children = new Drawable[]
            {
                _crossPicec = new ImagePicec(RpTexturePathManager.GetRPHitEffect(HitResult.Good, "Down"))
                {
                    //Colour = osuObject.Colour,
                    Position = new Vector2(0, 0),
                    Scale = new Vector2(1, 1)
                },
                _effectPicec = new ImagePicec(RpTexturePathManager.GetRPHitEffect(HitResult.Good, "Slide_effect"))
                {
                    //Colour = osuObject.Colour,
                    Position = new Vector2(0, 0),
                    Scale = new Vector2(1, 1)
                },
                _onpuPicec = new ImagePicec(RpTexturePathManager.GetRPHitEffect(HitResult.Good, "RP"))
                {
                    //Colour = osuObject.Colour,
                    Position = new Vector2(0, 0),
                    Scale = new Vector2(1, 1)
                }
            };
        }

        protected override void LoadComplete()
        {
            //透明度
            _crossPicec.FadeTo(0.7f, 0);
            _crossPicec.FadeTo(0.7f, 250);
            _crossPicec.FadeTo(0f, 300);
            //scale
            _crossPicec.Scale = new Vector2(0.8f);
            _crossPicec.ScaleTo(1.6f, 200);
            _crossPicec.ScaleTo(1.6f, 220);

            _crossPicec.RotateTo(-30, 220);

            //透明度
            _effectPicec.FadeTo(0.7f, 0);
            _effectPicec.FadeTo(0.7f, 250);
            _effectPicec.FadeTo(0f, 300);
            //scale
            _effectPicec.Scale = new Vector2(0.8f);
            _effectPicec.ScaleTo(2f, 50);
            _effectPicec.ScaleTo(2f, 150);

            //透明度
            _onpuPicec.FadeTo(0.8f, 0);
            _onpuPicec.FadeTo(0.8f, 350);
            _onpuPicec.FadeTo(0f, 400);
            //scale
            _onpuPicec.Scale = new Vector2(1f);
            _onpuPicec.ScaleTo(1.8f, 200);
            _onpuPicec.ScaleTo(1.8f, 220);
        }
    }
}
