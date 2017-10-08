// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System;
using System.ComponentModel;
using osu.Framework.Input.Bindings;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.RP.Input;
using osu.Game.Rulesets.RP.Judgements;
using osu.Game.Rulesets.RP.Objects.Drawables.Play.Interface;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.RpHitObject.Component.Common;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Play
{
    //DrawableBaseRpHitableObject
    public abstract class DrawableBaseRpHitableObject : DrawableBaseRpObject, IKeyBindingHandler<RpAction> , IHasTemplate
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
            //載�E判斷黁E
            //if (Judgement == null)
            //    Judgement = CreateJudgement();
        }

        protected override RpJudgement CreateJudgement() => new RpJudgement { MaxScore = RpScoreResult.Cool };

        protected override void ConstructObject()
        {
            Components.Add(new LoadEffect(HitObject));
        }

        //press down event
        protected virtual void OnKeyPressDown()
        {
            //((PositionalJudgementInfo)Judgement).PositionOffset = Vector2.Zero; //todo: set to correct value
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
        protected override void CheckJudgement(bool userTriggered)
        {
            if (!userTriggered)
            {
                if (Judgement.TimeOffset > HitObject.HitWindowFor(RpScoreResult.Safe))
                    Judgement.Result = HitResult.Miss;
                return;
            }

            double hitOffset = Math.Abs(Judgement.TimeOffset);

            var rpInfo = Judgement;
            rpInfo.HitExplosionPosition.Add(Position);

            if (hitOffset < HitObject.HitWindowFor(RpScoreResult.Safe))
            {
                Judgement.Result = HitResult.Hit;
                Judgement.Score = HitObject.ScoreResultForOffset(hitOffset);
            }
            else
                Judgement.Result = HitResult.Miss;
        }

        public bool OnPressed(RpAction action)
        {
            bool press = HitObject.CanHitBy(action);

            if (press)
            {
                var pressDelay = Math.Abs(Time.Current - HitObject.StartTime);
                //Hit at the time
                if (pressDelay < HitObject.HitWindowFor(RpScoreResult.Safe))
                {
                    OnKeyPressDown();
                    return true;
                }
            }

            return false;
        }

        public bool OnReleased(RpAction action)
        {
            bool release = HitObject.CanHitBy(action);

            if (release)
            {
                var pressDelay = Math.Abs(Time.Current - HitObject.StartTime);
                //Hit at the time
                if (pressDelay < HitObject.HitWindowFor(RpScoreResult.Safe))
                {
                    OnKeyPressDown();
                    return true;
                }
            }

            return false;
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
    public enum RpScoreResult
    {
        [Description(@"Sad")] Sad,
        [Description(@"Safe")] Safe,
        [Description(@"Fine")] Fine,
        [Description(@"Cool")] Cool,
        [Description(@"Slider")] Slider
    }
}
