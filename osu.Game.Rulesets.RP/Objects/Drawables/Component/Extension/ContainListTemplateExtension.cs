// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Linq;
using osu.Framework.Graphics.Containers;
using osu.Game.Rulesets.RP.Objects.Drawables.Component.Interface;
using osu.Game.Rulesets.RP.Objects.Drawables.Extension;
using osu.Game.Rulesets.RP.Objects.Drawables.Interface;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Component.Extension
{
    public static class ContainListTemplateExtension
    {
        public static void AddTemplate(this IContainListTemplate listTemplate, IHasTemplate template)
        {
            //Add to list
            listTemplate.ListTemplate.Add(template);

            //return;
  
            //TODO : get better
            //remove from origin drawable
            template.RemoveTemplateFromChild();//TODO : impliment

            //add to drawable

            var list = (listTemplate as Container).Children.ToList();
            if (list.Count == 0)
            {
                list.Add(template.Template.CreateProxy());
                (listTemplate as Container).Children = list.ToArray();//TODO : impliment
            }
            else
            {
                //TODO : connot add
                (listTemplate as Container).Add((template.Template));
            }
        }

        public static void RemoveTemplate(this IContainListTemplate listTemplate, IHasTemplate template)
        {
            //remove from drawable
            template.AddTemplateToChild();
            (listTemplate as Container).Children.ToList().Remove(template.Template);
            //Add to list
            listTemplate.ListTemplate.Remove(template);
        }
    }
}
