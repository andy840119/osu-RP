using osu.Game.Graphics.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Cursor;

namespace osu.Game.Rulesets.Karaoke.UI.Panel.Pieces
{
    public class KaraokeIntroduceText : OsuSpriteText, IHasTooltip
    {
        public KaraokeIntroduceText()
        {
            UseFullGlyphHeight = false;
            Origin = Anchor.CentreLeft;
            Anchor = Anchor.TopLeft;
            TextSize = 20;
            Alpha = 1;
        }

        public string TooltipText { get; set; }
    }
}
