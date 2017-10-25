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
    ///     負責用來載入圖片元素的
    /// </summary>
    public class ImagePicec : Container
    {
        private readonly Sprite disc;
        private string _resource;

        public ImagePicec(string resource)
        {
            _resource = resource;
            Size = new Vector2(100);

            //Masking = true;
            //CornerRadius = DrawSize.X / 2; //在mask的時候會變成圓形或是增加圓形角用

            //RelativeSizeAxes = Axes.Both; //物件會顯示不出來
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;

            Children = new Drawable[]
            {
                disc = new Sprite
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    FillMode = FillMode.Fit,
                    Scale = new Vector2(0.8f)
                }
            };
        }

        [BackgroundDependencyLoader]
        private void load(TextureStore textures)
        {
            disc.Texture = textures.Get(_resource);

            if (disc.Texture == null)
            {
                return;
            }
        }
    }
}
