using osu.Game.Beatmaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osu.Game.Rulesets.Karaoke.UI.Interface
{
    /// <summary>
    /// if it is karaoke GameField, need to add this for Externsion use
    /// </summary>
    public interface IAmKaraokeField
    {
         Ruleset Ruleset { get;  }
         WorkingBeatmap Beatmap { get; }
    }
}
