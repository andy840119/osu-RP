// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

namespace osu.Game.Rulesets.RP.Objects.Drawables.Template.Interface
{
    /// <summary>
    /// not sure this interface will be replace directly by EffectPiece class
    /// </summary>
    public interface IComponentAcceptEffect
    {
        /// <summary>
        /// if receive this effect 
        /// just pass RpEffect to the class that inherit EffectPiece
        /// </summary>
        /// <returns>The effect.</returns>
        /// <param name="effect">Effect.</param>
        void Effect(RpEffect.RpEffect effect);
    }
}
