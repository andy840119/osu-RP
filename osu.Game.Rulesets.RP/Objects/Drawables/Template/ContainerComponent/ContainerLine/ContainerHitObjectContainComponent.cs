using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osu.Game.Rulesets.RP.Objects.Drawables.Play.Interface;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.Calculator;
using OpenTK;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Template.ContainerComponent.ContainerLine
{
    public class ContainerHitObjectContainComponent : ContainerContainComponent<IHasTemplate>
    {
        public ContainerHitObjectContainComponent(RpContainerLineGroup hitObject) : base(hitObject)
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

        /// <summary>
        ///     更新物件
        /// </summary>
        private void UpdateHitObject()
        {
            foreach (var hitObject in ListContainObject)
                hitObject.Template.Position = new Vector2(100, 100);
        }
    }
}
