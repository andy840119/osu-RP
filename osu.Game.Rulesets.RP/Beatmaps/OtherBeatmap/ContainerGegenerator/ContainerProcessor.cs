// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.ContainerGegenerator.ContainerPosition;
using osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.ContainerGegenerator.CoopDecide;
using osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.ContainerGegenerator.Generator;
using osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.ContainerGegenerator.MultiContainer;
using osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.Parameter;

namespace osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.ContainerGegenerator
{
    public class ContainerProcessor
    {
        //MultiContainerDecidor
        private readonly MultiContainerDecidor multiContainerDecidor = new MultiContainerDecidor();

        //ContainerGenerator
        private readonly ContainerGenerator containerGenerator = new ContainerGenerator();

        //PositionDecidor
        private readonly PositionDecidor positionDecidor = new PositionDecidor();

        //CoopDecider
        private readonly CoopDecider coopDecider = new CoopDecider();

        public List<ConvertParameter> Convert(List<ConvertParameter> output)
        {
            foreach (var single in output)
            {
                //decide the number of container and layout
                single.ContainerConvertParameter = multiContainerDecidor.GetParameter(single);
                //generator physical object //MultiAlocate
                single.ContainerConvertParameter.ListObjectContainer = containerGenerator.GetListContainer(single);
                //Decide Left or right
                coopDecider.DecideCoop(single);
                //position(PositionDecidor)
                positionDecidor.AllocatePosition(single);
            }
            return output;
        }
    }
}
