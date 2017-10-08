// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Extension
{
    /// <summary>
    /// update (the type Rp Object change) to Template 
    /// https://stackoverflow.com/questions/358835/getproperties-to-return-all-properties-for-an-interface-inheritance-hierarchy
    /// https://stackoverflow.com/questions/1272871/interface-property-copy-in-c-sharp
    /// https://msdn.microsoft.com/zh-tw/library/xb5dd1f1(v=vs.110).aspx
    /// </summary>
    public static class ObjectTypeExtension
    {
        public static void UpdateObjectToDrawable(this Template.Template template)
        {
            foreach (var type in template.RpObject.GetType().GetInterfaces())
            {
                UpdateTypeToDrawable(template, type);
            }
        }

        public static void UpdateTypeToDrawable(this Template.Template template, Type type)
        {
            foreach (var singleDrawableObject in template.Components)
            {
                //all interface of a part of drawable object
                var singleObjectInterfaces = singleDrawableObject.GetType().GetInterfaces();

                //find all interface
                for (int i = 0; i < singleObjectInterfaces.Length; i++)
                {
                    //if has same interface
                    if (singleObjectInterfaces[i].ToString() == type.ToString())
                    {
                        //singleObjectInterfaces[i] = type;
                        //CopyPropertiesTo<Type>(type, singleObjectInterfaces[i]);

                        //TODO : 測試取得所有屬性

                        var allSourceProperty = type.GetPublicProperties();
                        var allDestProperty = singleObjectInterfaces[i].GetPublicProperties();
                        for (int j = 0; j < allSourceProperty.Length; j++)
                        {
                            object property = allSourceProperty[j].GetValue(template.RpObject, null);
                            allDestProperty[j].SetValue(singleDrawableObject, property, null);
                        }
                        //foreach (PropertyInfo prop in allSourceProperty)
                        //{
                        //    //設定屬鏡
                        //    prop.SetValue(singleObjectInterfaces[i], prop.GetValue(type, null), null);
                        //}
                    }
                }
            }
        }

        public static PropertyInfo[] GetPublicProperties(this Type type)
        {
            if (type.IsInterface)
            {
                var propertyInfos = new List<PropertyInfo>();

                var considered = new List<Type>();
                var queue = new Queue<Type>();
                considered.Add(type);
                queue.Enqueue(type);
                while (queue.Count > 0)
                {
                    var subType = queue.Dequeue();
                    foreach (var subInterface in subType.GetInterfaces())
                    {
                        if (considered.Contains(subInterface)) continue;

                        considered.Add(subInterface);
                        queue.Enqueue(subInterface);
                    }

                    var typeProperties = subType.GetProperties(
                        BindingFlags.FlattenHierarchy
                        | BindingFlags.Public
                        | BindingFlags.Instance);

                    var newPropertyInfos = typeProperties
                        .Where(x => !propertyInfos.Contains(x));

                    propertyInfos.InsertRange(0, newPropertyInfos);
                }

                return propertyInfos.ToArray();
            }

            return type.GetProperties(BindingFlags.FlattenHierarchy
                                      | BindingFlags.Public | BindingFlags.Instance);
        }
    }
}
