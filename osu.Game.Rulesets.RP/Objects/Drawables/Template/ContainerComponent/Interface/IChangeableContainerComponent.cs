// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

namespace osu.Game.Rulesets.RP.Objects.Drawables.Template.RpContainer.Component
{
    /// <summary>
    ///     可以改變Container的一些狀態
    /// </summary>
    public interface IChangeableContainerComponent
    {
        /// <summary>
        ///     改變高度
        /// </summary>
        /// <param name="newHeight"></param>
        void ChangeHeight(float newHeight);
    }
}
