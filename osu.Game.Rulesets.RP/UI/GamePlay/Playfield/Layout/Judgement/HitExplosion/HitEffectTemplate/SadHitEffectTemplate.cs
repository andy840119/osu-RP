// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Framework.Graphics;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.RP.Objects.Drawables.Play;
using osu.Game.Rulesets.RP.SkinManager;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.CommonDwawablePiece;
using OpenTK;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.Judgement.HitExplosion.HitEffectTemplate
{
    public class SadHitEffectTemplate : BaseHitEffectTemplate
    {
        /// <summary>
        ///     目前結果
        /// </summary>
        protected override HitResult RpScoreResult => HitResult.Ok;


        /// <summary>
        ///     特效
        /// </summary>
        private readonly ImagePicec _diffusePicec;

        /// <summary>
        ///     有音樂形狀那個icon
        /// </summary>
        private readonly ImagePicec _noonpuPicec;

        public SadHitEffectTemplate()
        {
            //string diffusePicecPath = SkinManager.RPSkinManager.GetRPHitEffect(RPScoreResult, "Diffuse");


            Children = new Drawable[]
            {
                _diffusePicec = new ImagePicec(RpTexturePathManager.GetRPHitEffect(RpScoreResult, "Diffuse"))
                {
                    Position = new Vector2(0, 0)
                },
                _noonpuPicec = new ImagePicec(RpTexturePathManager.GetRPHitEffect(RpScoreResult, "RP"))
                {
                    Position = new Vector2(0, 0)
                }
            };
        }

        public override void StartEffect()
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
