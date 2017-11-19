// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Framework.Graphics.Containers;

namespace osu.Game.Rulesets.RP.UI.Piece
{
    public class HitEffectPiece<T> : EffectPiece<T> where T : Container
    {
        /// <summary>
        /// InitialHitEffectPiece
        /// </summary>
        public HitEffectPiece()
        {
            GenerateHitEffect();
        }

        /// <summary>
        /// Generate Hit Effect
        /// </summary>
        public virtual void GenerateHitEffect()
        {
        }

        /// <summary>
        /// if call this method 
        /// will generate HitEffect and Play it
        /// </summary>
        public void Hit()
        {
            SetEffect(Effect);
        }
    }
}
