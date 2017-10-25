// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using osu.Framework.Graphics.Containers;
using osu.Game.Rulesets.RP.Objects.Drawables.Play;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Interface
{
    public interface IHasGameField
    {
          List<DrawableBaseRpObject> ListDrawableObject { get; set; }

          List<Container> ListGroupContainer { get; set; }
    }
}
