using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osu.Framework.Graphics.Containers;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.Objects.Types;
using osu.Game.Rulesets.RP.Objects;
using osu.Game.Rulesets.RP.Objects.Drawables.Extension;
using osu.Game.Rulesets.RP.Objects.Drawables.Play;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Interface;
using OpenTK;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Externsion
{
    public static class GameFieldExtension
    {

        /// <summary>
        /// add any type of DrawableHitObject
        /// </summary>
        /// <param name="field"></param>
        /// <param name="drawableObject"></param>
        public static void AddDrawableRpObject(this IHasGameField field, DrawableHitObject drawableObject)
        {
            if (drawableObject is DrawableRpContainerLine drawableRpContainerLine)
            {
                AddDrawableRpContainerLine(field, drawableRpContainerLine);
            }
            else if (drawableObject is DrawableRpContainerLineGroup drawableRpContainerLineGroup)
            {
                AddDrawableRpContainerLineGroup(field, drawableRpContainerLineGroup);
            }
            else if (drawableObject is DrawableRpHitObject drawableRpHitObject)
            {
                AddDrawableRpHitObject(field, drawableRpHitObject);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public static void AddDrawableRpContainerLine(this IHasGameField field, DrawableRpContainerLine drawableRpContainerLine)
        {
            DrawableRpContainerLineGroup drawableRpContainerLineGroup = GeDrawableByRpObject<DrawableRpContainerLineGroup>(field,drawableRpContainerLine.HitObject.ParentObject);
            drawableRpContainerLineGroup.ParentGroupContainer.Add(drawableRpContainerLine);
            drawableRpContainerLineGroup.AddObject(drawableRpContainerLine);
            //
            field.ListDrawableObject.Add(drawableRpContainerLine);
        }

        public static void AddDrawableRpContainerLineGroup(this IHasGameField field, DrawableRpContainerLineGroup drawableRpContainerLineGroup)
        {
            Container container = new Container();
            drawableRpContainerLineGroup.ParentGroupContainer = container;
            container.Position = drawableRpContainerLineGroup.HitObject.Position;
            container.Rotation = drawableRpContainerLineGroup.HitObject.Rotation;
            container.Add(drawableRpContainerLineGroup);
            //
            field.ListDrawableObject.Add(drawableRpContainerLineGroup);
            field.ListGroupContainer.Add(container);
        }

        public static void AddDrawableRpHitObject(this IHasGameField field, DrawableRpHitObject drawableRpHitObject)
        {
            DrawableRpContainerLineGroup drawableRpContainerLineGroup = GeDrawableByRpObject<DrawableRpContainerLineGroup>(field,drawableRpHitObject.HitObject.ParentObject.ParentObject);
            drawableRpContainerLineGroup.ParentGroupContainer.Add(drawableRpHitObject);

            DrawableRpContainerLine drawableRpContainerLine = GeDrawableByRpObject<DrawableRpContainerLine>(field,drawableRpHitObject.HitObject.ParentObject);
            drawableRpContainerLine.AddObject(drawableRpHitObject);
            //
            field.ListDrawableObject.Add(drawableRpContainerLine);
        }

        /// <summary>
        /// get drawable by it's HitObject
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="field"></param>
        /// <param name="containerGroupObject"></param>
        /// <returns></returns>
        public static T GeDrawableByRpObject<T>(this IHasGameField field, BaseRpObject containerGroupObject) where T : DrawableBaseRpObject
        {
            foreach (var container in field.ListDrawableObject)
                if (container.HitObject == containerGroupObject)
                {
                    if(container is T matchTypeDrawableObject)
                        return matchTypeDrawableObject;
                }

            return null;
        }

        /// <summary>
        ///     get object by time
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<T> GetContainerByTime<T>(this IHasGameField field, double time) where T : DrawableBaseRpObject
        {
            foreach (var container in field.ListDrawableObject)
            {
                if (container.HitObject is IHasEndTime hasEndTimeObject)
                {
                    if (container.HitObject.StartTime <= time && hasEndTimeObject.EndTime >= time)
                        if (container is T matchTypeDrawableObject)
                            yield return matchTypeDrawableObject;
                }
                else
                {
                    if(container.HitObject.StartTime== time)
                        if (container is T matchTypeDrawableObject)
                            yield return matchTypeDrawableObject;
                }
            }
            
        }

        public static Vector2 FindObjectPosition(this IHasGameField field, DrawableBaseRpObject drawableRpHitObject)
        {
            return new Vector2(0,0);
        }
    }
}
