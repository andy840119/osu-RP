// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System;
using osu.Framework.Input;
using osu.Game.Rulesets.Objects.Drawables;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Edit
{
    public class DrawableEditBaseRpObject : DrawableHitObject<BaseRpObject>
    {
        public DrawableEditBaseRpObject(BaseRpObject hitObject)
            : base(hitObject)
        {

        }

        protected override void UpdateState(ArmedState state)
        {
            throw new NotImplementedException();
        }


        protected override bool OnDoubleClick(InputState state)
        {
            return base.OnDoubleClick(state);
        }

        protected override bool OnDragStart(InputState state)
        {
            return base.OnDragStart(state);
        }

        protected override bool OnDrag(InputState state)
        {
            return base.OnDrag(state);
        }

        protected override bool OnDragEnd(InputState state)
        {
            return base.OnDragEnd(state);
        }
    }
}
