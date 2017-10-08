// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

namespace osu.Game.Rulesets.RP.Objects.Drawables.Template.Interface
{
    public interface IComponentDragable<T>
    {
        /// <summary>
        /// when the object is Drag by mouse and not drag out of the field
        /// </summary>
        void OnGragHold();

        //The Object is dragging and not decide where to place
        void OnGrag();

        //Object that has a place can be place
        void OnDragDecidePlace();

        //Grag release and the object is set
        void DragDown();

        //if remove this Dragable object,call this
        void OnThisRemove();

        //remove single Object
        //void Remove(T);
    }
}
