// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Framework.Graphics;
using osu.Game.Rulesets.Judgements;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.RP.Judgements;
using osu.Game.Rulesets.RP.Objects.Drawables.RpDrawableJudgement;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.Judgement
{
    internal class JudgementLayout : BaseGamePlayLayout
    {

        public void AddHitEffect(RpJudgement judgement)
        {
            DrawableJudgement hitEffect;
            //Direction = FillDirection.Vertical;
            //Spacing = new Vector2(0, 2);
            //Position = (h?.Position ?? Vector2.Zero) + judgement.PositionOffset;


            //if ((Judgement as RpJudgement).HitExplosionPosition.Count > 0)
            //    Position = judgement.HitExplosionPosition[0];
           

            //TODO : 根據物件去顯示成績
            switch ((judgement as RpJudgement).Result)
            {
                case HitResult.Ok:
                    hitEffect = new SadDrawableJudgement(judgement);
                    break;
                case HitResult.Good:
                    hitEffect = new SafeDrawableJudgement(judgement);
                    break;
                case HitResult.Great:
                    hitEffect = new FineDrawableJudgement(judgement);
                    break;
                case HitResult.Perfect:
                    hitEffect = new CoolDrawableJudgement(judgement);
                    break;
                case HitResult.Meh:
                    hitEffect = new SlideDrawableJudgement(judgement);
                    break;

                default:
                    hitEffect = new SadDrawableJudgement(judgement);
                    break;

            }
            hitEffect.Position = judgement.Position;

            Add(hitEffect);
        }
    }
}
