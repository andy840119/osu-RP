// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Framework.Graphics;
using osu.Game.Rulesets.RP.Objects;
using OpenTK;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.CoopHint
{
    internal class CoopHintLayout : BaseGamePlayLayout
    {
        private readonly Component.CoopHint leftCoopHint;
        private readonly Component.CoopHint rightCoopHint;

        public CoopHintLayout()
        {
            //initial left
            leftCoopHint = new Component.CoopHint(Coop.LeftOnly)
            {
                Position = new Vector2(0 - 300, 192),
                Rotation = 15
            };

            //initial right
            rightCoopHint = new Component.CoopHint(Coop.RightOnly)
            {
                Position = new Vector2(512 + 300, 192),
                Rotation = 195
            };

            //add both of them
            Children = new Drawable[]
            {
                leftCoopHint,
                rightCoopHint
            };
        }
    }
}
