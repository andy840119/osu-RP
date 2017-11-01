using System.Collections.Generic;
using NUnit.Framework;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Timing;
using osu.Game.Rulesets.Karaoke.Objects;
using osu.Game.Rulesets.Karaoke.Objects.Drawables;
using osu.Game.Rulesets.Karaoke.Osu_Objects;
using osu.Game.Rulesets.Karaoke.Osu_Objects.Drawables;
using osu.Game.Rulesets.Objects.Drawables;
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
            KaraokeObject=new KaraokeObject();
            KaraokeObject.MainText.Text = "Hello world!";
            KaraokeObject.Position=new Vector2(300,150);

            DrawableKaraokeObject = new DrawableKaraokeObject(KaraokeObject)
            {
                Position = KaraokeObject.Position
            };

            Children = new[]
            {
                DrawableKaraokeObject,
            };
        }
    }
}
