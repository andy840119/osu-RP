// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.RP.Judgements;
using osu.Game.Rulesets.RP.Objects;
using osu.Game.Rulesets.UI;

namespace osu.Game.Rulesets.RP.UI.GamePlay.HitRenderer.ModsProcessor.GameField
{
    public class GameFieldModsProcessor
    {
        private List<Mod> listMods;

        public GameFieldModsProcessor(List<Mod> listMods)
        {
            this.listMods = listMods;
        }

        internal void ProcessGameField(Playfield<BaseRpObject, RpJudgement> playfield)
        {
        }
    }
}
