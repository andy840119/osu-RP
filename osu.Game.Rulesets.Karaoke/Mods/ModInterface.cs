using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osu.Game.Rulesets.Karaoke.Mods
{
    /// <summary>
    /// if this mod can snow , inherit this interface
    /// </summary>
    public interface ICanSnow
    {
        string TexturePath { get; }
    }
}
