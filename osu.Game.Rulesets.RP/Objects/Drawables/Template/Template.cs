// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using System.Linq;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.MathUtils;
using osu.Game.Rulesets.RP.Objects.Drawables.Calculator;
using osu.Game.Rulesets.RP.Objects.Drawables.Component.Interface;
using osu.Game.Rulesets.RP.Objects.Drawables.Extension;
using OpenTK;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Template
{
    public class Template : Container
    {
        //RpObject
        public BaseRpObject RpObject;

        //Object that need to calculate each frame
        public List<IComponentBase> Components = new List<IComponentBase>();

        //calculate precentage by time
        protected PathPrecentageCounter PathPrecentageCounter;

        public Template(BaseRpObject rpObject, List<IComponentBase> components)
        {
            RpObject = rpObject;
            Components = components;

            PathPrecentageCounter = new PathPrecentageCounter();

           
        }

        public void Initial()
        {
            //initial all component template will use
            InitialComponent();
            //set all attribute form object to drawable component
            SetAppTypeByInterface();
            
            //adding all component into template
            InitialChild();
        }


        protected void SetAppTypeByInterface()
        {
            this.UpdateObjectToDrawable();
        }

        //initial all component template will use
        protected void InitialComponent()
        {
            foreach (var single in Components)
            {
                single.Initial();
            }
        }

        //adding all component into template
        protected void InitialChild()
        {
            Children = Components.Select(s => s as Container).ToArray();
        }

        //update on each frame
        public void UpdateEachFrame(double startTime, double endTime, double currentTime)
        {
            //start progress
            var startProgress = PathPrecentageCounter.CalculatePrecentage(startTime - currentTime, 1);
            //end progress
            var endProgress = PathPrecentageCounter.CalculatePrecentage(endTime - currentTime, 1);

            //set range between 0 to 1
            startProgress = MathHelper.Clamp(startProgress, 0, 1);
            endProgress = MathHelper.Clamp(endProgress, 0, 1);

            //update all 
            foreach (IComponentUpdateEachFrame single in Components.Where(n => n is IComponentUpdateEachFrame))
            {
                single.UpdateProgress(startProgress, endProgress);
            }
        }

        //Delay time
        public double DelayTime => 0;

        //update progress
        public void UpdateTemplate(double currentTime)
        {
            //start progress
            var startProgress = PathPrecentageCounter.CalculatePrecentage(RpObject.StartTime - currentTime + DelayTime, 1);
            //end progress
            var endProgress = PathPrecentageCounter.CalculatePrecentage(RpObject.StartTime - currentTime + DelayTime, 1);

            //影響程度
            var CurveEasingTypesPrecentage = 0;

            //修正
            startProgress = MathHelper.Clamp(startProgress, 0, 1);
            endProgress = MathHelper.Clamp(endProgress, 0, 1);
            //fix precentage by EasingTypes
            startProgress = Interpolation.ApplyEasing(Easing.None, startProgress, 0, 1, 1) * CurveEasingTypesPrecentage + startProgress * (1 - CurveEasingTypesPrecentage);
            endProgress = Interpolation.ApplyEasing(Easing.None, endProgress, 0, 1, 1) * CurveEasingTypesPrecentage + endProgress * (1 - CurveEasingTypesPrecentage);

            //update all 
            foreach (IComponentUpdateEachFrame single in Components.Where(n => n is IComponentUpdateEachFrame))
            {
                single.UpdateProgress(startProgress, endProgress);
            }
        }

        //Fade in
        public virtual void FadeIn(double time = 0)
        {
            foreach (IComponentBase single in Components)
            {
                single.FadeIn(time);
            }
        }

        //fade out
        public virtual void FadeOut(double time = 0)
        {
            foreach (IComponentBase single in Components)
            {
                single.FadeOut(time);
            }
        }
    }
}
