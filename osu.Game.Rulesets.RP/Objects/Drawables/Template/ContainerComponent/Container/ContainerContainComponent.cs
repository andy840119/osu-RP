using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osu.Game.Rulesets.RP.Objects.Drawables.Play;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.Component;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.ContainerComponent.Interface;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.RpContainer.Component;
using OpenTK;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Template.ContainerComponent
{
    /// <summary>
    /// 可以放置物件的地方
    /// Base compojnent class
    /// </summary>
    public class ContainerContainComponent<T> :  ComponentBaseContainer, ICanContainObject<T> , IComponentBase  where T : DrawableBaseRpObject
    {
        public ContainerContainComponent(RpContainerLineGroup hitObject) : base(hitObject)
        {
            ListContainObject = new BindingList<T>();
        }

        public BindingList<T> ListContainObject { get; set; }


        public void AddObject(T rpObject)
        {
            rpObject.Position = GetRowPosition();

            //add object
            if (!ListContainObject.Contains(rpObject))
                ListContainObject.Add(rpObject);

            //update Height
            //UpdateContainerHeight();
        }

        public void AddObject(List<T> dragObject)
        {
            foreach (T single in dragObject)
            {
                AddObject(single);
            }
        }

        public void RemoveObject(T dragObject)
        {
            if (ListContainObject.Contains(dragObject))
                ListContainObject.Remove(dragObject);
           
        }

        public void RemoveObject(List<T> dragObject)
        {
            foreach (T single in dragObject)
            {
                RemoveObject(single);
            }
        }

        //get row position
        public Vector2 GetRowPosition()
        {
            return new Vector2();
            //return RpObject.Position;
        }

        public void FadeIn(double time = 0)
        {
            //throw new NotImplementedException();
        }

        public void FadeOut(double time = 0)
        {
            //throw new NotImplementedException();
        }
    }
}
