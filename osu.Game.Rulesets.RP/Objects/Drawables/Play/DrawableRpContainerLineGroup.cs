// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Framework.Graphics;
using osu.Game.Rulesets.RP.Objects.Drawables.Play.Interface;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.ContainerComponent;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.ContainerComponent.ContainerLineGroup;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.RpContainer;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.RpContainer.Component;
using OpenTK;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Play
{
    /// <summary>
    ///     匁E��RP物件
    /// </summary>
    public class DrawableRpContainerLineGroup : DrawableBaseContainableObject<IHasTemplate> 
    {
        /// <summary>
        /// </summary>
        public new RpContainerLineGroup HitObject
        {
            get { return (RpContainerLineGroup)base.HitObject; }
        }

        private bool _startFadeont;

        /// <summary>
        /// </summary>
        /// <param name="hitObject"></param>
        public DrawableRpContainerLineGroup(BaseRpObject hitObject)
            : base(hitObject)
        {
            Position = HitObject.Position;
        }

        //建構樣板物件
        protected override void ConstructObject()
        {
            //背景
            Components.Add(new ContainerBackground(HitObject));
            //節拍黁E
            Components.Add(new ContainerDecisionLine(HitObject));
            ///開始結束黁E
            Components.Add(new ContainerStartEnd(HitObject));
            //按壁E
            Components.Add(new ContainerLongPressDraw(HitObject));
            //持E��E
            Components.Add(new ContainerBeatLine(HitObject));

            Components.Add(new ContainerGroupContainComponent(HitObject));
        }


        /// <summary>
        ///     更新初始狀慁E
        /// </summary>
        protected override void UpdateInitialState()
        {
            base.UpdateInitialState();
        }

        /// <summary>
        ///     這裡估計會一直更新
        /// </summary>
        protected override void UpdatePreemptState()
        {
            //BaseRpObjectTemplate single = (BaseRpObjectTemplate)Template;
            //FadeIn(FadeInTime);
            //開始特效
            //Template.FadeIn(FadeInTime);

            base.UpdatePreemptState();
        }

        /// <summary>
        ///     持續一直更新物件
        /// </summary>
        protected override void Update()
        {
            base.Update();

            //如果時間趁E��就執衁E
            if (HitObject.EndTime < Time.Current && !_startFadeont)
            {
                _startFadeont = true;
                this.FadeOut(FadeOutTime);
                Template.FadeOut(FadeOutTime);
            }
        }


        /// <summary>
        ///     從這邊去更新狀慁E
        /// </summary>
        /// <param name="userTriggered"></param>
        protected override void CheckJudgement(bool userTriggered)
        {
        }
    }
}
