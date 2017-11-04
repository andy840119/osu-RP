// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System.Collections.Generic;
using System.Linq;
using osu.Framework.Graphics;
using osu.Framework.Input.Bindings;
using osu.Game.Beatmaps;
using osu.Game.Graphics;
using osu.Game.Overlays.Settings;
using osu.Game.Rulesets.Karaoke.KaraokeDifficulty;
using osu.Game.Rulesets.Karaoke.Mods;
using osu.Game.Rulesets.Karaoke.Objects;
using osu.Game.Rulesets.Karaoke.Osu_Objects;
using osu.Game.Rulesets.Karaoke.UI;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.UI;

namespace osu.Game.Rulesets.Karaoke
{
    /// <summary>
    /// this the the lagacy karaoke project
    /// and will not have any update version.
    /// means that it will not looks like Joysound or other different Karakoe tools in the future : )
    /// </summary>
    public class KaraokeRuleset : Ruleset
    {
        public override RulesetContainer CreateRulesetContainerWith(WorkingBeatmap beatmap, bool isForCurrentRuleset) => new KaraokeRulesetContainer(this, beatmap, isForCurrentRuleset);

        public override IEnumerable<KeyBinding> GetDefaultKeyBindings(int variant = 0) => new[]
        {
            new KeyBinding(InputKey.Z, KaraokeAction.LeftButton),
            new KeyBinding(InputKey.X, KaraokeAction.RightButton),
            new KeyBinding(InputKey.MouseLeft, KaraokeAction.LeftButton),
            new KeyBinding(InputKey.MouseRight, KaraokeAction.RightButton),

            new KeyBinding(InputKey.Number1, KaraokeAction.FirstLyric),
            new KeyBinding(InputKey.Left, KaraokeAction.PreviousLyric),
            new KeyBinding(InputKey.Right, KaraokeAction.NextLyric),
            new KeyBinding(InputKey.Space, KaraokeAction.PlayAndPause),
            new KeyBinding(InputKey.Q, KaraokeAction.IncreaseSpeed),
            new KeyBinding(InputKey.A, KaraokeAction.DecreaseSpeed),
            new KeyBinding(InputKey.W, KaraokeAction.IncreaseTone),
            new KeyBinding(InputKey.S, KaraokeAction.DecreaseTone),
            new KeyBinding(InputKey.E, KaraokeAction.IncreaseLyricAppearTime),
            new KeyBinding(InputKey.D, KaraokeAction.DecreaseLyricAppearTime),
        };

        public override IEnumerable<BeatmapStatistic> GetBeatmapStatistics(WorkingBeatmap beatmap) => new[]
            {
            new BeatmapStatistic
            {
                Name = @"Circle count",
                Content = beatmap.Beatmap.HitObjects.Count(h => h is HitCircle).ToString(),
                Icon = FontAwesome.fa_dot_circle_o
            },
            new BeatmapStatistic
            {
                Name = @"Slider count",
                Content = beatmap.Beatmap.HitObjects.Count(h => h is Slider).ToString(),
                Icon = FontAwesome.fa_circle_o
            }
        };

        public override IEnumerable<Mod> GetModsFor(ModType type)
        {
            switch (type)
            {
                case ModType.DifficultyReduction:
                    return new Mod[]
                    {
                        new OsuModEasy(),
                        new OsuModNoFail(),
                        new MultiMod
                        {
                            Mods = new Mod[]
                            {
                                new OsuModHalfTime(),
                                new OsuModDaycore(),
                            },
                        },
                    };

                case ModType.DifficultyIncrease:
                    return new Mod[]
                    {
                        new OsuModHardRock(),
                        new MultiMod
                        {
                            Mods = new Mod[]
                            {
                                new OsuModSuddenDeath(),
                                new OsuModPerfect(),
                            },
                        },
                        new MultiMod
                        {
                            Mods = new Mod[]
                            {
                                new OsuModDoubleTime(),
                                new OsuModNightcore(),
                            },
                        },
                        new OsuModHidden(),
                        new OsuModFlashlight(),
                    };

                case ModType.Special:
                    return new Mod[]
                    {
                        new OsuModRelax(),
                        new OsuModAutopilot(),
                        new OsuModSpunOut(),
                        new MultiMod
                        {
                            Mods = new Mod[]
                            {
                                new OsuModAutoplay(),
                                new ModCinema(),
                            },
                        },
                        new OsuModTarget(),
                    };

                default:
                    return new Mod[] { };
            }
        }

        public override Drawable CreateIcon() => new SpriteIcon { Icon = FontAwesome.fa_question_circle_o };

        public override DifficultyCalculator CreateDifficultyCalculator(Beatmap beatmap) => new OsuDifficultyCalculator(beatmap);

        public override string Description => "カラオケ!";

        public override SettingsSubsection CreateSettings() => new KaraokeSettings();

        //TODO : give it a id temporatory
        public override int LegacyID => 0;

        public KaraokeRuleset(RulesetInfo rulesetInfo)
            : base(rulesetInfo)
        {
        }
    }
}
