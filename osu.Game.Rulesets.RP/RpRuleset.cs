// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using osu.Framework.Graphics;
using osu.Framework.Input.Bindings;
using osu.Game.Beatmaps;
using osu.Game.Overlays.Settings;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.RP.DifficultyCalculator;
using osu.Game.Rulesets.RP.KeyManager;
using osu.Game.Rulesets.RP.Scoreing;
using osu.Game.Rulesets.RP.UI.GamePlay.HitRenderer;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.CommonDwawablePiece;
using osu.Game.Rulesets.RP.UI.Select.Info;
using osu.Game.Rulesets.RP.UI.Select.RpMod;
using osu.Game.Rulesets.RP.UI.Setting;
using osu.Game.Rulesets.Scoring;
using osu.Game.Rulesets.UI;

namespace osu.Game.Rulesets.RP
{
    /// <summary>
    /// note : 
    /// mac beatmamp save path : /Users/Mac/.local/share/osu
    /// windows : 
    /// </summary>
    public class RpRuleset : Ruleset
    {
        /// <summary>
        ///     RP Object will be convert to Deawable Object
        /// </summary>
        /// <param name="objects"></param>
        /// <returns></returns>
        public override RulesetContainer CreateRulesetContainerWith(WorkingBeatmap beatmap, bool isForCurrentRuleset) => new RpRulesetContainer(this, beatmap, isForCurrentRuleset);

        /// <summary>
        /// all the keys that can be config
        /// </summary>
        /// <param name="variant"></param>
        /// <returns></returns>
        public override IEnumerable<KeyBinding> GetDefaultKeyBindings(int variant = 0) => new KeyBindingConfig().GetAllDefaultBinding();

        /// <summary>
        ///     detail column of a beatmap
        /// </summary>
        /// <param name="beatmap"></param>
        /// <returns></returns>
        public override IEnumerable<BeatmapStatistic> GetBeatmapStatistics(WorkingBeatmap beatmap) => new BeatmapStatistics(beatmap);

        /// <summary>
        ///     all the modes that RP have
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public override IEnumerable<Mod> GetModsFor(ModType type) => new SelectMod(type);

        /// <summary>
        ///     what the icon does osu!RP use
        /// </summary>
        public override Drawable CreateIcon() => new ImagePicec(@"GameIcon/Icon@2x"); // new SpriteIcon { Icon = FontAwesome.fa_question_circle };

        /// <summary>
        ///     Difficulty Calculator
        /// </summary>
        /// <param name="beatmap"></param>
        /// <returns></returns>
        public override Game.Beatmaps.DifficultyCalculator CreateDifficultyCalculator(Beatmap beatmap) => new RpDifficultyCalculator(beatmap);

        /// <summary>
        ///     Description
        /// </summary>
        public override string Description => "osu!RP";

        //public override SettingsSubsection CreateSettings() => new RpSettings();

        /// <summary>
        /// setting
        ///  TODO : Not work yet 
        /// </summary>
        /// <returns></returns>
        //public override SettingsSubsection CreateSettings() => new RpSettings();
        /// <summary>
        /// Do not override this unless you are a legacy mode.
        /// </summary>
        //public override int LegacyID => 1111;


        public override int LegacyID => 0;

        public RpRuleset(RulesetInfo rulesetInfo)
            : base(rulesetInfo)
        {
        }
    }
}
