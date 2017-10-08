// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using System.Linq;
using osu.Game.Rulesets.RP.Objects.Drawables.Play;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.ContainerBackground;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects
{
    /// <summary>
    ///     放置打擊物件的layout
    /// </summary>
    internal class HitObjectLayout : BaseGamePlayLayout
    {
        /// <summary>
        /// </summary>
        public ContainerBackgroundLayout ContainerBackgroundLayout;

        /// <summary>
        ///     那些找不到Container 的物件
        /// </summary>
        public List<DrawableBaseRpObject> _listMissingObject = new List<DrawableBaseRpObject>();

        /// <summary>
        ///     曾加速度
        /// </summary>
        /// <param name="drawObject"></param>
        public void AddDrawObject(DrawableBaseRpObject drawObject)
        {
            var drawableHitObject = drawObject as DrawableBaseRpHitableObject;
            AddDrawableBaseHitObject(drawableHitObject);
        }

        /// <summary>
        ///     增加物件進來
        /// </summary>
        /// <param name="drawableHitObject"></param>
        public void AddDrawableBaseHitObject(DrawableBaseRpHitableObject drawableHitObject)
        {
            var containerIndex = drawableHitObject.HitObject.RelativeContainerLineGroupIndex;
            var layoutIndex = drawableHitObject.HitObject.RelativeContainerLineIndex;

            //如果是背景按壓物件
            //if (drawableHitObject is DrawableRpContainerLineHoldObject)
            //     ContainerBackgroundLayout.GetContainerByTime(((DrawableBaseRpObject)drawableHitObject).HitObject.StartTime).ElementAt(containerIndex).Template.AddObject(drawableHitObject as DrawableRpContainerLineHoldObject);
            //else
            //    ContainerBackgroundLayout.GetContainerByTime(((DrawableBaseRpObject)drawableHitObject).HitObject.StartTime).ElementAt(containerIndex).Template.ListContainObject[layoutIndex].AddObject(drawableHitObject);


            try
            {
                //double time = ((DrawableBaseRpObject)drawableHitObject).HitObject.StartTime;
                //DrawableRpContainerLineGroup lineGroup = ContainerBackgroundLayout.GetContainerByTime(time).ElementAt(containerIndex);
                DrawableRpContainerLine line = ContainerBackgroundLayout.GetContainerLineByRpObject(drawableHitObject.HitObject.ParentObject);
                line.AddObject(drawableHitObject);
            }
            catch
            {
                _listMissingObject.Add(drawableHitObject);
            }
        }

        /// <summary>
        ///     取得時間點上的所有打擊物件
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DrawableBaseRpObject> GetHitObjectByTime(double time)
        {
            var listContainer = ContainerBackgroundLayout.GetContainerByTime(time);
            if (listContainer.Any())
                foreach (var container in listContainer)
                {
                    int offset = 50;

                    //Hold
                    //foreach (var singleHold in container.Template.ContainerLongPressDraw.ListPressObject)
                    //    if (((DrawableBaseRpObject)singleHold).HitObject.StartTime <= time && ((DrawableBaseRpObject)singleHold).HitObject.EndTime >= time)
                    //        yield return container;

                    //RpHitObject
                    foreach (var layoutTemplate in container.ListContainObject)
                    foreach (DrawableRpContainerLineHoldObject hitObject in layoutTemplate.ListContainObject)
                        if (((DrawableBaseRpObject)hitObject).HitObject.StartTime <= time + offset && ((DrawableBaseRpObject)hitObject).HitObject.StartTime >= time - offset)
                            yield return container;
                }
        }
    }
}
