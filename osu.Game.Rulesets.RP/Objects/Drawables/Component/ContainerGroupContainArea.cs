// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using System.Linq;
using osu.Framework.Graphics.Containers;
using osu.Game.Rulesets.RP.Objects.Drawables.Component.Interface;
using osu.Game.Rulesets.RP.Objects.Drawables.Interface;
using osu.Game.Rulesets.RP.Objects.Drawables.Component.Extension;
using osu.Game.Rulesets.RP.Objects.Interface;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Component
{
    public class ContainerGroupContainArea : Container, IContainListTemplate, IComponentBase
    {
        //TODO : if get Temlate from here, update the view and child
        public List<IHasTemplate> ListTemplate { get; set; }

        public void Add(IHasTemplate template)
        {
            this.AddTemplate(template);
            template.Template.Position = (template.Template.RpObject as IHasLayerIndex).PositionOfLayer();
        }

        public void Remove(IHasTemplate template)
        {
            this.RemoveTemplate(template);
        }

        public ContainerGroupContainArea()
        {
            ListTemplate=new List<IHasTemplate>();
        }

        public void Initial()
        {

        }

        public void FadeIn(double time = 0)
        {
        }

        public void FadeOut(double time = 0)
        {
        }
    }
}
