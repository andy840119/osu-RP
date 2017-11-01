using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Colour;
using osu.Framework.Graphics.Containers;
using osu.Game.Graphics.Sprites;
using OpenTK;
using OpenTK.Graphics;

namespace osu.Game.Rulesets.Karaoke.Objects.Drawables.Pieces
{
    public class TextsAndMask : Container
    {
        protected SingleSideOfAndMask LeftSideText { get; set; }=new SingleSideOfAndMask();

        protected SingleSideOfAndMask RightSideText { get; set; }=new SingleSideOfAndMask();

        private float _maskWidth;

        private float _maskHeight;

        public TextsAndMask()
        {

        }

        public void AddText(TextObject textObject)
        {
            LeftSideText.AddText(textObject);
            RightSideText.AddText(textObject);
        }

        public void RemoveText(TextObject textObject)
        {
            LeftSideText.RemoveText(textObject);
            RightSideText.RemoveText(textObject);
        }

        public void SetWidth(float width)
        {
            _maskWidth = width;
        }

        public void SetHeight(float height)
        {
            _maskHeight = height;
            LeftSideText.SetHeight(_maskHeight);
            RightSideText.SetHeight(_maskHeight);
        }

        public void MovingMask(float newValue)
        {
            LeftSideText.SetMaskStartAndEndPosition(0, newValue);
            RightSideText.SetMaskStartAndEndPosition(newValue, _maskWidth);
        }

        public void SetColor(Color4 color)
        {
            LeftSideText.SetColor(color);
            //Right side is white
            RightSideText.SetColor(new Color4(1,1,1,1));
        }

        protected class SingleSideOfAndMask : Container
        {
            private Container maskConttainer = new Container()
            {
                Masking = true,
            };

            private List<TextObject> _listText = new List<TextObject>();
            private List<Drawable> _listDrawableText=new List<Drawable>();
            private float _height;

            public SingleSideOfAndMask()
            {
                UpdateChild();
            }

            public void AddText(TextObject textObject)
            {
                _listText.Add(textObject);
                UpdateChild();
            }

            public void RemoveText(TextObject textObject)
            {
                _listText.Remove(textObject);
                UpdateChild();
            }

            protected void UpdateChild()
            {
                _listDrawableText.Clear();
                foreach (var singleText in _listText)
                {
                    _listDrawableText.Add(GetTextByTextObject(singleText));
                }
                Children = _listDrawableText.ToArray();
                //Children.ToList().Add(maskConttainer);
            }

            public void SetHeight(float height)
            {
                _height = height;
                maskConttainer.Height = height;
            }

            public void SetMaskStartAndEndPosition(float startPositionX, float endPositionX)
            {
                maskConttainer.Position = new Vector2(0, startPositionX);
                maskConttainer.Width = endPositionX - startPositionX;
            }

            public void SetColor(Color4 color)
            {
                
            }

            protected OsuSpriteText GetTextByTextObject(TextObject textObject)
            {
                return new OsuSpriteText
                {
                    Text = textObject.Text,
                    Font = @"Venera",
                    UseFullGlyphHeight = false,
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    TextSize = textObject.FontSize,
                    Alpha = 1,
                    ShadowColour = Color4.Orange,
                };
            }
        }
    }

}
