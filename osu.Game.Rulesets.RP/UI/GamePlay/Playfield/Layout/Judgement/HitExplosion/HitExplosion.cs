// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Framework.Graphics;
using osu.Game.Rulesets.Judgements;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.RP.Judgements;
using osu.Game.Rulesets.RP.Objects.Drawables.Play;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.Judgement.HitExplosion.HitEffectTemplate;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.Judgement.HitExplosion
{
    /// <summary>
    ///     打擊會產生的特效
    /// </summary>
    public class HitExplosion : DrawableJudgement
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

            if ((Judgement as RpJudgement).HitExplosionPosition.Count > 0)
                Position = judgement.HitExplosionPosition[0];

            //TODO : 根據物件去顯示成績
            switch ((Judgement as RpJudgement).Result)
            {
                case HitResult.Ok:
                    _hitEffect = new SadHitEffectTemplate();
                    break;
                case HitResult.Good:
                    _hitEffect = new SafeHitEffectTemplate();
                    break;
                case HitResult.Great:
                    _hitEffect = new FineHitEffectTemplate();
                    break;
                case HitResult.Perfect:
                    _hitEffect = new CoolHitEffectTemplate();
                    break;
                case HitResult.Meh:
                    _hitEffect = new SlideHitEffectTemplate();
                    break;

                default:
                    _hitEffect = new SadHitEffectTemplate();
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
