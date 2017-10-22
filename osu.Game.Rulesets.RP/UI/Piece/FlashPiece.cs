// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using OpenTK;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.CommonDwawablePiece
{
    /// <summary>
    ///     閃光
    /// </summary>
    public class FlashPiece : Container
    {
        public FlashPiece()
        {
            Size = new Vector2(144);

            Masking = true;
            CornerRadius = Size.X / 2;

            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;

            Blending = BlendingMode.Additive;
            Alpha = 0;

            Children = new Drawable[]
            {
                new Box
                {
                    RelativeSizeAxes = Axes.Both
                }
            };
        }
    }
}
