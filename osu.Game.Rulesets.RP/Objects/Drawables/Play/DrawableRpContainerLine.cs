// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Framework.Graphics;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.RP.Objects.Drawables.Component;
using osu.Game.Rulesets.RP.Objects.Drawables.Extension;
using osu.Game.Rulesets.RP.Objects.Drawables.Interface;
using osu.Game.Rulesets.RP.Objects.Interface;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Play
{
    public class DrawableRpContainerLine : DrawableBaseRpObject, ICanContainObject
    {
        /// <summary>
        /// </summary>
        public new RpContainerLine HitObject
        {
            get { return (RpContainerLine)base.HitObject; }
        }

        /// <summary>
        /// </summary>
        /// <param name="hitObject"></param>
        public DrawableRpContainerLine(BaseRpObject hitObject)
            : base(hitObject)
        {
        }

        //建構樣板物件
        protected override void ConstructObject()
        {
            //背景
            Components.Add(new ContainerLineBackground());
            Components.Add(new ContainerLineBeatLine());
            Components.Add(new ContainerLineStartEnd());
            Components.Add(new ContainerLineContainArea());
            Components.Add(new ContainerLineJudgementLine());
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
            base.UpdatePreemptState();
        }

        /// <summary>
        ///     持續一直更新物件
        /// </summary>
        protected override void Update()
        {
            base.Update();
        }

        protected override void UpdateCurrentState(ArmedState state)
        {
            //TODO :  修正
            double duration = ((HitObject as IHasEndTime)?.EndTime ?? HitObject.StartTime) - HitObject.StartTime;

            switch (state)
            {
                case ArmedState.Idle:
                    this.Delay(duration + PreemptTime).FadeOut(FadeOutTime);

                    Expire(true);
                    break;
                case ArmedState.Miss:
                    this.Delay(duration + PreemptTime).FadeOut(FadeOutTime);
                    //通知judgement
                    UpdateJudgement(true);
                    Expire(true);
                    break;
                case ArmedState.Hit:

                    this.Delay(duration + PreemptTime).FadeOut(FadeOutTime);

                    //TODO : 沒有用
                    //delay
                    this.ComponentDelay(duration + PreemptTime).FadeInComponents(FadeOutTime);

                    Expire(true);
                    break;
            }
        }
    }
}
