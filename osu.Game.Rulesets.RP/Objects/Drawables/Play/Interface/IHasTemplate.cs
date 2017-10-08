// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Game.Rulesets.RP.Objects.Drawables.Template;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Play.Interface
{
    public interface IHasTemplate 
    {
        Template.Template Template { get; }
    }
}
