// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator.Generator;
using osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator.Position;
using osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator.PostProcess;
using osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator.PreAnalyse;
using osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator.Type;
using osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.Parameter;

namespace osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator
{
    public class HitObjectProcessor
    {
        private readonly PreAnalyseHitObject preAnalyseHitObject = new PreAnalyseHitObject();

        private readonly HitObjectGenerator hitObjectGenerator = new HitObjectGenerator();

        private readonly TypeCalculator typeCalculator = new TypeCalculator();

        private readonly PositionGenerator positionGenerator = new PositionGenerator();

        private readonly HitObjectPostProcessor hitObjectPostProcessor = new HitObjectPostProcessor();

        public List<ConvertParameter> Convert(List<ConvertParameter> output)
        {
            foreach (var single in output)
            {
                //preAnaylse
                single.HitObjectConvertParameter = preAnalyseHitObject.Analyse(single);
                //single multi, it will generator real ob object
                single.HitObjectConvertParameter.ListSingleHitObjectConvertParameter = hitObjectGenerator.GeneratorListHitObject(single);
                //type generator
                typeCalculator.ProcessType(single);
                //position genertator : will decide which container and layout whould allocate
                positionGenerator.ProcessPosition(single);
                //return
                hitObjectPostProcessor.PostProcess(single);
            }
            return output;
        }
    }
}
