// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Framework.Graphics;
using osu.Framework.Input.Bindings;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.Objects.Types;
using osu.Game.Rulesets.RP.Input;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.RpHitObject;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.RpHitObject.Component.ApproachPiece;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.RpHitObject.Component.Common;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.RpHitObject.Component.StillPiece;
using OpenTK;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Play
{
    /// <summary>
    ///     繪製 RP HitCircle
    /// </summary>
    public class DrawableRpHitObject : DrawableBaseRpHitableObject
    {
        /// <summary>
        /// </summary>
        public new RpHitObject HitObject
        {
            get { return (RpHitObject)base.HitObject; }
        }

        public DrawableRpHitObject(RpHitObject h)
            : base(h)
        {

        }

        protected override void ConstructObject()
        {
            Components.Add(new LoadEffect(HitObject));
            Components.Add(new ApproachCircle(HitObject));
            Components.Add(new StillHit(HitObject));
        }

        /// <summary>
        ///     更新初始狀態
        /// </summary>
        protected override void UpdateInitialState()
        {
            base.UpdateInitialState();
        }

        /// <summary>
        ///     初始時會跑一次
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

        /// <summary>
        ///     結果，有打到或是miss
        /// </summary>
        /// <param name="state"></param>
        protected override void UpdateCurrentState(ArmedState state)
        {
            double duration = ((HitObject as IHasEndTime)?.EndTime ?? HitObject.StartTime) - HitObject.StartTime;

            using (Template.BeginDelayedSequence(duration))
                Template.FadeOut(400);

            //glow.FadeOut(400);

            switch (state)
            {
                case ArmedState.Idle:
                    using (BeginDelayedSequence(duration + PreemptTime))
                        this.FadeOut(PreemptTime);
                    Expire(true);
                    break;
                case ArmedState.Miss:
                    this.FadeOut(FadeOutTime / 5);
                    break;
                case ArmedState.Hit:

                    const double flash_in = 40;


                    using (BeginDelayedSequence(flash_in, true))
                    {
                        Template.FadeOut(flash_in);
                    }
                    //播放打擊的聲音
                    PlaySamples();
                    Expire();
                    break;
            }

            //
            //_template.FadeOut();
        }
    }
}
