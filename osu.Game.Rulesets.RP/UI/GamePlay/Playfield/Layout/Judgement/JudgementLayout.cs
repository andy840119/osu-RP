// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.RP.Judgements;
using osu.Game.Rulesets.RP.Objects;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.Judgement
{
    internal class JudgementLayout : BaseGamePlayLayout
    {
        public void AddHitEffect(RpJudgement drawableHitObject)
        {
            var explosion = new HitExplosion.HitExplosion(drawableHitObject);
            Add(explosion);
        }
    }
}
