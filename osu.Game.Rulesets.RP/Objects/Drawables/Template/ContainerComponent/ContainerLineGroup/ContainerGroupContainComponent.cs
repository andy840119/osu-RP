using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osu.Game.Rulesets.RP.Objects.Drawables.Play.Interface;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.Calculator;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.RpContainer.Component;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Template.ContainerComponent.ContainerLineGroup
{
    internal class ContainerGroupContainComponent : ContainerContainComponent<IHasTemplate>
    {
        public ContainerGroupContainComponent(RpContainerLineGroup hitObject) : base(hitObject)
        {

        }

        /// <summary>
        ///     負責計算物件在時間點該有的位置
        /// </summary>
        private readonly ContainerLayoutPositionCounter _positionCounter = new ContainerLayoutPositionCounter();

        /// <summary>
        ///     計算物件皁E��關高度和Height位置
        /// </summary>
        private readonly ContainerLayoutHeightCalculator _heightCalculator = new ContainerLayoutHeightCalculator();

        //call this to calculate new height
        public void UpdateContainerHeight()
        {
            _heightCalculator.LayoutCount = ListContainObject.Count;
            var newHeight = _heightCalculator.GetContainerHeight();
            ChangeHeight(newHeight);
        }

        //if update new height
        public void ChangeHeight(float newHeight)
        {
            for(int i=0;i< ListContainObject.Count;i++)
            foreach (IChangeableContainerComponent single in ListContainObject[i].Template.Components.Where(n => n is IChangeableContainerComponent))
            {
                single.ChangeHeight(newHeight);
            }
        }
    }
}
