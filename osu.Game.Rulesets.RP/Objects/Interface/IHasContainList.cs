// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;

namespace osu.Game.Rulesets.RP.Objects.Interface
{
    public interface IHasContainList<T>
    {
        List<T> ListContainObject { get; set; }
    }
}
