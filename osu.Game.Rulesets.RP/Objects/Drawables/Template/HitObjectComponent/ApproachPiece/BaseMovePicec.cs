// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System;
using osu.Framework.Graphics.Containers;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.Component;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.Interface;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Template.RpHitObject.Component.ApproachPiece
{
    /// <summary>
    ///     結束的物件後面帶的特效
    /// </summary>
    public class ComponentBaseMovePicec : Container, IComponentBase
    {
        /// <summary>
        ///     打擊物件
        /// </summary>
        protected BaseRpHitableObject BaseHitObject;

        public ComponentBaseMovePicec(BaseRpHitableObject baseHitObject)
        {
            BaseHitObject = baseHitObject;
        }

        public BaseRpObject HitObject { get; set; }
        public void Initial()
        {
            throw new NotImplementedException();
        }

        public void FadeIn(double time = 0)
        {
            throw new NotImplementedException();
        }

        public void FadeOut(double time = 0)
        {
            throw new NotImplementedException();
        }
    }
}
