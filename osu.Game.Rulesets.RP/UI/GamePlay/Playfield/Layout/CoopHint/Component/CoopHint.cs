// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Game.Rulesets.RP.Objects;
using osu.Game.Rulesets.RP.SkinManager;
using osu.Game.Rulesets.RP.UI.Piece;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.CoopHint.Component
{
    internal class CoopHint : Container
    {
        private readonly Coop _coop;

        private readonly RectanglePiece _rectangle;

        public CoopHint(Coop coop)
        {
            _coop = coop;
            _rectangle = new RectanglePiece(500, 1000)
            {
                Colour = RpTextureColorManager.GetCoopLayoutColor(_coop),
                Alpha = 0.5f
            };

            Children = new Drawable[]
            {
                _rectangle
            };
        }
    }
}
