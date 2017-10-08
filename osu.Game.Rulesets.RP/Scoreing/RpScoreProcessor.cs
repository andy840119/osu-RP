// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using osu.Framework.Extensions;
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
    internal class RpScoreProcessor : ScoreProcessor<BaseRpObject, RpJudgement>
    {
        public RpScoreProcessor()
        {
        }

        public RpScoreProcessor(RulesetContainer<BaseRpObject, RpJudgement> hitRenderer)
            : base(hitRenderer)
        {
        }

        protected override void Reset()
        {
            base.Reset();

            Health.Value = 1;
            Accuracy.Value = 1;
        }

        private readonly Dictionary<RpScoreResult, int> scoreResultCounts = new Dictionary<RpScoreResult, int>();
        private readonly Dictionary<RpComboResult, int> comboResultCounts = new Dictionary<RpComboResult, int>();

        public override void PopulateScore(Score score)
        {
            base.PopulateScore(score);

            score.Statistics[@"Cool"] = scoreResultCounts.GetOrDefault(RpScoreResult.Cool);
            score.Statistics[@"Fine"] = scoreResultCounts.GetOrDefault(RpScoreResult.Fine);
            score.Statistics[@"Safe"] = scoreResultCounts.GetOrDefault(RpScoreResult.Safe);
            score.Statistics[@"Sad"] = scoreResultCounts.GetOrDefault(RpScoreResult.Safe);
        }

        protected override void OnNewJudgement(RpJudgement judgement)
        {
            if (judgement != null)

                //登入成績
                if (judgement.Result != HitResult.None)
                {
                    scoreResultCounts[judgement.Score] = scoreResultCounts.GetOrDefault(judgement.Score) + 1;
                    comboResultCounts[judgement.Combo] = comboResultCounts.GetOrDefault(judgement.Combo) + 1;
                }

            switch (judgement.Result)
            {
                case HitResult.Hit:
                    Combo.Value++;
                    Health.Value += 0.1f;
                    break;
                case HitResult.Miss:
                    Combo.Value = 0;
                    Health.Value -= 0.1f;
                    break;
            }

            //成績
            var score = 0;
            //最大成績
            var maxScore = 0;

            foreach (var j in Judgements)
            {
                switch (j.Score)
                {
                    case RpScoreResult.Sad:
                        maxScore += 300;
                        break;
                    case RpScoreResult.Safe:
                        score += 100;
                        maxScore += 300;
                        break;
                    case RpScoreResult.Fine:
                        score += 250;
                        maxScore += 300;
                        break;
                    case RpScoreResult.Cool:
                        score += 300;
                        maxScore += 300;
                        break;
                }
                //增加額外分數
                score += j.AdditionalPlusScore;
            }

            TotalScore.Value = score;
            //命中率
            Accuracy.Value = (double)score / maxScore;
        }
    }
}
