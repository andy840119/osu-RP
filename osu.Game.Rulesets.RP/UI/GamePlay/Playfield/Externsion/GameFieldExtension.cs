// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System;
using System.Collections.Generic;
using osu.Framework.Graphics.Containers;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.Objects.Types;
using osu.Game.Rulesets.RP.Extension;
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
            else if (drawableObject is DrawableRpContainerGroup drawableRpContainerLineGroup)
            {
                AddDrawableRpContainerLineGroup(field, drawableRpContainerLineGroup);
            }
            else if (drawableObject is DrawableRpHit drawableRpHitObject)
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
            DrawableRpContainerGroup drawableRpContainerGroup = GeDrawableByRpObject<DrawableRpContainerGroup>(field, drawableRpContainerLine.HitObject.ParentObject);
            drawableRpContainerGroup.GameFieldContainer.Add(drawableRpContainerLine);
            drawableRpContainerGroup.AddObject(drawableRpContainerLine);
            drawableRpContainerLine.ParentObject = drawableRpContainerGroup;
            //
            field.ListDrawableObject.Add(drawableRpContainerLine);
        }

        public static void AddDrawableRpContainerLineGroup(this IHasGameField field, DrawableRpContainerGroup drawableRpContainerGroup)
        {
            Container container = new Container();
            drawableRpContainerGroup.GameFieldContainer = container;
            container.Position = drawableRpContainerGroup.HitObject.Position;
            container.Rotation = drawableRpContainerGroup.HitObject.Rotation;
            container.Add(drawableRpContainerGroup);
            //
            field.ListDrawableObject.Add(drawableRpContainerGroup);
            field.ListGroupContainer.Add(container);
        }

        public static void AddDrawableRpHitObject(this IHasGameField field, DrawableRpHit drawableRpHit)
        {
            DrawableRpContainerGroup drawableRpContainerGroup = GeDrawableByRpObject<DrawableRpContainerGroup>(field, drawableRpHit.HitObject.ParentObject.ParentObject);
            drawableRpContainerGroup.GameFieldContainer.Add(drawableRpHit);

            DrawableRpContainerLine drawableRpContainerLine = GeDrawableByRpObject<DrawableRpContainerLine>(field, drawableRpHit.HitObject.ParentObject);
            drawableRpContainerLine.AddObject(drawableRpHit);
            drawableRpHit.ParentObject = drawableRpContainerLine;
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
                    if (container is T matchTypeDrawableObject)
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
                    if (container.HitObject.StartTime == time)
                        if (container is T matchTypeDrawableObject)
                            yield return matchTypeDrawableObject;
                }
            }
        }

        /// <summary>
        /// get actual position by object
        /// </summary>
        /// <param name="field"></param>
        /// <param name="drawableRpHitObject"></param>
        /// <returns></returns>
        public static Vector2 FindObjectPosition(this IHasGameField field, DrawableBaseRpObject drawableRpHitObject)
        {
            if (drawableRpHitObject is DrawableRpContainerGroup group)
            {
                return group.GameFieldContainer.Position;
            }
            else if (drawableRpHitObject is DrawableRpContainerLine line)
            {
                var grpupContainer = GeDrawableByRpObject<DrawableRpContainerGroup>(field, line.HitObject.ParentObject).GameFieldContainer;
                return grpupContainer.Position + line.Position.Rotate(grpupContainer.Rotation);
            }
            else if (drawableRpHitObject is DrawableRpRectangleHold lineHold)
            {
                //TODO : implement
                return new Vector2(0, 0);
            }
            else if (drawableRpHitObject is DrawableRpHit hit)
            {
                var grpupContainer = GeDrawableByRpObject<DrawableRpContainerGroup>(field, hit.HitObject.ParentObject.ParentObject).GameFieldContainer;
                return grpupContainer.Position + hit.Position.Rotate(grpupContainer.Rotation);
            }
            else if (drawableRpHitObject is DrawableRpHold hold)
            {
                var grpupContainer = GeDrawableByRpObject<DrawableRpContainerGroup>(field, hold.HitObject.ParentObject.ParentObject).GameFieldContainer;
                return grpupContainer.Position + hold.Position.Rotate(grpupContainer.Rotation);
            }

            return new Vector2(0, 0);
        }
    }
}
