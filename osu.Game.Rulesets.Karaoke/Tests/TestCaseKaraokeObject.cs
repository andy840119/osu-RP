using System.Collections.Generic;
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

namespace osu.Game.Rulesets.Karaoke.Tests
{
    [TestFixture]
    [Ignore("getting CI working")]
    internal class TestCaseKaraokeObject : OsuTestCase
    {
        /// <summary>
        /// Drawable Object
        /// </summary>
        public DrawableKaraokeObject DrawableKaraokeObject { get; set; }

        public KaraokeObject KaraokeObject { get; set; }

        [BackgroundDependencyLoader]
        private void load(RulesetStore rulesets)
        {
            ExampleContainer container;

            KaraokeObject =new KaraokeObject();
            KaraokeObject.MainText.Text = "Hello world!";
            KaraokeObject.Position=new Vector2(300,150);

            DrawableKaraokeObject = new DrawableKaraokeObject(KaraokeObject)
            {
                Position = KaraokeObject.Position
            };


            Add(container = new ExampleContainer());

            //Add a slider
            Add(new SettingsSlider<double>
            {
                LabelText = "Background dim",
                Bindable = new Bindable<double>(),
                KeyboardStep = 0.1f
            });

            Add(DrawableKaraokeObject);
        }

        private class ExampleContainer : ReplayGroup
        {
            protected override string Title => @"example";
        }
    }
}
