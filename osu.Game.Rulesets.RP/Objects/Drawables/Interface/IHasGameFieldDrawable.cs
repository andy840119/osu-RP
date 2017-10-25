// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Framework.Graphics.Containers;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Interface
{
    /// <summary>
    /// only appear to RpContainerLineGroup
    /// </summary>
    public interface IHasGameFieldDrawable : IHasTemplate
    {
        Container GameFieldContainer { get; set; }
    }
}
