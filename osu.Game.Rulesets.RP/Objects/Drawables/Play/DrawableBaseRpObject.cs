// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Input.Bindings;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.RP.Input;
using osu.Game.Rulesets.RP.Judgements;
using osu.Game.Rulesets.RP.Objects.Drawables.Template;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.Component;
using OpenTK;
using OpenTK.Graphics;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Play
{
    public class DrawableBaseRpObject : DrawableHitObject<BaseRpObject, RpJudgement>
    {
        public List<IComponentBase> Components = new List<IComponentBase>();

        //FadeInTime
        public virtual float FadeInTime => 200;

        //FadeOutTime
        public virtual float FadeOutTime => 300;

        public virtual float PreemptTime => HitObject.PreemptTime;

        /// <summary>
        ///     樣板，把物件綁上去就對了
        /// </summary>
        public Template.Template Template { get; set; }

        public DrawableBaseRpObject(BaseRpObject hitObject)
            : base(hitObject)
        {
            AccentColour = new Color4(255, 255, 255, 255);
            Alpha = 0;

            Origin = Anchor.Centre;
            Position = new Vector2(100, 100);
            Scale = new Vector2(1);
            Size = new Vector2(1, 1);

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
        protected virtual void InitialChildObject()
        {
            Template = new Template.Template(HitObject,Components);
            Children = new Drawable[]
            {
                Template
            };
        }

        protected override void UpdateState(ArmedState state)
        {
            FinishTransforms();

            using (BeginAbsoluteSequence(HitObject.StartTime - PreemptTime, true))
            {
                UpdateInitialState();

                UpdatePreemptState();

                using (BeginDelayedSequence(PreemptTime + Judgement.TimeOffset, true))
                    UpdateCurrentState(state);
            }
        }

        //初始化
        protected virtual void UpdateInitialState()
        {
            //set alpha to 0
            //Alpha = 0;
            Hide();
        }

        //正在準備的時候
        protected virtual void UpdatePreemptState()
        {
            this.FadeIn(FadeInTime);
            //Fadein
            Template.FadeIn(FadeInTime);
        }

        /// <summary>
        ///     更新狀態
        /// </summary>
        /// <param name="state"></param>
        protected virtual void UpdateCurrentState(ArmedState state)
        {
            //state = ArmedState.Hit;

            //if (!IsLoaded) return;

            //this.Flush();

            //this.Delay(HitObject.StartTime - Time.Current - PreemptTime + Judgement.TimeOffset);

            //this.Delay(PreemptTime);
        }


        /// <summary>
        ///     持續一直更新物件
        /// </summary>
        protected override void Update()
        {
            base.Update();
            //更新物件位置
            Template.UpdateTemplate(Time.Current);
        }

        //if rotate , notified the template
        public new float Rotation
        {
            get { return base.Rotation; }
            set
            {
                base.Rotation = value;
                ChangeRotationValue(base.Rotation);
            }
        }

        //update rotation value
        public virtual void ChangeRotationValue(float rotation)
        {
        }

        protected override RpJudgement CreateJudgement() => new RpJudgement { Score = RpScoreResult.Cool };
    }
}
