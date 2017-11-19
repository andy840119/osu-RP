// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Game.Rulesets.Objects.Drawables;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Component.Interface
{
    /// <summary>
    /// Object can be tickle by it's child Object
    /// </summary>
    public interface IComponentTickleByChild
    {
        void Tickle(BaseRpObject tickleFrom, HitResult result);
    }

    /// <summary>
    /// 如果有些物件會在打擊時閃爍
    /// </summary>
    public interface IComponentTickleByHit
    {
        void Tickle(BaseRpObject result);
    }
}
