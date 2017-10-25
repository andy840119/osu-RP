using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Timing;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield;
using osu.Game.Tests.Visual;

namespace osu.Game.Rulesets.RP.Tests
{
    [TestFixture]
    internal class TestCaseEditableObjectRightClick : OsuTestCase
    {
        public override string Description => "testing right click editable object";

        private RpPlayfield playField { get; set; }

        private FramedClock framedClock;

        [BackgroundDependencyLoader]
        private void load(RulesetStore rulesets)
        {
            var rateAdjustClock = new StopwatchClock(true);
            framedClock = new FramedClock(rateAdjustClock);
            framedClock.ProcessFrame();


            playField=new RpPlayfield();
            //TODO : 增加物件


            Add(playField);
        }

    }
}
