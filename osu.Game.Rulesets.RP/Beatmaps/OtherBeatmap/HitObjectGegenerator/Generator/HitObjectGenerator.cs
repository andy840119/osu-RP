// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator.Parameter;
using osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.Parameter;
using osu.Game.Rulesets.RP.Objects;

namespace osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator.Generator
{
    /// <summary>
    /// </summary>
    public class HitObjectGenerator
    {
        public List<SingleHitObjectConvertParameter> GeneratorListHitObject(ConvertParameter single)
        {
            foreach (var singleHitObject in single.HitObjectConvertParameter.ListSingleHitObjectConvertParameter)
            {
                var singleHitObjects = new List<BaseRpHitableObject>();
                for (var i = 0; i < singleHitObject.MultiNumber; i++)
                    singleHitObjects.Add(GenerateRpHitObject(singleHitObject, single));
                singleHitObject.ListBaseHitObject = singleHitObjects;
            }

            return single.HitObjectConvertParameter.ListSingleHitObjectConvertParameter;
        }

        public RpHitObject GenerateRpHitObject(SingleHitObjectConvertParameter singleHitObject, ConvertParameter single)
        {
            var rpHitObject = new RpHitObject(single.ContainerConvertParameter.ListObjectContainer[0].ListContainObject[0], singleHitObject.StartTime);
            //fake sample
            return rpHitObject;
        }
    }
}
