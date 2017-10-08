// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using System.Linq;
using osu.Game.Rulesets.RP.Judgements;
using osu.Game.Rulesets.RP.Objects.Drawables.Interface;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Play
{
    /// <summary>
    /// Base object that can acceppt another object drag onto it
    /// </summary>
    public abstract class DrawableBaseContainableObject<T> : DrawableBaseRpObject, ICanContainObject
    {
        //FadeInTime
        public override float FadeInTime => 300;

        //FadeOutTime
        public override float FadeOutTime => 300;

        public DrawableBaseContainableObject(BaseRpObject hitObject)
            : base(hitObject)
        {
        }

        /// <summary>
        /// Add Object on ContainableObject
        /// </summary>
        /// <param name="dragObject"></param>
        public virtual void AddObject(T dragObject)
        {
            foreach (ICanContainObject<T> single in Components.Where(n => n is ICanContainObject<T>))
            {
                single.AddObject(dragObject);
            }
        }

        /// <summary>
        /// Add Object on ContainableObject
        /// </summary>
        /// <param name="dragObject"></param>
        public virtual void AddObject(List<T> dragObject)
        {
            foreach (ICanContainObject<T> single in Components.Where(n => n is ICanContainObject<T>))
            {
                single.AddObject(dragObject);
            }
        }

        /// <summary>
        /// remove Object from ContainableObject
        /// </summary>
        /// <param name="dragObject"></param>
        public virtual void RemoveObject(T dragObject)
        {
            foreach (ICanContainObject<T> single in Components.Where(n => n is ICanContainObject<T>))
            {
                single.RemoveObject(dragObject);
            }
        }

        /// <summary>
        /// remove Object from ContainableObject
        /// </summary>
        /// <param name="dragObject"></param>
        public virtual void RemoveObject(List<T> dragObject)
        {
            foreach (ICanContainObject<T> single in Components.Where(n => n is ICanContainObject<T>))
            {
                single.RemoveObject(dragObject);
            }
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        protected override RpJudgement CreateJudgement()
        {
            return new RpJudgement();
        }
    }
}
