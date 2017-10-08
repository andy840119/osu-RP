// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Framework.Graphics;
using osu.Game.Rulesets.RP.Objects.Drawables.Play;
using osu.Game.Rulesets.RP.SkinManager;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.CommonDwawablePiece;
using OpenTK;
using osu.Game.Rulesets.Objects.Drawables;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.Judgement.HitExplosion.HitEffectTemplate
{
    public class SlideHitEffectTemplate : BaseHitEffectTemplate
    {
        /// <summary>
        ///     目前結果
        /// </summary>
        protected override HitResult RpScoreResult => HitResult.Meh;

        /// <summary>
        ///     白色十字
        /// </summary>
        private readonly ImagePicec _effectPicec;

        /// <summary>
        ///     有音樂形狀那個icon
        /// </summary>
        private readonly ImagePicec _onpuPicec;

        public SlideHitEffectTemplate()
        {
            Children = new Drawable[]
            {
                _effectPicec = new ImagePicec(RpTexturePathManager.GetRPHitEffect(RpScoreResult, "Slide_effect"))
                {
                    Position = new Vector2(0, 0)
                },
                _onpuPicec = new ImagePicec(RpTexturePathManager.GetRPHitEffect(RpScoreResult, "RP"))
                {
                    Position = new Vector2(0, 0)
                }
            };
        }

        public override void StartEffect()
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
