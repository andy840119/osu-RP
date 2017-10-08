// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using System.Linq;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using OpenTK.Graphics;

namespace osu.Game.Rulesets.RP.UI.Select.Detail
{
    internal class RpBeatmapDetailsGraph : FillFlowContainer<RpBeatmapDetailsBar>
    {
        public IEnumerable<float> Values
        {
            set
            {
                var values = value.ToList();
                var graphBars = Children.ToList();
                for (var i = 0; i < values.Count; i++)
                    if (graphBars.Count > i)
                    {
                        graphBars[i].Length = values[i] / values.Max();
                        graphBars[i].Width = 1.0f / values.Count;
                    }
                    else
                    {
                        Add(new RpBeatmapDetailsBar
                        {
                            RelativeSizeAxes = Axes.Both,
                            Width = 1.0f / values.Count,
                            Length = values[i] / values.Max(),
                            Direction = BarDirection.BottomToTop,
                            BackgroundColour = new Color4(0, 0, 0, 0)
                        });
                    }
            }
        }
    }
}
