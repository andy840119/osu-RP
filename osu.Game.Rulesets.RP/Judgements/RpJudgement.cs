// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using osu.Game.Rulesets.Judgements;
using osu.Game.Rulesets.RP.Objects.Drawables.Play;
using OpenTK;

namespace osu.Game.Rulesets.RP.Judgements
{
    public class RpJudgement : Judgement
    {
        public DrawableBaseRpObject RpObject;
        //public RpScoreResult MaxScore;

        // public RpScoreResult Score;
        public RpComboResult Combo;

        //TODO : will be remove
        public List<Vector2> HitExplosionPosition = new List<Vector2>();

        public Vector2 Position = new Vector2();
        public int AdditionalPlusScore = 0;
    }
}
