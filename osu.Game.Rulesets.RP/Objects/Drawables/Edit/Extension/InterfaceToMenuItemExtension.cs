using System;
using osu.Framework.Graphics.UserInterface;
using osu.Game.Rulesets.RP.Objects.Interface;
using System.Collections.Generic;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Edit.Extension
{
    /// <summary>
    /// generate menu item by interface
    /// </summary>
    public static class InterfaceToMenuItemExtension
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The menu item by identifier irection.</returns>
        /// <param name="direction">Direction.</param>
        public static MenuItem[] GenerateMenuItemByInterface(List<object> listINterface)
        {
            //TODO : also binding action ?
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The menu item by identifier irection.</returns>
        /// <param name="direction">Direction.</param>
        public static MenuItem[] GenerateMenuItemByInterface(object isInterface)
        {
            //TODO : also binding action ?
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The menu item by identifier irection.</returns>
        /// <param name="direction">Direction.</param>
        public static MenuItem[] GenerateMenuItem(this IHasBPM bgmInterface)
        {
            //TODO : show bgm input windows field
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The menu item by identifier irection.</returns>
        /// <param name="direction">Direction.</param>
        public static MenuItem[] GenerateMenuItem(this IHasColor colorINterface)
        {
            //TODO : show bgm input windows field
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The menu item by identifier irection.</returns>
        /// <param name="direction">Direction.</param>
        public static MenuItem[] GenerateMenuItem(this IHasCoop coop)
        {
            //TODO : show bgm input windows field
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The menu item by identifier irection.</returns>
        /// <param name="direction">Direction.</param>
        public static MenuItem[] GenerateMenuItem(this IHasDirection direction)
        {
            //TODO : also binding action ?
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The menu item by identifier irection.</returns>
        /// <param name="direction">Direction.</param>
        public static MenuItem[] GenerateMenuItem(this IHasRotation direction)
        {
            //TODO : also binding action ?
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The menu item by identifier irection.</returns>
        /// <param name="direction">Direction.</param>
        public static MenuItem[] GenerateMenuItem(this IHasScale scale)
        {
            //TODO : also binding action ?
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The menu item by identifier irection.</returns>
        /// <param name="direction">Direction.</param>
        public static MenuItem[] GenerateMenuItem(this IHasSpecial special)
        {
            //TODO : also binding action ?
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The menu item by identifier irection.</returns>
        /// <param name="direction">Direction.</param>
        public static MenuItem[] GenerateMenuItem(this IHasVelocity velocity)
        {
            //TODO : also binding action ?
            return null;
        }

    }
}
