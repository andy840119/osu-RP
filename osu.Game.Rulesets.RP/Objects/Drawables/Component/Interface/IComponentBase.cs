// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Framework.Graphics.Containers;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Component.Interface
{
    /// <summary>
    ///     is the part of the template object
    /// </summary>
    public interface IComponentBase : IContainer
    {
        /// <summary>
        ///     fade in
        /// </summary>
        void FadeIn(double time = 0);

        /// <summary>
        ///     Fade out
        /// </summary>
        void FadeOut(double time = 0);
    }
}
