// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using System.Linq;
using osu.Game.Rulesets.RP.Objects.Drawables.Play;
using OpenTK;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjectsConnector
{
    /// <summary>
    ///     ópò“òAê⁄ï®åèìIê¸
    /// </summary>
    internal class HitObjectConnector : ConnectionRenderer<DrawableBaseRpHitableObject>
    {
        /// <summary>
        ///     Determines how much space there is between points.
        /// </summary>
        public int PointDistance
        {
            get { return pointDistance; }
            set
            {
                if (pointDistance == value) return;
                pointDistance = value;
                update();
            }
        }

        /// <summary>
        ///     Follow points to the next hitobject start appearing for this many milliseconds before an hitobject's end time.
        /// </summary>
        public int PreEmpt
        {
            get { return preEmpt; }
            set
            {
                if (preEmpt == value) return;
                preEmpt = value;
                update();
            }
        }

        public override IEnumerable<DrawableBaseRpHitableObject> HitObjects
        {
            get { return hitObjects; }
            set
            {
                hitObjects = value;
                update();
            }
        }

        /// <summary>
        ///     will scan when the beatmap converted Finish
        ///     add all the same time's RpHitObject's Tuple will place in there
        /// </summary>
        private readonly List<List<DrawableBaseRpHitableObject>> ListTuple = new List<List<DrawableBaseRpHitableObject>>();

        /// <summary>
        /// </summary>
        private int pointDistance = 32;

        private int preEmpt = 800;

        private IEnumerable<DrawableBaseRpHitableObject> hitObjects;

        /// <summary>
        ///     Add all the same time's RpHitObject's Tuple will place in there
        /// </summary>
        public override void ScanSameTuple()
        {
            DrawableBaseRpHitableObject lastObjectTime = null;
            ListTuple.Clear();

            foreach (var currHitObject in hitObjects)
            {
                if (lastObjectTime != null && ((DrawableBaseRpObject)currHitObject).HitObject.StartTime == ((DrawableBaseRpObject)lastObjectTime).HitObject.StartTime)
                    if (ListTuple.Count > 0 && ((DrawableBaseRpObject)ListTuple[ListTuple.Count - 1][0]).HitObject.StartTime
                        == ((DrawableBaseRpObject)lastObjectTime).HitObject.StartTime) //exist tuple
                    {
                        ListTuple[ListTuple.Count - 1].Add(currHitObject);
                    }
                    else //new tuple
                    {
                        var sligleTuple = new List<DrawableBaseRpHitableObject>();
                        sligleTuple.Add(lastObjectTime);
                        sligleTuple.Add(currHitObject);
                        ListTuple.Add(sligleTuple);
                    }
                lastObjectTime = currHitObject;
            }

            update();
        }


        /// <summary>
        ///     Find the same time RpHitObject
        ///     ///
        /// </summary>
        private void update()
        {
            Clear();
            if (hitObjects == null)
                return;

            for (var i = 0; i < ListTuple.Count(); i++)
            {
                var listPosition = new List<Vector2>();
                for (var j = 0; j < ListTuple[i].Count; j++)
                    listPosition.Add(ListTuple[i][j].Position);
                var startTime = ((DrawableBaseRpObject)ListTuple[i][0]).HitObject.StartTime - ListTuple[i][0].PreemptTime;
                var endTime = ((DrawableBaseRpObject)ListTuple[i][0]).HitObject.StartTime;
                AddLine(listPosition, startTime, endTime);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="startPosition"></param>
        /// <param name="endPosition"></param>
        private void AddLine(List<Vector2> listPositoin, double startTime, double endTime)
        {
            var rpHitMulitpleObjectConnectionLine = new RpHitMulitpleObjectConnectionLine();
            rpHitMulitpleObjectConnectionLine.SetListLine(listPositoin);
            rpHitMulitpleObjectConnectionLine.StartTime = startTime;
            rpHitMulitpleObjectConnectionLine.EndTime = endTime;
            Add(rpHitMulitpleObjectConnectionLine);
        }
    }
}
