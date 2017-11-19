// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using osu.Game.Rulesets.Objects;
using osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.ContainerGegenerator.Parameter;
using osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator.Parameter;
using osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.Slicing.Parameter;

namespace osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.Parameter
{
    /// <summary>
    ///     a little monent of the beatmap
    /// </summary>
    public class ConvertParameter
    {
        /// <summary>
        ///     original hit Object;
        ///     can be use as refrence;
        /// </summary>
        public List<HitObject> ListRefrenceObject = new List<HitObject>();

        /// <summary>
        ///     切片時臨時會用參數
        /// </summary>
        public SliceConvertParameter SliceConvertParameter = new SliceConvertParameter();

        /// <summary>
        ///     打擊物件會用到的參數
        /// </summary>
        public HitObjectConvertParameter HitObjectConvertParameter = new HitObjectConvertParameter();

        /// <summary>
        ///     ContainerGroup 會用到的臨時參數
        /// </summary>
        public containerConvertParameter ContainerConvertParameter = new containerConvertParameter();

        public double Difficulty;
    }
}
