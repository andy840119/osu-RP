// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using osu.Game.Overlays;
using osu.Game.Users;

namespace osu.Desktop.VisualTests.Tests.GamePlay_PlayField
{
    //testing the medal RP has
    internal class TestCaseMedalOverlay : CategoryTestCase
    {
        public override string TestName => @"TestCaseMedalOverlay";

        public override string Category => TestCaseCategory.GamePlay_PlayField.ToString();

        public override string Description => @"medal get!";

        public TestCaseMedalOverlay()
        {
            AddStep(@"display", () =>
            {
                LoadComponentAsync(new MedalOverlay(new Medal
                {
                    Name = @"Animations",
                    InternalName = @"all-intro-doubletime",
                    Description = @"More complex than you think.",
                }), Add);
            });
        }
    }
}
