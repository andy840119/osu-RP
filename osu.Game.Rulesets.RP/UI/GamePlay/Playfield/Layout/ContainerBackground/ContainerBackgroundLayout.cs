// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using osu.Framework.Graphics;
using osu.Game.Rulesets.RP.Objects;
using osu.Game.Rulesets.RP.Objects.Drawables.Extension;
using osu.Game.Rulesets.RP.Objects.Drawables.Play;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.ContainerBackground
{
    /// <summary>
    ///     ïâê”ï˙íuîwåiö§ï–
    ///     DrawableContainer
    /// </summary>
    internal class ContainerBackgroundLayout : BaseGamePlayLayout
    {
        /// <summary>
        ///     ContainerGroup
        /// </summary>
        private List<DrawableRpContainerLineGroup> _listContainer = new List<DrawableRpContainerLineGroup>();

        public ContainerBackgroundLayout()
        {
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
        }

        /// <summary>
        ///     ˙ùâ¡Container
        /// </summary>
        public void AddContainerGroup(DrawableRpContainerLineGroup drawableContainer)
        {
            //ContainerGroup
            _listContainer.Add(drawableContainer);
            //Add(drawableContainer);

            //ContainerLine
            foreach (var layout in drawableContainer.HitObject.ListContainObject)
            {
                //andy840119 : cancel from here
                //DrawableRpContainerLine layoutLine = new DrawableRpContainerLine(layout);
                //drawableContainer.AddObject(layoutLine);

                //Add(layoutLine);
            }
        }

        /// <summary>
        ///     ˙ùâ¡Container
        /// </summary>
        public void AddContainerLine(DrawableRpContainerLine drawableContainerLine)
        {
            DrawableRpContainerLineGroup drawableContainer = GetGroupByRpObject((drawableContainerLine.HitObject).ParentObject);
            drawableContainer.AddObject(drawableContainerLine);
          
        }

        /// <summary>
        ///     ç™ùüéûä‘éÊìæéûä‘Íyè„ìIContainer
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DrawableRpContainerLineGroup> GetContainerByTime(double time)
        {
            foreach (var container in _listContainer)
                if (container.HitObject.StartTime <= time && container.HitObject.EndTime >= time)
                    yield return container;
        }

        public DrawableRpContainerLineGroup GetGroupByRpObject(RpContainerLineGroup containerGroupObject)
        {
            foreach (var container in _listContainer)
                if (container.HitObject == containerGroupObject)
                    return container;

            return null;
        }

        public DrawableRpContainerLine GetContainerLineByRpObject(RpContainerLine containerLineObject)
        {
            DrawableRpContainerLineGroup targetGroup = GetGroupByRpObject(containerLineObject.ParentObject);
            foreach (var single in targetGroup.ListContainObject())
            {
                if (single.Template.RpObject == containerLineObject)
                    return single as DrawableRpContainerLine;
            }

            return null;
        }
    }
}
