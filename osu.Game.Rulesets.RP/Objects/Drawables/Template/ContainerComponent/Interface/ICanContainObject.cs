using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osu.Game.Rulesets.RP.Objects.Drawables.Play;
using osu.Game.Rulesets.RP.Objects.Drawables.Play.Interface;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Template.ContainerComponent.Interface
{
    public interface ICanContainObject<T> where T : IHasTemplate
    {
        BindingList<T> ListContainObject { get; set; }


        void AddObject(T rpObject);

        void AddObject(List<T> dragObject);

        void RemoveObject(T dragObject);

        void RemoveObject(List<T> dragObject);
    }
}
