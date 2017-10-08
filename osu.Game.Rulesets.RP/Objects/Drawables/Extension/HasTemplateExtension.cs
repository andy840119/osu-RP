// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Linq;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Game.Rulesets.RP.Objects.Drawables.Interface;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Extension
{
    public static class HasTemplateExtension
    {
        /// <summary>
        /// AddTemplateToChild
        /// </summary>
        /// <param name="drawableObject"></param>
        public static void AddTemplateToChild(this IHasTemplate drawableObject)
        {
            if(drawableObject.Template!=null)
                drawableObject.Template.Dispose();
            drawableObject.Template = null;

            //要重新new 一個
            drawableObject.Template = new Template.Template(drawableObject.RpObject, drawableObject.Components);
            drawableObject.Template.Initial();

            //TODO : add or remove only template
            (drawableObject as Container).Children = new Drawable[]
            {
                drawableObject.Template
            };
        }

        /// <summary>
        /// RemoveTemplateFromChild
        /// </summary>
        /// <param name="drawableObject"></param>
        public static void RemoveTemplateFromChild(this IHasTemplate drawableObject)
        {
            //TODO : add or remove only template
            (drawableObject as Container).Children = new Drawable[]
            {
                //drawableObject.Template
            };

            // (drawableObject as Container).Children.ToList().Remove(drawableObject.Template);

            if (drawableObject.Template != null)
                drawableObject.Template.Dispose();
            drawableObject.Template = null;

            //要重新new 一個
            drawableObject.Template = new Template.Template(drawableObject.RpObject, drawableObject.Components);
            drawableObject.Template.Initial();
        }

    }
}
