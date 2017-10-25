using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace osu.Game.Rulesets.RP.Extension
{
    static class Vector2Extension
    {
        public static Vector2 Rotate(this Vector2 targetVector2, float rotateAngel)
        {
            float total = (float)Math.Sqrt(Math.Pow(targetVector2.X, 2) + Math.Pow(targetVector2.Y, 2));
            var position= new Vector2(total * (float)Math.Cos(rotateAngel), total * (float)Math.Sin(rotateAngel));
            return position;
        }
    }
}
