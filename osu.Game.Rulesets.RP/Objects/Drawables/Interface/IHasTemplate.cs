// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using osu.Framework.Graphics.Containers;
using osu.Game.Rulesets.RP.Objects.Drawables.Component.Interface;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Interface
{
    public interface IHasTemplate : IContainer
    {

        List<IComponentBase> Components { get; set; }

        BaseRpObject RpObject { get; }

        Container DrawableObject { get; }

        IHasTemplate ParentObject { get; set; }
    }
}
