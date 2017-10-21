// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;

namespace osu.Game.Rulesets.RP.UI.GamePlay.RulesetContainer.ModsProcessor.GameField
{
    public class GameFieldModsProcessor
    {
        private List<Mod> listMods;

        public GameFieldModsProcessor(List<Mod> listMods)
        {
            this.listMods = listMods;
        }

        internal void ProcessGameField(Rulesets.UI.Playfield playfield)
        {
        }
    }
}
