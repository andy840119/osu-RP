// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Game.Rulesets.RP.Objects.Drawables.Interface;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Component.Interface
{
    /// <summary>
    /// if single component knows the whole components and HitObjects
    /// </summary>
    public interface IComponentKnowTemplate
    {
        IHasTemplate Template { get; set; }
    }
}
