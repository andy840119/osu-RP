// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.CommonDwawablePiece
{
    /// <summary>
    ///     顯示外框
    /// </summary>
    public class GlowPiece : Container
    {
        private readonly Sprite layer;

        public GlowPiece()
        {
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;

            Children = new[]
            {
                layer = new Sprite
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Blending = BlendingMode.Additive,
                    Alpha = 0.5f
                }
            };
        }

        [BackgroundDependencyLoader]
        private void load(TextureStore textures)
        {
            layer.Texture = textures.Get(@"Play/osu/ring-glow@2x");
        }
    }
}
