// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using osu.Framework.Extensions;
using osu.Game.Beatmaps;
using osu.Game.Rulesets.Judgements;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.RP.Judgements;
using osu.Game.Rulesets.RP.Objects;
using osu.Game.Rulesets.RP.Objects.Drawables.Play;
using osu.Game.Rulesets.Scoring;
using osu.Game.Rulesets.UI;

namespace osu.Game.Rulesets.RP.Scoreing
{
    /// <summary>
    ///     簡單來說用來計算成績
    /// </summary>
    internal class RpScoreProcessor : ScoreProcessor<BaseRpObject>
    {

        public RpScoreProcessor(RulesetContainer<BaseRpObject> hitRenderer)
            : base(hitRenderer)
        {

        }

        private float hpDrainRate;

        private readonly Dictionary<HitResult, int> scoreResultCounts = new Dictionary<HitResult, int>();
        private readonly Dictionary<RpComboResult, int> comboResultCounts = new Dictionary<RpComboResult, int>();

        protected override void SimulateAutoplay(Beatmap<BaseRpObject> beatmap)
        {
            hpDrainRate = beatmap.BeatmapInfo.Difficulty.DrainRate;

            foreach (var obj in beatmap.HitObjects)
            {
                AddJudgement(new RpJudgement { Result = HitResult.Great });
            }
        }

        protected override void Reset(bool storeResults)
        {
            base.Reset(storeResults);

            scoreResultCounts.Clear();
            comboResultCounts.Clear();
        }

        public override void PopulateScore(Score score)
        {
            base.PopulateScore(score);

            score.Statistics[@"Cool"] = scoreResultCounts.GetOrDefault(HitResult.Perfect);
            score.Statistics[@"Fine"] = scoreResultCounts.GetOrDefault(HitResult.Great);
            score.Statistics[@"Safe"] = scoreResultCounts.GetOrDefault(HitResult.Good);
            score.Statistics[@"Sad"] = scoreResultCounts.GetOrDefault(HitResult.Ok);
            score.Statistics[@"Meh"] = scoreResultCounts.GetOrDefault(HitResult.Meh);
            score.Statistics[@"Sad"] = scoreResultCounts.GetOrDefault(HitResult.Miss);
        }

        protected override void OnNewJudgement(Judgement judgement)
        {
            base.OnNewJudgement(judgement);

            var rpJudgememt = judgement as RpJudgement;

            if (rpJudgememt != null)
            {
                //登入成績
                if (judgement.Result != HitResult.None)
                {
                    scoreResultCounts[rpJudgememt.Result] = scoreResultCounts.GetOrDefault(rpJudgememt.Result) + 1;
                    comboResultCounts[rpJudgememt.Combo] = comboResultCounts.GetOrDefault(rpJudgememt.Combo) + 1;
                }

                switch (judgement.Result)
                {
                    case HitResult.Great:
                        Health.Value += (10.2 - hpDrainRate) * 0.02;
                        break;

                    case HitResult.Good:
                        Health.Value += (8 - hpDrainRate) * 0.02;
                        break;

                    case HitResult.Meh:
                        Health.Value += (4 - hpDrainRate) * 0.02;
                        break;

                    /*case HitResult.SliderTick:
                        Health.Value += Math.Max(7 - hpDrainRate, 0) * 0.01;
                        break;*/

                    case HitResult.Miss:
                        Health.Value -= hpDrainRate * 0.04;
                        break;
                }
            }
        }
    }
}
