// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using System.Linq;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.RP.Judgements;
using osu.Game.Rulesets.RP.Objects;
using osu.Game.Rulesets.RP.UI.GamePlay.HitRenderer.ModsProcessor.GameField;
using osu.Game.Rulesets.RP.UI.GamePlay.HitRenderer.ModsProcessor.HitObject;
using osu.Game.Rulesets.UI;

namespace osu.Game.Rulesets.RP.UI.GamePlay.HitRenderer.ModsProcessor
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

        internal void ProcessGameField(Playfield<BaseRpObject, RpJudgement> playfield)
        {
            GameFieldModsProcessor.ProcessGameField(playfield);
        }

        internal void ProcessHitObject(DrawableHitObject<BaseRpObject, RpJudgement> returnObject)
        {
            HitObjectModsProcessor.ProcessHitObject(returnObject);
        }
    }
}
