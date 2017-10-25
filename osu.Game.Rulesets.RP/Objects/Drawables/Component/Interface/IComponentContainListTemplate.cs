// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using osu.Game.Rulesets.RP.Objects.Drawables.Interface;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Component.Interface
{
    public interface IComponentContainListTemplate
    {
        List<IHasTemplate> ListTemplate { get; set; }

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="template"></param>
        void Add(IHasTemplate template);

        /// <summary>
        /// Remove
        /// </summary>
        /// <param name="template"></param>
        void Remove(IHasTemplate template);
    }
}
