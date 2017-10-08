// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System;
using osu.Framework.Graphics;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.RpHitObject;
using OpenTK;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Play
{
    /// <summary>
    ///     Slider
    /// </summary>
    public class DrawableRpHoldObject : DrawableBaseRpHitableObject //, IHasTemplate<RpHoldObjectTemplate>
    {
        // HitObject
        public new RpHoldObject HitObject
        {
            get { return (RpHoldObject)base.HitObject; }
        }

        public DrawableRpHoldObject(RpHoldObject h)
            : base(h)
        {

        }

        // Since the DrawableSlider itself is just a container without a size we need to
        // pass all input through.
        //public override bool Contains(Vector2 screenSpacePos) => true;

        /// <summary>
        /// </summary>
        /// <param name="userTriggered"></param>
        protected override void CheckJudgement(bool userTriggered)
        {
            if (!userTriggered)
            {
                if (Judgement.TimeOffset > HitObject.HitWindowFor(RpScoreResult.Safe))
                    Judgement.Result = HitResult.Miss;
                return;
            }

            var hitOffset = Math.Abs(Judgement.TimeOffset);

            var rpJudgement = Judgement;
            rpJudgement.HitExplosionPosition.Add(Position);

            if (hitOffset < HitObject.HitWindowFor(RpScoreResult.Safe))
            {
                Judgement.Result = HitResult.Hit;


                if (hitOffset < HitObject.HitWindowFor(RpScoreResult.Cool))
                    rpJudgement.Score = RpScoreResult.Cool;
                else if (hitOffset < HitObject.HitWindowFor(RpScoreResult.Fine))
                    rpJudgement.Score = RpScoreResult.Fine;
                else if (hitOffset < HitObject.HitWindowFor(RpScoreResult.Safe))
                    rpJudgement.Score = RpScoreResult.Safe;
            }
            else
            {
                Judgement.Result = HitResult.Miss;
            }
        }

        /// <summary>
        ///     更新初始狀態
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

        //UpdateState
        protected override void UpdateState(ArmedState state)
        {
            if (!IsLoaded) return;

            base.UpdateState(state);

            //glow.FadeOut(400);

            switch (state)
            {
                case ArmedState.Idle:
                    this.Delay(HitObject.Duration + PreemptTime);
                    this.FadeOut(FadeOutTime);
                    break;
                case ArmedState.Miss:
                    this.FadeOut(FadeOutTime / 5);
                    break;
                case ArmedState.Hit:
                    const double flash_in = 40;

                    //flash.FadeTo(0.8f, flash_in);
                    //flash.Delay(flash_in);
                    //flash.FadeOut(100);

                    //explode.FadeIn(flash_in);

                    this.Delay(flash_in);

                    //after the flash, we can hide some elements that were behind it
                    //ring.FadeOut();
                    //_detectPress.FadeOut();
                    //number.FadeOut();

                    this.FadeOut(800);
                    this.ScaleTo(Scale * 1.5f, 400, Easing.OutQuad);
                    //播放打擊的聲音
                    PlaySamples();
                    break;
            }

            //
            //_template.FadeOut();
        }
    }
}
