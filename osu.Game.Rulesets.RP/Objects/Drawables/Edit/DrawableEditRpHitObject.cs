// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using osu.Framework.Graphics;
using osu.Framework.Graphics.UserInterface;
using osu.Game.Graphics.UserInterface;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.Objects.Types;
using osu.Game.Rulesets.RP.Objects.Drawables.Component;
using osu.Game.Rulesets.RP.Objects.Drawables.Edit.Extension;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Edit
{
    /// <summary>
    ///     繪製 RP HitCircle
    /// </summary>
    public class DrawableEditRpHitObject : DrawableEditBaseRpObject
    {
        /// <summary>
        /// </summary>
        public new RpHitObject HitObject
        {
            get { return (RpHitObject)base.HitObject; }
        }

        public DrawableEditRpHitObject(RpHitObject h)
            : base(h)
        {
        }

        protected override void ConstructObject()
        {
            Components.Add(new ApproachCircle());
            Components.Add(new StillHit());
            Components.Add(new LoadEffect());
        }

        protected override void GenerateRightClickMenu()
        {
            ContextMenuItems = new MenuItem[]
            {
                //generate all the menu
                this.GenerateDirectionMenuItem(),
                this.GenerateCoopMenuItem(),
                this.GenerateSpecialMenuItem(),
                this.GenerateVelocityMenuItem(),
                this.GenerateDeleteMenuItem(),
            };
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

