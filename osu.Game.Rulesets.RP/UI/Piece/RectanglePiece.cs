// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Game.Rulesets.RP.SkinManager;
using OpenTK;

namespace osu.Game.Rulesets.RP.UI.Piece
{
    /// <summary>
    ///     用來顯示矩形元素
    ///     可以設定長寬，還有顏色
    /// </summary>
    public class RectanglePiece : Container
    {
        public new float Width
        {
            get { return _rectangleWidth; }
            set
            {
                _rectangleWidth = value;
                ChangeSize(_rectangleWidth, _rectangleHeight);
            }
        }

        public new float Height
        {
            get { return _rectangleHeight; }
            set
            {
                _rectangleHeight = value;
                ChangeSize(_rectangleWidth, _rectangleHeight);
            }
        }

        /// <summary>
        ///     物件的大小剛好是100*100
        /// </summary>
        private readonly Sprite rectangle;

        /// <summary>
        ///     寬度
        /// </summary>
        private float _rectangleWidth;

        private float _rectangleHeight;

        /// <summary>
        ///     會根據初始設定的 width Height 改變物件的scale
        /// </summary>
        /// <param name="width"></param>
        /// <param name="Height"></param>
        public RectanglePiece(float width, float height)
        {
            Size = new Vector2(width, Height);
            CornerRadius = DrawSize.X / 2;

            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;

            Children = new Drawable[]
            {
                rectangle = new Sprite
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Size = new Vector2(100, 100)
                }
            };

            //改變大小
            ChangeSize(width, height);
        }

        /// <summary>
        ///     改變大小
        /// </summary>
        /// <param name="width"></param>
        /// <param name="Height"></param>
        public void ChangeSize(float width, float height)
        {
            _rectangleWidth = width;
            _rectangleHeight = height;
            rectangle.Scale = new Vector2(_rectangleWidth / 100, _rectangleHeight / 100);
        }

        [BackgroundDependencyLoader]
        private void load(TextureStore textures)
        {
            rectangle.Texture = textures.Get(RpTexturePathManager.GetRectangleTexture());
        }
    }
}
