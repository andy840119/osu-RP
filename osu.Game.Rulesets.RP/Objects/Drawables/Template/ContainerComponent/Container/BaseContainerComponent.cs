// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Framework.Graphics.Containers;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.Calculator;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.Component;
using OpenTK;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Template.RpContainer.Component
{
    public class ComponentBaseContainer :  Container
    {
        /// <summary>
        /// </summary>
        public BaseRpObject HitObject { get; set; }

        public void Initial()
        {
            //throw new System.NotImplementedException();
        }

        /// <summary>
        ///     負責計算物件在時間點該有的位置
        /// </summary>
        protected readonly ContainerLayoutPositionCounter _positionCounter = new ContainerLayoutPositionCounter();

        public ComponentBaseContainer(RpContainerLineGroup hitObject)
        {
            HitObject = hitObject;
            InitialObject();
            InitialChild();
        }

        /// <summary>
        ///     更新新的 Layout數量
        /// </summary>
        /// <param name="newLayerNumber"></param>
        public virtual void UpdateLayerNumber()
        {
            //資料從 ParentObject 裡面讀取
        }

        /// <summary>
        ///     如果更新了開始或是結束的時間
        /// </summary>
        public virtual void UpdateTime()
        {
        }


        /// <summary>
        ///     初始化所有顯示物件
        /// </summary>
        protected virtual void InitialObject(int layerCount = 1)
        {
        }

        /// <summary>
        ///     初始化所有顯示物件
        /// </summary>
        protected virtual void InitialChild()
        {
        }

        /// <summary>
        ///     根據時間點計算物件位置
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        protected Vector2 CalculatePosition(double time)
        {
            return new Vector2(_positionCounter.GetPosition(time, HitObject.Velocity), 0);
        }

        /// <summary>
        ///     取得間隔時間
        /// </summary>
        /// <returns></returns>
        protected double GetDeltaBeatTime()
        {
            return 1000 * 60 / HitObject.BPM;
        }
    }
}
