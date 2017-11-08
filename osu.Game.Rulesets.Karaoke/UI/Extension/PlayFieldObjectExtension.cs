using osu.Game.Rulesets.Karaoke.Objects;
using osu.Game.Rulesets.Karaoke.Objects.Drawables;
using osu.Game.Rulesets.Karaoke.UI.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osu.Game.Rulesets.Karaoke.UI.Extension
{
    public static class PlayFieldObjectExtension
    {
        

        /// <summary>
        /// update combo by last object
        /// </summary>
        /// <param name="karaokeField"></param>
        /// <param name="karaokeObject"></param>
        public static void UpdateObjectCombo(this IAmKaraokeField karaokeField, KaraokeObject karaokeObject)
        {

        }

        /// <summary>
        /// update position
        /// </summary>
        /// <param name="karaokeField"></param>
        /// <param name="karaokeObject"></param>
        public static void UpdateObjectAutomaticallyPosition(this IAmKaraokeField karaokeField, DrawableKaraokeObject drawableKaraokeObject)
        {
            int index = karaokeField.ListObjects().IndexOf(drawableKaraokeObject.HitObject);
            if (index % 2 == 0)
                drawableKaraokeObject.Position = new OpenTK.Vector2(0, 200);
            else
                drawableKaraokeObject.Position = new OpenTK.Vector2(200, 270);
        }

        /// <summary>
        /// update the preemptive time
        /// </summary>
        /// <param name="karaokeField"></param>
        /// <param name="karaokeObject"></param>
        public static void UpdateObjectPreemptiveTime(this IAmKaraokeField karaokeField, KaraokeObject karaokeObject)
        {

        }

        public static List<KaraokeObject> ListObjects(this IAmKaraokeField karaokeField)
        {
            return karaokeField.KaraokeRulesetContainer.Beatmap.HitObjects;
        }

    }
}
