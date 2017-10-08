// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using osu.Game.Rulesets.RP.Objects.Drawables.Component.Interface;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Interface
{
    public interface IHasTemplate
    {
        Template.Template Template { get; set; }

        List<IComponentBase> Components { get; set; }

        BaseRpObject RpObject { get; }
    }
}
