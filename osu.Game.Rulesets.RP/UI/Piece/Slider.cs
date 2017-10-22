// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System;
using System.Collections.Generic;
using osu.Framework.Allocation;
using osu.Framework.Configuration;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Lines;
using osu.Framework.Graphics.OpenGL.Textures;
using osu.Framework.Graphics.Textures;
using osu.Game.Configuration;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.ES30;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.CommonDwawablePiece
{
    public class Slider : Container
    {
        /// <summary>
        ///     Used to colour the path.
        /// </summary>
        public Color4 Colour
        {
            get { return _colour; }
            set
            {
                if (_colour == value)
                    return;
                _colour = value;

                if (LoadState == LoadState.Loaded)
                    Schedule(reloadTexture);
            }
        }

        public float PathWidth
        {
            get { return path.PathWidth; }
            set { path.PathWidth = value; }
        }

        private int textureWidth => (int)PathWidth * 2;

        /// <summary>
        ///     一段繪製路徑
        /// </summary>
        private readonly Path path;

        private readonly BufferedContainer container;

        private Color4 _colour;

        private Bindable<bool> snakingIn;
        private Bindable<bool> snakingOut;

        public Slider()
        {
            Children = new Drawable[]
            {
                container = new BufferedContainer
                {
                    CacheDrawnFrameBuffer = true,
                    Children = new Drawable[]
                    {
                        path = new Path
                        {
                            Blending = BlendingMode.None
                        }
                    }
                }
            };
            container.Attach(RenderbufferInternalFormat.DepthComponent16);
        }

        /// <summary>
        ///     設定Slider顯示範圍
        /// </summary>
        /// <param name="p0"></param>
        /// <param name="p1"></param>
        public void SetRange(List<Vector2> currentCurve)
        {
            //如果可以顯示
            if (updateSnaking(currentCurve))
            {
                // Autosizing does not give us the desired behaviour here.
                // We want the container to have the same size as the slider,
                // and to be positioned such that the slider head is at (0,0).
                container.Size = path.Size;
                //修正顯示座標
                //container.Position = -path.PositionInBoundingBox(slider.Curve.PositionAt(0) - currentCurve[0]);

                container.Position = -new Vector2(PathWidth, PathWidth);

                container.ForceRedraw();
            }
        }

        [BackgroundDependencyLoader]
        private void load(OsuConfigManager config)
        {
            //snakingIn = config.GetBindable<bool>(OsuConfig.SnakingInSliders);
            //snakingOut = config.GetBindable<bool>(OsuConfig.SnakingOutSliders);

            //int textureWidth = (int)PathWidth * 2;

            ////initialise background
            //var upload = new TextureUpload(textureWidth * 4);
            //var bytes = upload.Data;

            //const float aa_portion = 0.02f;
            //const float border_portion = 0.18f;
            //const float gradient_portion = 1 - border_portion;

            //const float opacity_at_centre = 0.3f;
            //const float opacity_at_edge = 0.8f;

            //for (int i = 0; i < textureWidth; i++)
            //{
            //    float progress = (float)i / (textureWidth - 1);

            //    if (progress <= border_portion)
            //    {
            //        bytes[i * 4] = 255;
            //        bytes[i * 4 + 1] = 255;
            //        bytes[i * 4 + 2] = 255;
            //        bytes[i * 4 + 3] = (byte)(Math.Min(progress / aa_portion, 1) * 255);
            //    }
            //    else
            //    {
            //        progress -= border_portion;

            //        bytes[i * 4] = (byte)(Colour.R * 255);
            //        bytes[i * 4 + 1] = (byte)(Colour.G * 255);
            //        bytes[i * 4 + 2] = (byte)(Colour.B * 255);
            //        bytes[i * 4 + 3] = (byte)((opacity_at_edge - (opacity_at_edge - opacity_at_centre) * progress / gradient_portion) * (Colour.A * 255));
            //    }
            //}

            //var texture = new Texture(textureWidth, 1);
            //texture.SetData(upload);
            //path.Texture = texture;
            reloadTexture();
        }

        private void reloadTexture()
        {
            var texture = new Texture(textureWidth, 1);

            //initialise background
            var upload = new TextureUpload(textureWidth * 4);
            var bytes = upload.Data;

            const float aa_portion = 0.02f;
            const float border_portion = 0.128f;
            const float gradient_portion = 1 - border_portion;

            const float opacity_at_centre = 0.3f;
            const float opacity_at_edge = 0.8f;

            for (var i = 0; i < textureWidth; i++)
            {
                var progress = (float)i / (textureWidth - 1);

                if (progress <= border_portion)
                {
                    bytes[i * 4] = 255;
                    bytes[i * 4 + 1] = 255;
                    bytes[i * 4 + 2] = 255;
                    bytes[i * 4 + 3] = (byte)(Math.Min(progress / aa_portion, 1) * 255);
                }
                else
                {
                    progress -= border_portion;

                    bytes[i * 4] = (byte)(Colour.R * 255);
                    bytes[i * 4 + 1] = (byte)(Colour.G * 255);
                    bytes[i * 4 + 2] = (byte)(Colour.B * 255);
                    bytes[i * 4 + 3] = (byte)((opacity_at_edge - (opacity_at_edge - opacity_at_centre) * progress / gradient_portion) * (Colour.A * 255));
                }
            }

            texture.SetData(upload);
            path.Texture = texture;
        }

        /// <summary>
        ///     更新繪製區域
        /// </summary>
        /// <param name="p0"></param>
        /// <param name="p1"></param>
        /// <returns></returns>
        private bool updateSnaking(List<Vector2> currentCurve)
        {
            path.ClearVertices();
            foreach (var p in currentCurve)
                path.AddVertex(p - currentCurve[0]);

            return true;
        }
    }
}
