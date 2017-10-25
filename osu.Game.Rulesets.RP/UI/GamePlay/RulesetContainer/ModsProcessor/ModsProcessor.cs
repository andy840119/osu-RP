// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using System.Linq;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.RP.Objects;
using osu.Game.Rulesets.RP.UI.GamePlay.RulesetContainer.ModsProcessor.GameField;
using osu.Game.Rulesets.RP.UI.GamePlay.RulesetContainer.ModsProcessor.HitObject;

namespace osu.Game.Rulesets.RP.UI.GamePlay.RulesetContainer.ModsProcessor
{
    /// <summary>
    /// process Mods
    /// </summary>
    public class ModsProcessor
    {
        private GameFieldModsProcessor GameFieldModsProcessor;
        private HitObjectModsProcessor HitObjectModsProcessor;

        private List<Mod> listMods;

        public ModsProcessor(IEnumerable<Mod> value)
        {
            listMods = value.ToList();

            GameFieldModsProcessor = new GameFieldModsProcessor(listMods);
            HitObjectModsProcessor = new HitObjectModsProcessor(listMods);
        }

        internal void ProcessGameField(Rulesets.UI.Playfield playfield)
        {
            GameFieldModsProcessor.ProcessGameField(playfield);
        }

        internal void ProcessHitObject(DrawableHitObject<BaseRpObject> returnObject)
        {
            HitObjectModsProcessor.ProcessHitObject(returnObject);
        }
    }
}
