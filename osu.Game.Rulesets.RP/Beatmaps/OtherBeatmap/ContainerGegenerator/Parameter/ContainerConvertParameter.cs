// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using osu.Game.Rulesets.RP.Objects;

namespace osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.ContainerGegenerator.Parameter
{
    public class containerConvertParameter
    {
        /// <summary>
        ///     The container number.
        /// </summary>
        public int ContainerNumber = 1;

        /// <summary>
        ///     The layout number.
        /// </summary>
        public int LayoutNumber = 1;

        /// <summary>
        ///     enable multiObject or not
        /// </summary>
        public bool MultiObjectMode = false;

        /// <summary>
        ///     all of the container class
        /// </summary>
        public List<RpContainerGroup> ListObjectContainer = new List<RpContainerGroup>();
    }
}
