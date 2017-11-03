using NUnit.Framework;
using osu.Framework.Allocation;
using osu.Framework.Configuration;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Timing;
using osu.Game.Configuration;
using osu.Game.Graphics.UserInterface;
using osu.Game.Overlays.Settings;
using osu.Game.Rulesets.Karaoke.Objects;
using osu.Game.Rulesets.Karaoke.Objects.Drawables;
using osu.Game.Rulesets.Karaoke.Osu_Objects;
using osu.Game.Rulesets.Karaoke.Osu_Objects.Drawables;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Screens.Play;
using osu.Game.Screens.Play.ReplaySettings;
using osu.Game.Tests.Visual;
using OpenTK;
using osu.Game.Rulesets.Karaoke.UI;

namespace osu.Game.Rulesets.Karaoke.Tests
{
    [TestFixture]
    [Ignore("getting CI working")]
    internal class TestCaseKaraokePanel : OsuTestCase
    {
        /// <summary>
        /// Drawable Object
        /// </summary>
        public KaraokePanelOverlay KaraokePanelOverlay { get; set; }

        [BackgroundDependencyLoader]
        private void load(RulesetStore rulesets)
        {

        }

        protected override void LoadComplete()
        {
            base.LoadComplete();

            Add(KaraokePanelOverlay = new KaraokePanelOverlay()
            {
                RelativeSizeAxes = Axes.X,
                Origin = Anchor.BottomCentre,
                Anchor = Anchor.BottomCentre,
            });

            AddStep("Toggle", KaraokePanelOverlay.ToggleVisibility);
        }
    }
}
