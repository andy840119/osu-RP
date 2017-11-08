// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Game.Beatmaps;

namespace osu.Game.Rulesets.Karaoke.UI.Interface
{
    /// <summary>
    /// if it is karaoke GameField, need to add this for Externsion use
    /// </summary>
    public interface IAmKaraokeField
    {
        Ruleset Ruleset { get; }
        WorkingBeatmap WorkingBeatmap { get; }

        KaraokeRulesetContainer KaraokeRulesetContainer { get; }
    }
}
