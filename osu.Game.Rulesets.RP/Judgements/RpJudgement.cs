// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using osu.Framework.Extensions;
using osu.Game.Rulesets.Judgements;
using osu.Game.Rulesets.RP.Objects.Drawables.Play;
using OpenTK;

namespace osu.Game.Rulesets.RP.Judgements
{
    public class RpJudgement : Judgement
    {

        //public RpScoreResult MaxScore;

       // public RpScoreResult Score;
        public RpComboResult Combo;
        public List<Vector2> HitExplosionPosition = new List<Vector2>();
        public int AdditionalPlusScore = 0;
    }
}
