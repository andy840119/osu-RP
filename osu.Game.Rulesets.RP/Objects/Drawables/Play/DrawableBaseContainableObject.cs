// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using osu.Game.Rulesets.RP.Judgements;
using osu.Game.Rulesets.RP.Objects.Drawables.Play.Interface;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.ContainerComponent.Interface;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.RpContainer;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Play
{
    /// <summary>
    /// Base object that can acceppt another object drag onto it
    /// </summary>
    public abstract class DrawableBaseContainableObject<T> : DrawableBaseRpObject, ICanContainObject<T> where T : IHasTemplate
    {
        //FadeInTime
        public override float FadeInTime => 300;

        //FadeOutTime
        public override float FadeOutTime => 300;

        public BindingList<T> ListContainObject
        {
            get
            {
                return (Components.Where(n => n is ICanContainObject<T>).FirstOrDefault() as ICanContainObject<T>).ListContainObject;
            }
            set
            {
                (Components.Where(n => n is ICanContainObject<T>).FirstOrDefault() as ICanContainObject<T>).ListContainObject = value;
            }
        }

        public DrawableBaseContainableObject(BaseRpObject hitObject)
            : base(hitObject)
        {
            ListContainObject = new BindingList<T>();
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
