// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Game.Rulesets.RP.Objects;
using OpenTK.Graphics;

namespace osu.Game.Rulesets.RP.SkinManager
{
    /// <summary>
    ///     Manage all the Color in the skin that can be adjust in the skin config.
    /// </summary>
    public static class RpTextureColorManager
    {
        /// <summary>
        ///     RpHitObject's shape color
        /// </summary>
        /// <returns></returns>
        public static Color4 GetKeyLayoutButtonDirection(Direction type)
        {
            /*
            switch (type)
            {
                case Shape.Right:
                    return new Color4(200, 200, 200, 255);
                case Shape.Down:
                    return new Color4(200, 200, 200, 255);
                case Shape.Left:
                    return new Color4(200, 200, 200, 255);
                case Shape.Up:
                    return new Color4(200, 200, 200, 255);
                case Shape.ContainerHold:
                    return new Color4(200, 200, 200, 255);
            }
            return new Color4(255, 255, 255, 255);
            */

            switch (type)
            {
                case Direction.Right:
                    return new Color4(226, 66, 54, 255);
                case Direction.Down:
                    return new Color4(54, 99, 226, 255);
                case Direction.Left:
                    return new Color4(226, 54, 177, 255);
                case Direction.Up:
                    return new Color4(131, 226, 54, 255);
            }
            return new Color4(255, 255, 255, 255);
        }

        public static Color4 GetTypeColor(Shape type)
        {
            return new Color4(169, 188, 185, 255);
        }

        /// <summary>
        ///     get the layout color
        /// </summary>
        /// <returns></returns>
        public static Color4 GetCoopLayoutColor(Coop coop)
        {
            switch (coop)
            {
                case Coop.Both: //Both
                    return new Color4(226, 190, 122, 255);
                case Coop.LeftOnly: //Left : blue
                    return new Color4(70, 192, 206, 255);
                case Coop.RightOnly: //Right : purple
                    return new Color4(224, 80, 178, 255);
            }
            return new Color4(255, 255, 255, 255);
        }

        /// <summary>
        ///     get the layout JudgementLine color
        /// </summary>
        /// <returns></returns>
        public static Color4 GetCoopJudgementLineColor(Coop coop)
        {
            switch (coop)
            {
                case Coop.Both: //Both
                    return new Color4(100, 100, 100, 255);
                case Coop.LeftOnly: //Left : blue
                    return new Color4(70, 192, 206, 255);
                case Coop.RightOnly: //Right : purple
                    return new Color4(224, 80, 178, 255);
            }
            return new Color4(255, 255, 255, 255);
        }

        /// <summary>
        ///     RpHitObject's border co-op color
        /// </summary>
        /// <returns></returns>
        public static Color4 GetCoopHitObjectColor(Coop coop)
        {
            switch (coop)
            {
                case Coop.Both: //Both
                    return new Color4(100, 100, 100, 255);
                case Coop.LeftOnly: //Left : blue
                    return new Color4(70, 192, 206, 255);
                case Coop.RightOnly: //Right : purple
                    return new Color4(224, 80, 178, 255);
            }
            return new Color4(255, 255, 255, 255);
        }
    }
}
