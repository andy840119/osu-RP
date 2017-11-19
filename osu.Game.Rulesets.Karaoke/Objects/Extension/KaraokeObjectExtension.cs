using System;
using System.Linq;

namespace osu.Game.Rulesets.Karaoke.Objects.Extension
{
    public static class KaraokeObjectExtension
    {
        /// <summary>
        /// Gets the progress by time.
        /// </summary>
        /// <returns>The progress by time.</returns>
        public static double GetProgressByTime(this KaraokeObject karaokeObject,double nowRelativeTime)
        {
            
            //at least has one point
            if(karaokeObject.IsInTime(nowRelativeTime) && karaokeObject.ListProgressPoint.Count>0)
            {
                var listPoints = karaokeObject.ListProgressPoint;

                for (int i = 0; i < listPoints.Count;i++)
                {
                    //means that progress is between this and last objects
                    if(listPoints[i].RelativeTime> nowRelativeTime)
                    {
                        var lastProgress = i >= 1 ? listPoints[i - 1] : new ProgressPoint(0,0);
                        var thisObject = listPoints[i];

                        if (lastProgress.X == thisObject.X)
                            return lastProgress.X;

                        if (lastProgress.RelativeTime == thisObject.RelativeTime)
                            return lastProgress.X;

                        double relativeToThisAndLastTime = nowRelativeTime - lastProgress.RelativeTime;

                        //return
                        return lastProgress.X + KaraokeObjectExtension.GetPositionBetweenTowObjects(lastProgress, thisObject, relativeToThisAndLastTime);
                    }
                }

                //if not any,means it is the last, return karaokeObject's width as progress
                return listPoints.Last().X;
            }

            return 0;
        }

        /// <summary>
        /// Times the is in time.
        /// </summary>
        /// <returns><c>true</c>, if is in time was timed, <c>false</c> otherwise.</returns>
        /// <param name="karaokeObject">Karaoke object.</param>
        /// <param name="nowRelativeTime">Now time.</param>
        public static bool IsInTime(this KaraokeObject karaokeObject, double nowRelativeTime)
        {
            if (nowRelativeTime < 0 && nowRelativeTime > karaokeObject.Duration)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// get delta position from two objects and delta time
        /// </summary>
        /// <returns>The position between tow objects.</returns>
        /// <param name="firstObject">First object.</param>
        /// <param name="lastObejct">Last obejct.</param>
        /// <param name="time">Time.</param>
        public static float GetPositionBetweenTowObjects(ProgressPoint firstObject,ProgressPoint lastObejct,double time)
        {
            return (lastObejct.X - firstObject.X) / (float)(lastObejct.RelativeTime - firstObject.RelativeTime) * (float)time;
        }

        /// <summary>
        /// will filter if has same languate
        /// </summary>
        /// <param name="karaokeObject">Karaoke object.</param>
        public static bool AddNewTranslate(this KaraokeObject karaokeObject,KaraokeTranslateString translateString)
        {
            return false;
        }

        /// <summary>
        /// will check if this progress point is valid
        /// </summary>
        /// <returns><c>true</c>, if progress point was added, <c>false</c> otherwise.</returns>
        /// <param name="karaokeObject">Karaoke object.</param>
        public static bool AddProgressPoint(this KaraokeObject karaokeObject, ProgressPoint point)
        {
            //TODO : filter
            if (karaokeObject.ListProgressPoint.Any(x => x.X == point.X))
                return false;
            if (karaokeObject.ListProgressPoint.Any(x => x.RelativeTime == point.RelativeTime))
                return false;

            karaokeObject.ListProgressPoint.Add(point);
            karaokeObject.SortProgressPoint();
            return true;
        }

        /// <summary>
        /// sorting by position and time should be higher
        /// </summary>
        public static void SortProgressPoint(this KaraokeObject karaokeObject)
        {
            // from small to large
            karaokeObject.ListProgressPoint = karaokeObject.ListProgressPoint.OrderBy(x => x.RelativeTime).ToList();
        }
    }
}
