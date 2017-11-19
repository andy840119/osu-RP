// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using OpenTK;

namespace osu.Game.Rulesets.RP.UI.Piece
{
    /// <summary>
    ///     顯示棒狀用的物件
    ///     有 上 中 下 三塊
    ///     使用方式是設定解析度(長 寬)
    /// </summary>
    internal class BarPiece : Container
    {
        public float Width = 100f;
        public float Height = 100f;

        //中間物件
        public string Resource;

        //上面物件
        public string UpResource;

        //下面物件
        public string DownResource;

        private readonly Sprite _middleSpirit;
        private readonly Sprite _upSpirit;
        private readonly Sprite _downSpirit;

        /// <summary>
        ///     設定初始的長，寬
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public BarPiece(float width, float height)
        {
            //設定目前寬度
            Width = width;
            Height = height;

            Size = new Vector2(144);
            //Masking = true;
            CornerRadius = DrawSize.X / 2;

            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;

            //Child物件
            Children = new Drawable[]
            {
                //中間物件位置
                _middleSpirit = new Sprite
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Scale = new Vector2(2),
                    Position = new Vector2(0, 0)
                },
                //下面
                _downSpirit = new Sprite
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Scale = new Vector2(2),
                    Position = new Vector2(0, Height / 2)
                },
                //上面
                _upSpirit = new Sprite
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Scale = new Vector2(2),
                    Position = new Vector2(0, -Height / 2)
                }
            };
        }

        [BackgroundDependencyLoader]
        private void load(TextureStore textures)
        {
            _upSpirit.Texture = textures.Get(UpResource);
            _downSpirit.Texture = textures.Get(DownResource);
            _middleSpirit.Texture = textures.Get(Resource);
        }
    }
}
