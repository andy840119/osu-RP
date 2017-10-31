// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using osu.Framework.Input;
using osu.Game.Beatmaps;
using osu.Game.Rulesets.Karaoke.Beatmaps;
using osu.Game.Rulesets.Karaoke.Objects;
using osu.Game.Rulesets.Karaoke.Objects.Drawables;
using osu.Game.Rulesets.Karaoke.Replays;
using osu.Game.Rulesets.Karaoke.Scoring;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.Replays;
using osu.Game.Rulesets.Scoring;
using osu.Game.Rulesets.UI;
using OpenTK;

namespace osu.Game.Rulesets.Karaoke.UI
{
    public class OsuRulesetContainer : RulesetContainer<OsuHitObject>
    {
        public OsuRulesetContainer(Ruleset ruleset, WorkingBeatmap beatmap, bool isForCurrentRuleset)
            : base(ruleset, beatmap, isForCurrentRuleset)
        {
        }

        public override ScoreProcessor CreateScoreProcessor() => new OsuScoreProcessor(this);

        protected override BeatmapConverter<OsuHitObject> CreateBeatmapConverter() => new OsuBeatmapConverter();

        protected override BeatmapProcessor<OsuHitObject> CreateBeatmapProcessor() => new OsuBeatmapProcessor();

        protected override Playfield CreatePlayfield() => new OsuPlayfield();

        public override PassThroughInputManager CreateInputManager() => new OsuInputManager(Ruleset.RulesetInfo);

        protected override DrawableHitObject<OsuHitObject> GetVisualRepresentation(OsuHitObject h)
        {
            var circle = h as HitCircle;
            if (circle != null)
                return new DrawableHitCircle(circle);

            var slider = h as Slider;
            if (slider != null)
                return new DrawableSlider(slider);

            var spinner = h as Spinner;
            if (spinner != null)
                return new DrawableSpinner(spinner);
            return null;
        }

        protected override FramedReplayInputHandler CreateReplayInputHandler(Replay replay) => new OsuReplayInputHandler(replay);

        protected override Vector2 GetPlayfieldAspectAdjust() => new Vector2(0.75f);
    }
}
