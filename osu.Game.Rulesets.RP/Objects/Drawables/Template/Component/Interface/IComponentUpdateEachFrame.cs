// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

namespace osu.Game.Rulesets.RP.Objects.Drawables.Template.Interface
{
    //if need to update each frame, should inherit this
    public interface IComponentUpdateEachFrame
    {
        void UpdateProgress(double startProgress = 0, double endProgress = 1);
    }
}
