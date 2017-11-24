using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osu.Framework.Graphics;
using osu.Game.Graphics.Sprites;
using osu.Framework.Allocation;
using osu.Framework.IO.Stores;

namespace osu.Game.Rulesets.Karaoke.Objects.Drawables.Pieces
{
    public class KaraokeText : OsuSpriteText
    {
        private TextObject _textObject;

        public List<float> ListCharEndPosition { get; protected set; } = new List<float>();

        protected FontStore FontStore=null;

        public TextObject TextObject
        {
            get => _textObject;
            set
            {
                _textObject = value;
                if(_textObject==null)
                    return;
                //set text
                Text = _textObject.Text;
                Position = _textObject.Position;
                if(_textObject.FontSize!=null)
                    TextSize = _textObject.FontSize.Value;

                //update each text's end position
                UpdateSingleCharacterEndPosition();
            }
        }

        public KaraokeText(TextObject textObject)
        {
            TextObject = textObject;

            UseFullGlyphHeight = false;
            Anchor = Anchor.TopLeft;
            Origin = Anchor.TopLeft;
            Alpha = 1;
        }

        protected void UpdateSingleCharacterEndPosition()
        {
            if (FontStore == null)
                return;

            if (_textObject?.Text != null)
            {
                float totalWidth = 0;
                ListCharEndPosition.Clear();
                foreach (var single in _textObject.Text)
                {
                    //get single char width
                    var singleCharWhdth = CreateCharacterDrawable(single).Width * TextSize;
                    totalWidth += singleCharWhdth;
                    ListCharEndPosition.Add(totalWidth);
                }
            }
        }

        public float GetEndPositionByIndex(int index)
        {
            try
            {
                return ListCharEndPosition[index];
            }
            catch
            {
                return -1;
            }
        }

        public int GetIndexByPosition(float position)
        {
            return ListCharEndPosition.FindIndex(x => x > position);
        }

        [BackgroundDependencyLoader]
        private void load(FontStore store)
        {
            FontStore = store;
            UpdateSingleCharacterEndPosition();
        }
    }
}
