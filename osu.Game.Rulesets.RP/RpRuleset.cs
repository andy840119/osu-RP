//Copyright (c) 2007-2016 ppy Pty Ltd <contact@ppy.sh>.
//Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System.Collections.Generic;
using osu.Game.Beatmaps;
using osu.Game.Graphics;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.RP.DifficultyCalculator;
using osu.Game.Rulesets.RP.KeyManager;
using osu.Game.Rulesets.RP.Scoreing;
using osu.Game.Rulesets.RP.UI.GamePlay.HitRenderer;
using osu.Game.Rulesets.RP.UI.GamePlay.KeyCounter;
using osu.Game.Rulesets.RP.UI.Select.Info;
using osu.Game.Rulesets.RP.UI.Select.RpMod;
using osu.Game.Rulesets.UI;
using osu.Game.Screens.Play;

namespace osu.Game.Rulesets.RP
{
    /// <summary>
    /// note : 
    /// mac beatmamp save path : /Users/Mac/.local/share/osu
    /// windows : C:\Users\andy840119\AppData\Roaming\osu
    /// </summary>
    public class RpRuleset : Ruleset
    {
        /// <summary>
        ///     what the icon does osu!RP use
        /// </summary>
        public override FontAwesome Icon => FontAwesome.fa_align_justify;

        /// <summary>
        ///     Description
        /// </summary>
        public override string Description => "osu!RP";

        /// <returns></returns>
        /// <summary>
        ///     PlayMode
        /// </summary>
        //protected override PlayMode PlayMode => PlayMode.RP;

        /// <summary>
        ///     RP Object will be convert to Deawable Object
        /// </summary>
        /// <param name="objects"></param>
        /// <returns></returns>
        public override HitRenderer CreateHitRendererWith(WorkingBeatmap beatmap, bool isForCurrentRuleset) => new RpHitRenderer(beatmap,isForCurrentRuleset);

        /// <summary>
        ///     beatmap的詳細資訊
        /// </summary>
        /// <param name="beatmap"></param>
        /// <returns></returns>
        public override IEnumerable<BeatmapStatistic> GetBeatmapStatistics(WorkingBeatmap beatmap) => new BeatmapStatistics(beatmap);

        /// <summary>
        ///     目前有那些模式
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public override IEnumerable<Mod> GetModsFor(ModType type) => new SelectMod(type);

        /// <summary>
        ///     計算難度
        /// </summary>
        /// <param name="beatmap"></param>
        /// <returns></returns>
        public override Game.Beatmaps.DifficultyCalculator CreateDifficultyCalculator(Beatmap beatmap) => new RpDifficultyCalculator(beatmap);

        /// <summary>
        ///     Score processor
        /// </summary>
        /// <returns></returns>
        public override osu.Game.Rulesets.Scoring.ScoreProcessor CreateScoreProcessor() => new RpScoreProcessor();

        /// <summary>
        ///     get the keys that currently use
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<KeyCounter> CreateGameplayKeys() => new RpKeyCounterCollection(RpKeyManager.GetCurrentKeyConfig()).ListKey;

        /// <summary>
        /// Do not override this unless you are a legacy mode.
        /// </summary>
        //public override int LegacyID => 4;
    }
}
