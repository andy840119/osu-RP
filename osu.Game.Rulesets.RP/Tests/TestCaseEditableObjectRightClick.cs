// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using NUnit.Framework;
using osu.Framework.Allocation;
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


            playField = new RpPlayfield();
            //TODO : 增加物件


            Add(playField);
        }
    }
}
