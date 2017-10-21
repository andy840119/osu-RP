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
    public class SadDrawableJudgement : DrawableJudgement
    {


        /// <summary>
        ///     特效
        /// </summary>
        private readonly ImagePicec _diffusePicec;

        /// <summary>
        ///     有音樂形狀那個icon
        /// </summary>
        private readonly ImagePicec _noonpuPicec;

        public SadDrawableJudgement(RpJudgement judgement) : base(judgement)
        {
            //string diffusePicecPath = SkinManager.RPSkinManager.GetRPHitEffect(RPScoreResult, "Diffuse");
            Origin = Anchor.Centre;

            Children = new Drawable[]
            {
                _diffusePicec = new ImagePicec(RpTexturePathManager.GetRPHitEffect(HitResult.Ok, "Diffuse"))
                {
                    Position = new Vector2(0, 0)
                },
                _noonpuPicec = new ImagePicec(RpTexturePathManager.GetRPHitEffect(HitResult.Ok, "RP"))
                {
                    Position = new Vector2(0, 0)
                }
            };
        }

        protected override void LoadComplete()
        {
            //透明度
            _diffusePicec.FadeTo(0.7f, 0);
            _diffusePicec.FadeTo(0.7f, 250);
            _diffusePicec.FadeTo(0f, 300);
            //scale
            _diffusePicec.Scale = new Vector2(0.8f);
            _diffusePicec.ScaleTo(2f, 50);
            _diffusePicec.ScaleTo(2f, 150);

            //透明度
            _noonpuPicec.FadeTo(0.8f, 0);
            _noonpuPicec.FadeTo(0.8f, 350);
            _noonpuPicec.FadeTo(0f, 400);
            //scale
            _noonpuPicec.Scale = new Vector2(1f);
            _noonpuPicec.ScaleTo(1.8f, 200);
            _noonpuPicec.ScaleTo(1.8f, 220);
        }
    }
}
