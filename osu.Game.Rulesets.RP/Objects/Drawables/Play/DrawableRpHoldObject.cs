// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System;
using osu.Framework.Graphics;
using osu.Game.Rulesets.Objects.Drawables;

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
        /*
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
        */

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
    }
}
