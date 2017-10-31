using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osu.Framework.Graphics.Containers;
using osu.Game.Graphics.Sprites;
using OpenTK.Graphics;

namespace osu.Game.Rulesets.Karaoke.Objects.Drawables.Pieces
{
    public class TextsAndMask : Container
    {
        protected SingleSideOfAndMask LeftSideText { get; set; }=new SingleSideOfAndMask();

        protected SingleSideOfAndMask RightSideText { get; set; }=new SingleSideOfAndMask();

        private float _maskWidth;

        private float _maskHeight;

        protected TextsAndMask()
        {

        }

        protected void AddText(TextObject textObject)
        {
            LeftSideText.AddText(textObject);
            RightSideText.AddText(textObject);
        }

        protected void RemoveText(TextObject textObject)
        {
            LeftSideText.RemoveText(textObject);
            RightSideText.RemoveText(textObject);
        }

        public void SetWidth(float width)
        {
            _maskWidth = width;
            LeftSideText.SetWidth(_maskWidth);
            RightSideText.SetWidth(_maskWidth);
        }

        public void SetHeight(float height)
        {
            _maskHeight = height;
            LeftSideText.SetWidth(_maskHeight);
            RightSideText.SetWidth(_maskHeight);
        }

        protected void MovingMask(float newValue)
        {
            LeftSideText.SetMaskStartPosition(0);
            LeftSideText.SetMaskEndPosition(newValue);
            RightSideText.SetMaskStartPosition(newValue);
            RightSideText.SetMaskEndPosition(_maskWidth);
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

            private List<OsuSpriteText> _listText=new List<OsuSpriteText>();

            public SingleSideOfAndMask()
            {
                UpdateChild();
            }

            public void AddText(TextObject textObject)
            {
                UpdateChild();
            }

            public void RemoveText(TextObject textObject)
            {

                UpdateChild();
            }

            protected void UpdateChild()
            {

            }


            public void SetWidth(float width)
            {

            }

            public void SetHeight(float height)
            {

            }


            public void SetMaskStartPosition(float positionX)
            {

            }

            public void SetMaskEndPosition(float positionX)
            {

            }

            public void SetColor(Color4 color)
            {

            }
        }
    }

}
