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
    public class SafeHitEffectTemplate : BaseHitEffectTemplate
    {
        /// <summary>
        ///     目前結果
        /// </summary>
        protected override HitResult RpScoreResult => HitResult.Good;

        /// <summary>
        ///     有音樂形狀那個icon
        /// </summary>
        private readonly ImagePicec _noonpuPicec;

        public SafeHitEffectTemplate()
        {
            Children = new Drawable[]
            {
                _noonpuPicec = new ImagePicec(RpTexturePathManager.GetRPHitEffect(RpScoreResult, "RP"))
                {
                    //Colour = osuObject.Colour,
                    Scale = new Vector2(1, 1),
                    Position = new Vector2(0, 0)
                }
            };
        }

        public override void StartEffect()
        {
            //透明度
            _noonpuPicec.FadeTo(0.8f, 0);
            _noonpuPicec.FadeTo(0.8f, 350);
            _noonpuPicec.FadeTo(0f, 400);
            //scale
            _noonpuPicec.Scale = new Vector2(0.5f);
            _noonpuPicec.ScaleTo(0.8f, 200);
            _noonpuPicec.ScaleTo(0.8f, 220);
        }
    }
}
