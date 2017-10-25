// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System;
using System.ComponentModel;
using osu.Framework.Graphics;
using osu.Framework.Input.Bindings;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.Objects.Types;
using osu.Game.Rulesets.RP.Judgements;
using osu.Game.Rulesets.RP.KeyManager;
using osu.Game.Rulesets.RP.Objects.Drawables.Component;
using osu.Game.Rulesets.RP.Objects.Drawables.Extension;
using osu.Game.Rulesets.RP.Objects.Drawables.Interface;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Play
{
    //DrawableBaseRpHitableObject
    public abstract class DrawableBaseRpHitableObject : DrawableBaseRpObject, IKeyBindingHandler<RpAction>
    {
        // HitObject
        public new BaseRpHitableObject HitObject
        {
            get { return (BaseRpHitableObject)base.HitObject; }
        }

        //constructor
        protected DrawableBaseRpHitableObject(BaseRpHitableObject hitObject)
            : base(hitObject)
        {
           
        }

        protected override void ConstructObject()
        {
            Components.Add(new LoadEffect());
        }

        //press down event
        protected virtual void OnKeyPressDown()
        {

            UpdateJudgement(true);
            //Debug.Print(Judgement.Result + " " + RpHitObject.StartTime + " " + Position.X + "," + Position.Y);
        }

        //press up event
        protected virtual void OnKeyPressUp()
        {
            //((PositionalJudgementInfo)Judgement).PositionOffset = Vector2.Zero; //todo: set to correct value
            //UpdateJudgement(true);
            //Debug.Print(Judgement.Result.ToString());
        }

        //update every frame
        protected override void Update()
        {
            base.Update();
        }

        //CheckJudgement
        protected override void CheckForJudgements(bool userTriggered, double timeOffset)
        {
            if (!userTriggered)
            {
                if (timeOffset > HitObject.HitWindowFor(HitResult.Meh))
                {
                    AddJudgement(new RpJudgement
                    {
                        Result = HitResult.Miss,
                        RpObject = this,
                    });
                    return;
                }
                return;
            }

            AddJudgement(new RpJudgement()
            {
                Result = HitObject.ScoreResultForOffset(timeOffset),
                RpObject = this,
            });

            //如果是打在時間內
            if (timeOffset < HitObject.HitWindowFor(HitResult.Meh))
            {
                var result = HitObject.ScoreResultForOffset(timeOffset);
                //cell component to show effect
                this.TickleComponents(RpObject);
                //call parent component to show effect
                this.ParentObject.TickleComponents(RpObject,result);
            }
        }

        public virtual bool OnPressed(RpAction action)
        {
            bool press = HitObject.CanHitBy(action);

            if (press)
            {
                var pressDelay = Math.Abs(Time.Current - HitObject.StartTime);
                //Hit at the time
                if (pressDelay < HitObject.HitWindowFor(HitResult.Meh))
                {
                    OnKeyPressDown();
                    return true;
                }
            }

            return false;
        }

        public virtual bool OnReleased(RpAction action)
        {
            bool release = HitObject.CanHitBy(action);

            if (release)
            {
                var pressDelay = Math.Abs(Time.Current - HitObject.StartTime);
                //Hit at the time
                if (pressDelay < HitObject.HitWindowFor((HitResult.Meh)))
                {
                    OnKeyPressDown();
                    return true;
                }
            }

            return false;
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
                    this.FadeOut(FadeOutTime / 5);
                    Expire();
                    break;
                case ArmedState.Hit:

                    const double flash_in = 40;
                    using (BeginDelayedSequence(flash_in, true))
                    {
                        this.FadeOut(FadeOutTime);
                    }

                    Expire();
                    break;
            }
        }

        //get all the key Hitted?
        private RpInputManager rpActionInputManager;

        internal RpInputManager RpActionInputManager => rpActionInputManager ?? (rpActionInputManager = GetContainingInputManager() as RpInputManager);
    }

    //RpComboResult
    public enum RpComboResult
    {
        [Description(@"")] None,
        [Description(@"Good")] Good,
        [Description(@"Amazing")] Perfect
    }

    //RpScoreResult
    //TODO : not use anymore
    /*
    public enum RpScoreResult
    {
        [Description(@"Sad")] Sad,
        [Description(@"Safe")] Safe,
        [Description(@"Fine")] Fine,
        [Description(@"Cool")] Cool,
        [Description(@"Slider")] Slider
    }
    */
}
