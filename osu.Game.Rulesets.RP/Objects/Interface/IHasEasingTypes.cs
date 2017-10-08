// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Framework.Graphics;

namespace osu.Game.Rulesets.RP.Objects.Interface
{
    public interface IHasEasingTypes
    {
        //設定移動軌跡的曲線 will be remove
        Easing CurveEasingTypes { get; set; } //= EasingTypes.None;

        // 特殊曲線佔的百分比(0~1) will be remove
        double CurveEasingTypesPrecentage { get; set; } // = 0.5;
    }
}
