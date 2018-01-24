﻿// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Game.Rulesets.RP.Objects.Drawables.Component;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Play
{
    /// <summary>
    ///     繪製 RP HitCircle
    /// </summary>
    public class DrawableRpHit : DrawableBaseRpHitableObject
    {
        /// <summary>
        /// </summary>
        public new RpHit HitObject
        {
            get { return (RpHit)base.HitObject; }
        }

        public DrawableRpHit(RpHit h)
            : base(h)
        {
        }

        protected override void ConstructObject()
        {
            Components.Add(new ApproachCircle());
            Components.Add(new StillHit());
            Components.Add(new LoadEffect());
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
    }
}
