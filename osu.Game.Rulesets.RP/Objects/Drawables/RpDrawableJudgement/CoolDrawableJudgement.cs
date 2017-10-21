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
    /// <summary>
    ///     如果是Cool的打擊特效
    /// </summary>
    public class CoolDrawableJudgement : DrawableJudgement
    {
        /// <summary>
        ///     黃色光環
        /// </summary>
        private readonly ImagePicec _flarePicec;

        /// <summary>
        ///     白色圈圈
        /// </summary>
        private readonly ImagePicec _loopPicec;

        /// <summary>
        ///     有音樂形狀那個icon
        /// </summary>
        private readonly ImagePicec _onpuPicec;

        public CoolDrawableJudgement(RpJudgement judgement) : base(judgement)
        {
            Origin = Anchor.Centre;

            Children = new Drawable[]
            {
                _flarePicec = new ImagePicec(RpTexturePathManager.GetRPHitEffect(HitResult.Perfect, "Flare"))
                {
                    Position = new Vector2(0, 0)
                },
                _loopPicec = new ImagePicec(RpTexturePathManager.GetRPHitEffect(HitResult.Perfect, "Loop"))
                {
                    //Colour = osuObject.Colour,
                    Position = new Vector2(0, 0)
                },
                _onpuPicec = new ImagePicec(RpTexturePathManager.GetRPHitEffect(HitResult.Perfect, "RP"))
                {
                    //Colour = osuObject.Colour,
                    Position = new Vector2(0, 0)
                }
            };
        }

        private float multi = 1;

        //開始特效
        protected override void LoadComplete()
        {
            //透明度
            _loopPicec.FadeTo(0.7f, 0);
            _loopPicec.FadeTo(0.7f, 250 * multi);
            _loopPicec.FadeTo(0f, 300 * multi);
            //scale
            _loopPicec.Scale = new Vector2(1.4f);
            _loopPicec.ScaleTo(3.0f, 200 * multi);
            _loopPicec.ScaleTo(3.0f, 220 * multi);

            //透明度
            _flarePicec.FadeTo(0.7f, 0);
            _flarePicec.FadeTo(0.7f, 250 * multi);
            _flarePicec.FadeTo(0f, 300 * multi);
            //scale
            _flarePicec.Scale = new Vector2(0.8f);
            _flarePicec.ScaleTo(1.6f, 50 * multi);
            _flarePicec.ScaleTo(1.6f, 150 * multi);

            //透明度
            _onpuPicec.FadeTo(0.8f, 0);
            _onpuPicec.FadeTo(0.8f, 350 * multi);
            _onpuPicec.FadeTo(0f, 400 * multi);
            //scale
            _onpuPicec.Scale = new Vector2(1f);
            _onpuPicec.ScaleTo(1.8f, 200 * multi);
            _onpuPicec.ScaleTo(1.8f, 220 * multi);
        }
    }
}
