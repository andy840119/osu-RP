using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osu.Game.Rulesets.RP.Objects.Interface
{
    public interface IHasSpecial
    {
        Special Special { get; set; }
    }
}
