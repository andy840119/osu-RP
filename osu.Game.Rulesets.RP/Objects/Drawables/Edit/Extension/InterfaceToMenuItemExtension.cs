// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using osu.Framework.Graphics.UserInterface;
using osu.Game.Graphics.UserInterface;
using osu.Game.Rulesets.RP.Objects.Drawables.Extension;
using osu.Game.Rulesets.RP.Objects.Drawables.Interface;
using osu.Game.Rulesets.RP.Objects.Interface;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Edit.Extension
{
    /// <summary>
    /// generate menu item by interface
    /// </summary>
    public static class InterfaceToMenuItemExtension
    {
        /// <summary>
        /// Direction >> up down left right
        /// </summary>
        /// <returns>The menu item by identifier irection.</returns>
        /// <param name="editableTemplate"></param>
        public static MenuItem GenerateDirectionMenuItem(this IHasEditableTemplate editableTemplate)
        {
            return new MenuItem(@"Direction")
            {
                Items = new List<MenuItem>()
                {
                    new OsuMenuItem(@"Up", MenuItemType.Standard, () =>
                    {
                        (editableTemplate.RpObject as IHasDirection).Direction = Direction.Up;
                        editableTemplate.UpdateTypeToDrawable(typeof(IHasDirection));
                    }),
                    new OsuMenuItem(@"Down", MenuItemType.Standard, () =>
                    {
                        (editableTemplate.RpObject as IHasDirection).Direction = Direction.Down;
                        editableTemplate.UpdateTypeToDrawable(typeof(IHasDirection));
                    }),
                    new OsuMenuItem(@"Left", MenuItemType.Standard, () =>
                    {
                        (editableTemplate.RpObject as IHasDirection).Direction = Direction.Left;
                        editableTemplate.UpdateTypeToDrawable(typeof(IHasDirection));
                    }),
                    new OsuMenuItem(@"Right", MenuItemType.Standard, () =>
                    {
                        (editableTemplate.RpObject as IHasDirection).Direction = Direction.Right;
                        editableTemplate.UpdateTypeToDrawable(typeof(IHasDirection));
                    }),
                }
            };
        }

        /// <summary>
        /// Color
        /// </summary>
        /// <returns>The menu item by identifier irection.</returns>
        /// <param name="editableTemplate">editableTemplate</param>
        public static MenuItem GenerateColorMenuItem(this IHasEditableTemplate editableTemplate)
        {
            return new OsuMenuItem(@"Up", MenuItemType.Standard, () =>
            {
                //TODO : ShowColorPicker
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The menu item by identifier irection.</returns>
        /// <param name="direction">Direction.</param>
        public static MenuItem GenerateCoopMenuItem(this IHasEditableTemplate editableTemplate)
        {
            return new MenuItem(@"Co-op")
            {
                Items = new List<MenuItem>()
                {
                    new OsuMenuItem(@"Both", MenuItemType.Standard, () =>
                    {
                        (editableTemplate.RpObject as IHasCoop).Coop = Coop.Both;
                        editableTemplate.UpdateTypeToDrawable(typeof(IHasCoop));
                    }),
                    new OsuMenuItem(@"Left Only", MenuItemType.Standard, () =>
                    {
                        (editableTemplate.RpObject as IHasCoop).Coop = Coop.LeftOnly;
                        editableTemplate.UpdateTypeToDrawable(typeof(IHasCoop));
                    }),
                    new OsuMenuItem(@"Right Only", MenuItemType.Standard, () =>
                    {
                        (editableTemplate.RpObject as IHasCoop).Coop = Coop.RightOnly;
                        editableTemplate.UpdateTypeToDrawable(typeof(IHasCoop));
                    }),
                }
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The menu item by identifier irection.</returns>
        /// <param name="direction">Direction.</param>
        public static MenuItem GenerateMovingLayerMenuItem(this IHasEditableTemplate editableTemplate)
        {
            return new MenuItem(@"Layer")
            {
                Items = new List<MenuItem>()
                {
                    new OsuMenuItem(@"Move UP", MenuItemType.Standard, () =>
                    {
                        if (editableTemplate.RpObject is IHasLayerIndex hasLayerIndexObject)
                        {
                            if (hasLayerIndexObject.LayerIndex > 0)
                            {
                                hasLayerIndexObject.LayerIndex--;
                                editableTemplate.UpdateTypeToDrawable(typeof(IHasLayerIndex));
                            }
                        }
                    }),
                    new OsuMenuItem(@"MoveDown", MenuItemType.Standard, () =>
                    {
                        if (editableTemplate.RpObject is IHasLayerIndex hasLayerIndexObject)
                        {
                            if (hasLayerIndexObject.LayerIndex < 10)
                            {
                                hasLayerIndexObject.LayerIndex++;
                                editableTemplate.UpdateTypeToDrawable(typeof(IHasLayerIndex));
                            }
                        }
                    }),
                }
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The menu item by identifier irection.</returns>
        /// <param name="direction">Direction.</param>
        public static MenuItem GenerateRotateMenuItem(this IHasEditableTemplate editableTemplate)
        {
            return new OsuMenuItem(@"Rotate", MenuItemType.Standard, () =>
            {
                //TODO : show Rotate tool
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The menu item by identifier irection.</returns>
        /// <param name="direction">Direction.</param>
        public static MenuItem GenerateScaleMenuItem(this IHasEditableTemplate editableTemplate)
        {
            return new OsuMenuItem(@"Scale", MenuItemType.Standard, () =>
            {
                //TODO : show Rotate tool
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The menu item by identifier irection.</returns>
        /// <param name="direction">Direction.</param>
        public static MenuItem GenerateSpecialMenuItem(this IHasEditableTemplate editableTemplate)
        {
            return new MenuItem(@"Type")
            {
                Items = new List<MenuItem>()
                {
                    new OsuMenuItem(@"Normal", MenuItemType.Standard, () =>
                    {
                        if (editableTemplate.RpObject is IHasSpecial hasSpecial)
                        {
                            hasSpecial.Special = Special.Normal;
                            editableTemplate.UpdateTypeToDrawable(typeof(IHasSpecial));
                        }
                    }),
                    new OsuMenuItem(@"Special", MenuItemType.Standard, () =>
                    {
                        if (editableTemplate.RpObject is IHasSpecial hasSpecial)
                        {
                            hasSpecial.Special = Special.Gold;
                            editableTemplate.UpdateTypeToDrawable(typeof(IHasSpecial));
                        }
                    }),
                }
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The menu item by identifier irection.</returns>
        /// <param name="direction">Direction.</param>
        public static MenuItem GenerateVelocityMenuItem(this IHasEditableTemplate editableTemplate)
        {
            return new OsuMenuItem(@"Velocity", MenuItemType.Standard, () =>
            {
                //TODO : show Velocity tool
            });
        }

        public static MenuItem GenerateDeleteMenuItem(this IHasEditableTemplate editableTemplate)
        {
            return new OsuMenuItem(@"Delete", MenuItemType.Standard, () =>
            {
                //TODO : delete the object
            });
        }
    }
}
