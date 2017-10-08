// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Framework.Graphics;
using osu.Game.Rulesets.Judgements;
using osu.Game.Rulesets.RP.Judgements;
using osu.Game.Rulesets.RP.Objects.Drawables.Play;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.Judgement.HitExplosion.HitEffectTemplate;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.Judgement.HitExplosion
{
    /// <summary>
    ///     打擊會產生的特效
    /// </summary>
    public class HitExplosion : DrawableJudgement<RpJudgement>
    {
        /// <summary>
        ///     顯示特效
        /// </summary>
        private readonly BaseHitEffectTemplate _hitEffect;

        public HitExplosion(RpJudgement judgement)
            : base(judgement)
        {
            AutoSizeAxes = Axes.Both;
            Origin = Anchor.Centre;

            //Direction = FillDirection.Vertical;
            //Spacing = new Vector2(0, 2);
            //Position = (h?.Position ?? Vector2.Zero) + judgement.PositionOffset;

            if (Judgement.HitExplosionPosition.Count > 0)
                Position = judgement.HitExplosionPosition[0];

            //根據物件去顯示成績
            switch (Judgement.Score)
            {
                case RpScoreResult.Sad:
                    _hitEffect = new SadHitEffectTemplate();
                    break;
                case RpScoreResult.Safe:
                    _hitEffect = new SafeHitEffectTemplate();
                    break;
                case RpScoreResult.Fine:
                    _hitEffect = new FineHitEffectTemplate();
                    break;
                case RpScoreResult.Cool:
                    _hitEffect = new CoolHitEffectTemplate();
                    break;
                case RpScoreResult.Slider:
                    _hitEffect = new SlideHitEffectTemplate();
                    break;
            }

            //
            //_hitEffect = new FineHitEffectTemplate();
            //Position = PositionManager.GetPosition(h);

            //把物件增加上去
            Children = new Drawable[]
            {
                _hitEffect
            };
        }

        protected override void LoadComplete()
        {
            _hitEffect.StartEffect();
            base.LoadComplete();
        }
    }
}
