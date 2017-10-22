// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System;
using System.Collections.Generic;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Game.Rulesets.RP.Objects.RpEffect;
using osu.Game.Rulesets.RP.Objects.RpEffect.Point;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.CommonDwawablePiece
{
    public class EffectPiece<T> where T : Container
    {
        /// <summary>
        /// Rp Effect;
        /// </summary>
        protected RpEffect Effect = new RpEffect();

        /// <summary>
        /// Default that ProcessTime is 1000ms
        /// </summary>
        protected double Time = 1000;

        /// <summary>
        /// The target container.s
        /// </summary>
        T TargetContainer;

        public EffectPiece()
        {
        }

        //TODO :  set the filter effect
        public Type[] IncompatibleMods; //=> new[] { typeof(ModAutoplay), typeof(RpModRelax) };

        /// <summary>
        /// Sets the target container.
        /// </summary>
        /// <param name="targetContainer">Target container.</param>
        public void SetTargetContainer(T targetContainer)
        {
            TargetContainer = targetContainer;
        }


        /// <summary>
        /// Sets effect.
        /// </summary>
        /// <param name="effect">Effect.</param>
        public void SetEffect(RpEffect effect)
        {
            Effect = effect;
            CleanAllEffect();
            UpdateEffect();
        }

        /// <summary>
        /// clean all effect that TargetContainer have
        /// </summary>
        private void CleanAllEffect()
        {
            //TargetContainer.Transforms.Clear();
        }

        /// <summary>
        /// Add all effect to the TargetContainer;
        /// </summary>
        private void UpdateEffect()
        {
            double delay = 0;
            double lastEffectDeltaTime = 0;

            List<EffectPoint> listSortedPoint = Effect.GetFilterEffectPoint(IncompatibleMods);
            do
            {
                foreach (EffectPoint singleEffectPoint in listSortedPoint)
                {
                    delay = singleEffectPoint.Time - lastEffectDeltaTime - delay;
                    //set the effect time
                    TargetContainer.Delay(delay);
                    UpdateSingleEffectPoint(singleEffectPoint);
                    //Save the last effect process time ;
                    lastEffectDeltaTime = singleEffectPoint.ProcessTime;
                }
                if (delay > Time)
                    break;
            } while (Effect.Loop);
        }

        private void UpdateSingleEffectPoint(EffectPoint singleEffectPoint)
        {
            if (singleEffectPoint is ScaleEffectPoint)
            {
                ScaleEffectPoint effectPoint = singleEffectPoint as ScaleEffectPoint;
                TargetContainer.ScaleTo(effectPoint.NewScale, effectPoint.ProcessTime, effectPoint.EasingTypes);
            }
            else if (singleEffectPoint is ColorEffectPoint)
            {
                ColorEffectPoint effectPoint = singleEffectPoint as ColorEffectPoint;
                TargetContainer.FadeColour(effectPoint.Color, effectPoint.ProcessTime, effectPoint.EasingTypes);
            }
        }

        public void SetProcessTime()
        {
        }
    }
}
