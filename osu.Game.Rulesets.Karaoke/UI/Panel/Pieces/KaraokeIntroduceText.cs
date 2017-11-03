using osu.Game.Graphics.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osu.Framework.Graphics;

namespace osu.Game.Rulesets.Karaoke.UI.Panel.Pieces
{
    public class KaraokeIntroduceText : OsuSpriteText
    {
        public KaraokeIntroduceText()
        {
            UseFullGlyphHeight = false;
            Anchor = Anchor.TopLeft;
            Origin = Anchor.TopLeft;
            TextSize = 10;
            Alpha = 1;
        }
    }
}
