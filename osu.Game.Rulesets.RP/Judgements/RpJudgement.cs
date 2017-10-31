// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Game.Rulesets.Judgements;
using osu.Game.Rulesets.RP.Objects.Drawables.Play;
using OpenTK;

namespace osu.Game.Rulesets.RP.Judgements
{
    public class RpJudgement : Judgement
    {
        public DrawableBaseRpObject RpObject;

        public RpComboResult Combo;

        public Vector2 Position = new Vector2();
        public int AdditionalPlusScore = 0;
    }
}
