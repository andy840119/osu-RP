// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System;
using System.Collections.Generic;
using osu.Framework.Graphics.Containers;
using osu.Game.Rulesets.RP.Objects.Drawables.Component.Extension;
using osu.Game.Rulesets.RP.Objects.Drawables.Component.Interface;
using osu.Game.Rulesets.RP.Objects.Drawables.Interface;
using osu.Game.Rulesets.RP.Objects.Interface;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Component
{
    public class ContainerLineContainArea : Container, IContainListTemplate,IHasVelocity,IHasStartTime, IComponentBase
    {
        //TODO : if get Temlate from here, update the view and child
        public List<IHasTemplate> ListTemplate { get; set; }

        public float Velocity { get; set; }

        public double StartTime { get; set; }

        public void Add(IHasTemplate template)
        {
            this.AddTemplate(template);
            //時間位置
            var position = this.PositionOfTime(template.RpObject.StartTime - StartTime);
            template.DrawableObject.Position = position;
        }

        public void Remove(IHasTemplate template)
        {
            this.RemoveTemplate(template);
        }

        public ContainerLineContainArea()
        {
            ListTemplate = new List<IHasTemplate>();
        }


        public void FadeIn(double time = 0)
        {
        }

        public void FadeOut(double time = 0)
        {
        }
    }
}
