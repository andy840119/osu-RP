// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.Parameter;
using osu.Game.Rulesets.RP.Objects;

namespace osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.ContainerGegenerator.CoopDecide
{
    internal class CoopDecider
    {
        private readonly int _coopNumber = 10;

        /// <summary>
        ///     DecideCoop
        /// </summary>
        /// <param name="single"></param>
        internal void DecideCoop(ConvertParameter single)
        {
            var layoutNumber = 0;
            //Get the number of layoutNumber;
            foreach (var sligleContainer in single.ContainerConvertParameter.ListObjectContainer)
                layoutNumber = layoutNumber + sligleContainer.ListContainObject.Count;

            //Get how many number of the RpHitObject
            var refCount = single.ListRefrenceObject.Count;

            //decide use coop or not
            if (refCount < _coopNumber)
                GenerateCoop(single);
            else
                GenerateNonCoop(single);
        }

        /// <summary>
        ///     all the layout will have non-coop
        /// </summary>
        private void GenerateNonCoop(ConvertParameter single)
        {
            foreach (var sligleContainer in single.ContainerConvertParameter.ListObjectContainer)
            foreach (var layout in sligleContainer.ListContainObject)
                layout.Coop = Coop.Both;
        }

        /// <summary>
        ///     Depend on how many layout and decide the coop
        /// </summary>
        private void GenerateCoop(ConvertParameter single)
        {
            var listLayout = new List<RpContainerLine>();
            foreach (var sligleContainer in single.ContainerConvertParameter.ListObjectContainer)
                listLayout.AddRange(sligleContainer.ListContainObject);

            var additionRandomValue = GetRandomValue(single);
            for (var i = 0; i < listLayout.Count; i++)
                if ((i + additionRandomValue) % 2 == 0)
                    listLayout[i].Coop = Coop.LeftOnly;
                else
                    listLayout[i].Coop = Coop.RightOnly;
        }

        /// <summary>
        ///     generate readom value by something
        /// </summary>
        /// <returns></returns>
        private int GetRandomValue(ConvertParameter single)
        {
            return single.ListRefrenceObject.Count + single.ContainerConvertParameter.ListObjectContainer.Count + 1;
        }
    }
}
