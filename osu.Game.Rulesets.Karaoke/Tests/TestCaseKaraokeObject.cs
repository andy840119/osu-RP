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
            KaraokeObject.MainText.Text = "終わるまでは終わらないよ";
            KaraokeObject.Position=new Vector2(300,150);
            KaraokeObject.ListSubTextObject.Add(new TextObject
            {
                Text="お",
                Position=new Vector2(13,10)
            });
            KaraokeObject.ListSubTextObject.Add(new TextObject
            {
                Text = "お",
                Position = new Vector2(278, 10)
            });

            DrawableKaraokeObject = new DrawableKaraokeObject(KaraokeObject)
            {
                Position = KaraokeObject.Position
            };


            Add(container = new ExampleContainer());

            var slider = new SettingsSlider<double>()
            {
                LabelText = "Background dim",
                Bindable = new BindableDouble
                {
                    MinValue = 0,
                    MaxValue = 1000,
                    Default = 500,
                    Value = DrawableKaraokeObject.Progress,
                },
            };
            slider.Bindable.ValueChanged+=  (v) =>
            {
                DrawableKaraokeObject.Progress = v;
            };

            Children = new Drawable[]
            {
                slider,
            };

            Add(DrawableKaraokeObject);
        }

        private class ExampleContainer : ReplayGroup
        {
            protected override string Title => @"example";
        }
    }
}
