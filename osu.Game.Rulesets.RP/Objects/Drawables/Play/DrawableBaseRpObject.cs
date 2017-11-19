// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using System.Linq;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.RP.Judgements;
using osu.Game.Rulesets.RP.Objects.Drawables.Component.Interface;
using osu.Game.Rulesets.RP.Objects.Drawables.Extension;
using osu.Game.Rulesets.RP.Objects.Drawables.Interface;
using osu.Game.Rulesets.RP.Objects.Interface;
using OpenTK.Graphics;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Play
{
    public class DrawableBaseRpObject : DrawableHitObject<BaseRpObject>, IHasTemplate
    {
        public IHasTemplate ParentObject { get; set; }
        public List<IComponentBase> Components { get; set; }
        public BaseRpObject RpObject => HitObject;
        public Container DrawableObject => this;

        //FadeInTime
        public virtual float FadeInTime => 200;

        //FadeOutTime
        public virtual float FadeOutTime => 300;

        public virtual float PreemptTime => HitObject.PreemptTime;

        public DrawableBaseRpObject(BaseRpObject hitObject)
            : base(hitObject)
        {
            AccentColour = new Color4(255, 255, 255, 255);
            Alpha = 0;

            Components = new List<IComponentBase>();

            Origin = Anchor.Centre;
            //Position = new Vector2(100, 100);

            //initial component
            ConstructObject();
            //initial template and 
            InitialChildObject();
        }

        //建構樣板物件
        protected virtual void ConstructObject()
        {
        }

        //建構
        protected void InitialChildObject()
        {
            this.InitialTemplate();
        }

        protected override void UpdateState(ArmedState state)
        {
            FinishTransforms();

            //var relativeStartTime = (HitObject is IHasParentID) ? (HitObject as IHasParentID).RelativeToParentStartTime : HitObject.StartTime;

            //if ((HitObject is IHasParentID))
            //{
            //    int a = 0;
            //}

            using (BeginAbsoluteSequence(HitObject.StartTime - PreemptTime, true))
            {
                UpdateInitialState();

                UpdatePreemptState();

                using (BeginDelayedSequence(PreemptTime + (Judgements.FirstOrDefault()?.TimeOffset ?? 0), true))
                    UpdateCurrentState(state);
            }
        }

        /// <summary>
        /// initial state
        /// </summary>
        protected virtual void UpdateInitialState()
        {
            Hide();
        }

        //正在準備的時候
        protected virtual void UpdatePreemptState()
        {
            this.FadeIn(FadeInTime);
            //Fadein
            this.FadeInComponents(FadeInTime);
        }

        /// <summary>
        ///     更新狀態
        /// </summary>
        /// <param name="state"></param>
        protected virtual void UpdateCurrentState(ArmedState state)
        {
            //TODO :  修正
            double duration = ((HitObject as IHasEndTime)?.EndTime ?? HitObject.StartTime) - HitObject.StartTime;

            switch (state)
            {
                case ArmedState.Miss:
                    //this.Delay(duration + PreemptTime).FadeOut(FadeOutTime);
                    //this.FadeOutComponents(FadeOutTime);

                    //通知judgement
                    UpdateJudgement(true);
                    Expire(true);
                    break;

                default:

                    this.Delay(duration + PreemptTime).FadeOut(FadeOutTime);
                    //this.FadeOutComponents(FadeOutTime);

                    using (BeginDelayedSequence(duration + PreemptTime, true))
                    {
                        this.FadeOutComponents(FadeOutTime);
                    }

                    //Expire(true);
                    break;
            }
        }

        //CheckJudgement
        protected override void CheckForJudgements(bool userTriggered, double timeOffset)
        {
            //TODO : 如果需要修正
            AddJudgement(new RpJudgement()
            {
                Result = HitResult.Good,
                RpObject = this,
            });
        }

        /// <summary>
        ///     持續一直更新物件
        /// </summary>
        protected override void Update()
        {
            base.Update();
            //更新物件位置
            this.UpdateTemplate(Time.Current);
        }
    }
}
