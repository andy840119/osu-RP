using osu.Framework.Graphics.Cursor;
using osu.Game.Graphics.UserInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osu.Game.Rulesets.Karaoke.UI.Panel.Pieces
{
    /// <summary>
    /// inherit from osuButton
    /// Has tooltop
    /// </summary>
    public class KaraokeButton : OsuButton, IHasTooltip
    {
        public string TooltipText { get; set; }
    }
}
