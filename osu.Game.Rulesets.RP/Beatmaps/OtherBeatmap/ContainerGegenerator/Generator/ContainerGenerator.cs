// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.Parameter;
using osu.Game.Rulesets.RP.Objects;

namespace osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.ContainerGegenerator.Generator
{
    public class ContainerGenerator
    {
        //parameter

        /// <summary>
        ///     Generators the object by parameter.
        /// </summary>
        internal List<RpContainerLineGroup> GetListContainer(ConvertParameter single)
        {
            var returnContainer = new List<RpContainerLineGroup>();
            var listLayout = new List<RpContainerLine>();

            //container number
            for (var i = 0; i < single.ContainerConvertParameter.ContainerNumber; i++)
            {
                returnContainer.Add(GenerateSingleContainer(single));

                //decide this container shouble allocate number of layout
                listLayout.Add(GenerateSingleLayout(single, returnContainer[i]));

                //    container layout number;
                //TODO : adjust it later
                returnContainer[i].ListContainObject[0] = listLayout[i];
            }

            return returnContainer;
        }


        private RpContainerLineGroup GenerateSingleContainer(ConvertParameter single)
        {
            var objectContainer = new RpContainerLineGroup(single.SliceConvertParameter.StartTime);
            objectContainer.StartTime = single.SliceConvertParameter.StartTime;
            objectContainer.EndTime = single.SliceConvertParameter.EndTime;
            objectContainer.BPM = single.SliceConvertParameter.BPM;
            objectContainer.Velocity = single.SliceConvertParameter.Volocity;
            return objectContainer;
        }

        private RpContainerLine GenerateSingleLayout(ConvertParameter single, RpContainerLineGroup container)
        {
            var objectContainerLayer = new RpContainerLine(container);
            objectContainerLayer.StartTime = single.SliceConvertParameter.StartTime;
            objectContainerLayer.EndTime = single.SliceConvertParameter.EndTime;
            return objectContainerLayer;
        }
    }
}
