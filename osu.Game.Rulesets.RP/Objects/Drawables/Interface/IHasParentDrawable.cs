// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Framework.Graphics.Containers;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Interface
{
    public interface IHasParentDrawable
    {
        Container ParentGroupContainer { get; set; }
    }
}
