using System;
namespace osu.Game.Rulesets.Karaoke.Objects.Extension
{
    public static class KaraokeObjectExtension
    {
        /// <summary>
        /// Gets the progress by time.
        /// </summary>
        /// <returns>The progress by time.</returns>
        public static double GetProgressByTime(this KaraokeObject karaokeObject,double nowTime)
        {
            
            //at least has one point
            if(karaokeObject.IsInTime(nowTime) && karaokeObject.ListProgressPoint.Count>0)
            {
                double absoluteTime = nowTime - karaokeObject.StartTime;
                var listPoints = karaokeObject.ListProgressPoint;

                for (int i = 0; i < listPoints.Count;i++)
                {
                    //means that progress is between this and last objects
                    if(listPoints[i].RelativeTime>absoluteTime)
                    {
                        var lastProgress = i > 1 ? listPoints[i - 1] : new ProgressPoint(0,0);
                        var thisObject = listPoints[i];

                        //return
                        return KaraokeObjectExtension.GetPositionBetweenTowObjects(lastProgress, thisObject, nowTime);
                    }
                }

                //if not any,means it is the last, return karaokeObject's width as progress
                return karaokeObject.Width;
            }

            return -1;
        }

        /// <summary>
        /// Times the is in time.
        /// </summary>
        /// <returns><c>true</c>, if is in time was timed, <c>false</c> otherwise.</returns>
        /// <param name="karaokeObject">Karaoke object.</param>
        /// <param name="nowTime">Now time.</param>
        public static bool IsInTime(this KaraokeObject karaokeObject, double nowTime)
        {
            double absoluteTime = nowTime - karaokeObject.StartTime;
            if (absoluteTime < 0 && absoluteTime > karaokeObject.Duration)
            {
                return true;
            }
            return false;
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
    }
}
