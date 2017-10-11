// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using System.Linq;
using osu.Framework.Extensions.IEnumerableExtensions;
using osu.Game.Rulesets.RP.Objects.Drawables.Component.Interface;
using osu.Game.Rulesets.RP.Objects.Drawables.Interface;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Extension
{
    public static class CanContainObjectExtension
    {
        public static List<IHasTemplate> ListContainObject(this ICanContainObject iCanContainObject)
        {
            var list = iCanContainObject.Components.Where(n => n is IContainListTemplate);
            return (list.FirstOrDefault() as IContainListTemplate).ListTemplate;

            //(Components.Where(n => n is ICanContainObject<T>).FirstOrDefault() as ICanContainObject<T>).ListContainObject = value;
        }

        private static List<IContainListTemplate> containListTemplate(this ICanContainObject iCanContainObject)
        {
            var listCompare = iCanContainObject.Components.Where(n => n is IContainListTemplate);
            List<IContainListTemplate> listReturn = new List<IContainListTemplate>();
            foreach (var single in listCompare)
            {
                listReturn.Add(single as IContainListTemplate);
            }
            return listReturn;

            //(Components.Where(n => n is ICanContainObject<T>).FirstOrDefault() as ICanContainObject<T>).ListContainObject = value;
        }

        public static void AddObject(this ICanContainObject iCanContainObject, IHasTemplate drawableObject)
        {
            foreach (var single in iCanContainObject.containListTemplate())
            {
                single.Add(drawableObject);
            }
        }

        /// <summary>
        /// Add Object on ContainableObject
        /// </summary>
        /// <param name="iCanContainObject"></param>
        /// <param name="dragObject"></param>
        public static void AddObject(this ICanContainObject iCanContainObject, List<IHasTemplate> dragObject)
        {
            foreach (IHasTemplate single in dragObject)
            {
                iCanContainObject.AddObject(single);
            }
        }

        /// <summary>
        /// remove Object from ContainableObject
        /// </summary>
        /// <param name="iCanContainObject"></param>
        /// <param name="dragObject"></param>
        public static void RemoveObject(this ICanContainObject iCanContainObject, IHasTemplate dragObject)
        {
            foreach (var single in iCanContainObject.containListTemplate())
            {
                single.Remove(dragObject);
            }
        }

        /// <summary>
        /// remove Object from ContainableObject
        /// </summary>
        /// <param name="iCanContainObject"></param>
        /// <param name="dragObject"></param>
        public static void RemoveObject(this ICanContainObject iCanContainObject, List<IHasTemplate> dragObject)
        {
            foreach (IHasTemplate single in dragObject)
            {
                iCanContainObject.RemoveObject(single);
            }
        }
    }
}
