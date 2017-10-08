// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.MathUtils;
using osu.Framework.Timing;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.RP.Judgements;
using osu.Game.Rulesets.RP.Objects;
using osu.Game.Rulesets.RP.Scoreing;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables;
using osu.Game.Rulesets.Taiko.Objects;
using osu.Game.Rulesets.Taiko.Objects.Drawables;
using osu.Game.Rulesets.Taiko.UI;
using OpenTK;

namespace osu.Desktop.VisualTests.Tests.GamePlay_HitObject
{
    /// <summary>
    /// will be modified for RP for testing hit
    /// </summary>
    internal class TestCaseRpPlayField : CategoryTestCase
    {
        private const double default_duration = 300;
        private const float scroll_time = 1000;

        public override string Description => "Rp Playfield";

        public override string Category => TestCaseCategory.GamePlay_PlayField.ToString();

        public override string TestName => @"Test RP Playing";


        protected override double TimePerAction => default_duration * 2;


        protected readonly Random RNG = new Random(1337);

        protected RpPlayfield Playfield;

        protected Container PlayfieldContainer;



        protected virtual StopwatchClock RateAdjustClock => new StopwatchClock(true) { Rate = 1 };

        public TestCaseRpPlayField()
        {
            AddStep("Hit!", addHitJudgement);
            AddStep("Miss :(", addMissJudgement);
            AddStep("DrumRoll", () => addDrumRoll(false));
            AddStep("Strong DrumRoll", () => addDrumRoll(true));
            AddStep("Swell", () => addSwell());
            AddStep("Centre", () => addCentreHit(false));
            AddStep("Strong Centre", () => addCentreHit(true));
            AddStep("Rim", () => addRimHit(false));
            AddStep("Strong Rim", () => addRimHit(true));
            AddStep("Add bar line", () => addBarLine(false));
            AddStep("Add major bar line", () => addBarLine(true));
            AddStep("Height test 1", () => changePlayfieldSize(1));
            AddStep("Height test 2", () => changePlayfieldSize(2));
            AddStep("Height test 3", () => changePlayfieldSize(3));
            AddStep("Height test 4", () => changePlayfieldSize(4));
            AddStep("Height test 5", () => changePlayfieldSize(5));
            AddStep("Reset height", () => changePlayfieldSize(6));



            CreatePlayField();
        }

        protected void CreatePlayField()
        {
            Add(PlayfieldContainer = new Container
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                RelativeSizeAxes = Axes.X,
                Height = TaikoPlayfield.DEFAULT_PLAYFIELD_HEIGHT,
                Clock = new FramedClock(RateAdjustClock),
                Children = new[]
                {
                    Playfield = new RpPlayfield()
                }
            });
        }

        private void changePlayfieldSize(int step)
        {
            // Add new hits
            switch (step)
            {
                case 1:
                    addCentreHit(false);
                    break;
                case 2:
                    addCentreHit(true);
                    break;
                case 3:
                    addDrumRoll(false);
                    break;
                case 4:
                    addDrumRoll(true);
                    break;
                case 5:
                    addSwell(1000);
                    PlayfieldContainer.Delay(scroll_time - 100);
                    break;
            }

            // Tween playfield height
            switch (step)
            {
                default:
                    PlayfieldContainer.ResizeTo(new Vector2(1, RNG.Next(25, 400)), 500);
                    break;
                case 6:
                    PlayfieldContainer.ResizeTo(new Vector2(1, TaikoPlayfield.DEFAULT_PLAYFIELD_HEIGHT), 500);
                    break;
            }
        }

        private void addHitJudgement()
        {
            RpScoreResult hitResult = Framework.MathUtils.RNG.Next(2) == 0 ? RpScoreResult.Cool : RpScoreResult.Fine;

            var h = new DrawableTestHit(new RpHitObject())
            {
                X = Framework.MathUtils.RNG.NextSingle(hitResult == RpScoreResult.Cool ? -0.1f : -0.05f, hitResult == RpScoreResult.Cool ? 0.1f : 0.05f),
                Judgement = new RpJudgement
                {
                    Result = HitResult.Hit,
                    Score = hitResult,
                    TimeOffset = 0
                }
            };

            Playfield.OnJudgement(h);

            if (Framework.MathUtils.RNG.Next(10) == 0)
            {
                //h.Judgement.SecondHit = true;
                Playfield.OnJudgement(h);
            }
        }

        private void addMissJudgement()
        {
            Playfield.OnJudgement(new DrawableTestHit(new RpHitObject())
            {
                Judgement = new RpJudgement
                {
                    Result = HitResult.Miss,
                    TimeOffset = 0
                }
            });
        }

        private void addBarLine(bool major, double delay = scroll_time)
        {
            BarLine bl = new BarLine
            {
                StartTime = Playfield.Time.Current + delay,
                ScrollTime = scroll_time
            };

            //playfield.AddBarLine(major ? new DrawableBarLineMajor(bl) : new DrawableBarLine(bl));
        }

        private void addSwell(double duration = default_duration)
        {
            Playfield.Add(new DrawableSwell(new Swell
            {
                StartTime = Playfield.Time.Current + scroll_time,
                Duration = duration,
                ScrollTime = scroll_time
            }));
        }

        private void addDrumRoll(bool strong, double duration = default_duration)
        {
            addBarLine(true);
            addBarLine(true, scroll_time + duration);

            var d = new DrumRoll
            {
                StartTime = Playfield.Time.Current + scroll_time,
                IsStrong = strong,
                Duration = duration,
                ScrollTime = scroll_time,
            };

            Playfield.Add(new DrawableDrumRoll(d));
        }

        private void addCentreHit(bool strong)
        {
            Hit h = new Hit
            {
                StartTime = Playfield.Time.Current + scroll_time,
                ScrollTime = scroll_time
            };

            if (strong)
                Playfield.Add(new DrawableCentreHitStrong(h));
            else
                Playfield.Add(new DrawableCentreHit(h));
        }

        private void addRimHit(bool strong)
        {
            Hit h = new Hit
            {
                StartTime = Playfield.Time.Current + scroll_time,
                ScrollTime = scroll_time
            };

            if (strong)
                Playfield.Add(new DrawableRimHitStrong(h));
            else
                Playfield.Add(new DrawableRimHit(h));
        }

        private class DrawableTestHit : DrawableHitObject<BaseRpObject, RpJudgement>
        {
            public DrawableTestHit(BaseRpObject hitObject): base(hitObject)
            {
            }

            protected override RpJudgement CreateJudgement() => new RpJudgement();

            protected override void UpdateState(ArmedState state)
            {
            }
        }
    }
}
