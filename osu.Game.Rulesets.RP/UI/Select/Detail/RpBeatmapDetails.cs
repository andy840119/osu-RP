// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

namespace osu.Game.Rulesets.RP.UI.Select.Detail
{
    /// <summary>
    /// modified form osu!vitaru
    /// and need to modify after
    /// </summary>
    public class RpBeatmapDetails //: BeatmapDetails
    {
        /*
        public new BeatmapInfo Beatmap
        {
            get { return beatmap; }

            set
            {
                if (beatmap == value) return;
                beatmap = value;
                description.Text = beatmap.Version;
                source.Text = beatmap.Metadata.Source;
                tags.Children = beatmap.Metadata.Tags?.Split(' ').Select(text => new OsuSpriteText
                {
                    Text = text,
                    Font = "Exo2.0-Medium"
                });

                circleSize.Value = beatmap.Difficulty.CircleSize;
                drainRate.Value = beatmap.Difficulty.DrainRate;
                overallDifficulty.Value = beatmap.Difficulty.OverallDifficulty;
                approachRate.Value = beatmap.Difficulty.ApproachRate;
                stars.Value = (float)beatmap.StarDifficulty;
            }
        }

        public IEnumerable<int> Ratings
        {
            get { return ratings; }
            set
            {
                ratings = value.ToList();
                negativeRatings.Text = ratings.GetRange(0, 5).Sum().ToString();
                positiveRatings.Text = ratings.GetRange(5, 5).Sum().ToString();
                ratingsBar.Length = (float)ratings.GetRange(0, 5).Sum() / ratings.Sum();

                ratingsGraph.Values = ratings.Select(rating => (float)rating);
            }
        }

        public IEnumerable<int> Retries
        {
            get { return retries; }
            set
            {
                retries = value.ToList();
                calcRetryAndFailGraph();
            }
        }

        public IEnumerable<int> Fails
        {
            get { return fails; }
            set
            {
                fails = value.ToList();
                calcRetryAndFailGraph();
            }
        }

        private readonly OsuSpriteText description;
        private readonly OsuSpriteText source;
        private readonly FillFlowContainer<OsuSpriteText> tags;

        private readonly DifficultyRow circleSize;
        private readonly DifficultyRow drainRate;
        private readonly DifficultyRow overallDifficulty;
        private readonly DifficultyRow approachRate;
        private readonly DifficultyRow stars;

        private readonly RpBeatmapDetailsBar ratingsBar;
        private readonly OsuSpriteText negativeRatings;
        private readonly OsuSpriteText positiveRatings;
        private readonly RpBeatmapDetailsGraph ratingsGraph;

        private readonly RpBeatmapDetailsGraph retryGraph;
        private readonly RpBeatmapDetailsGraph failGraph;

        private BeatmapInfo beatmap;

        private List<int> ratings;

        private List<int> retries = Enumerable.Repeat(0, 100).ToList();

        private List<int> fails = Enumerable.Repeat(0, 100).ToList();

        public RpBeatmapDetails()
        {
            Children = new Drawable[]
            {
                new Box
                {
                    RelativeSizeAxes = Axes.Both,
                    Colour = Color4.Black,
                    Alpha = 0.5f
                },
                new FillFlowContainer
                {
                    Anchor = Anchor.TopRight,
                    Origin = Anchor.TopRight,
                    RelativeSizeAxes = Axes.X,
                    AutoSizeAxes = Axes.Y,
                    Width = 0.4f,
                    Direction = FillDirection.Vertical,
                    Padding = new MarginPadding(10) { Top = 25 },
                    Children = new Drawable[]
                    {
                        new OsuSpriteText
                        {
                            Text = "Description",
                            Font = @"Exo2.0-Bold"
                        },
                        description = new OsuSpriteText
                        {
                            Font = @"Exo2.0-Medium",
                            Direction = FillDirection.Full
                        },
                        new OsuSpriteText
                        {
                            Text = "Source",
                            Font = @"Exo2.0-Bold",
                            Margin = new MarginPadding { Top = 20 }
                        },
                        source = new OsuSpriteText
                        {
                            Font = @"Exo2.0-Medium",
                            Direction = FillDirection.Full
                        },
                        new OsuSpriteText
                        {
                            Text = "Tags",
                            Font = @"Exo2.0-Bold",
                            Margin = new MarginPadding { Top = 20 }
                        },
                        tags = new FillFlowContainer<OsuSpriteText>
                        {
                            RelativeSizeAxes = Axes.X,
                            Spacing = new Vector2(3, 0)
                        }
                    }
                },
                new FillFlowContainer
                {
                    RelativeSizeAxes = Axes.X,
                    AutoSizeAxes = Axes.Y,
                    Width = 0.6f,
                    Direction = FillDirection.Vertical,
                    Spacing = new Vector2(0, 15),
                    Padding = new MarginPadding(10) { Top = 0 },
                    Children = new Drawable[]
                    {
                        new ContainerGroup
                        {
                            RelativeSizeAxes = Axes.X,
                            AutoSizeAxes = Axes.Y,
                            Children = new Drawable[]
                            {
                                new Box
                                {
                                    RelativeSizeAxes = Axes.Both,
                                    Colour = Color4.Black,
                                    Alpha = 0.5f
                                },
                                new FillFlowContainer
                                {
                                    RelativeSizeAxes = Axes.X,
                                    AutoSizeAxes = Axes.Y,
                                    Direction = FillDirection.Vertical,
                                    Spacing = new Vector2(0, 10),
                                    Padding = new MarginPadding(15) { Top = 25 },
                                    Children = new[]
                                    {
                                        circleSize = new DifficultyRow
                                        {
                                            DifficultyName = "Circle Size",
                                            AutoSizeAxes = Axes.Y,
                                            RelativeSizeAxes = Axes.X,
                                            MaxValue = 7
                                        },
                                        drainRate = new DifficultyRow
                                        {
                                            DifficultyName = "HP Drain",
                                            AutoSizeAxes = Axes.Y,
                                            RelativeSizeAxes = Axes.X
                                        },
                                        overallDifficulty = new DifficultyRow
                                        {
                                            DifficultyName = "Accuracy",
                                            AutoSizeAxes = Axes.Y,
                                            RelativeSizeAxes = Axes.X
                                        },
                                        approachRate = new DifficultyRow
                                        {
                                            DifficultyName = "Approach Rate",
                                            AutoSizeAxes = Axes.Y,
                                            RelativeSizeAxes = Axes.X
                                        },
                                        stars = new DifficultyRow
                                        {
                                            DifficultyName = "Star Difficulty",
                                            AutoSizeAxes = Axes.Y,
                                            RelativeSizeAxes = Axes.X
                                        }
                                    }
                                }
                            }
                        },
                        new ContainerGroup
                        {
                            RelativeSizeAxes = Axes.X,
                            AutoSizeAxes = Axes.Y,
                            Children = new Drawable[]
                            {
                                new Box
                                {
                                    RelativeSizeAxes = Axes.Both,
                                    Colour = Color4.Black,
                                    Alpha = 0.5f
                                },
                                new FillFlowContainer
                                {
                                    RelativeSizeAxes = Axes.X,
                                    AutoSizeAxes = Axes.Y,
                                    Direction = FillDirection.Vertical,
                                    Padding = new MarginPadding(15) { Top = 25, Bottom = 0 },
                                    Children = new Drawable[]
                                    {
                                        new OsuSpriteText
                                        {
                                            Text = "User Rating",
                                            Font = @"Exo2.0-Medium",
                                            Anchor = Anchor.TopCentre,
                                            Origin = Anchor.TopCentre
                                        },
                                        ratingsBar = new RpBeatmapDetailsBar
                                        {
                                            RelativeSizeAxes = Axes.X,
                                            Height = 5,
                                            Length = 0
                                        },
                                        new ContainerGroup
                                        {
                                            RelativeSizeAxes = Axes.X,
                                            AutoSizeAxes = Axes.Y,
                                            Children = new[]
                                            {
                                                negativeRatings = new OsuSpriteText
                                                {
                                                    Font = @"Exo2.0-Medium",
                                                    Text = "0"
                                                },
                                                positiveRatings = new OsuSpriteText
                                                {
                                                    Font = @"Exo2.0-Medium",
                                                    Text = "0",
                                                    Anchor = Anchor.TopRight,
                                                    Origin = Anchor.TopRight
                                                }
                                            }
                                        },
                                        new OsuSpriteText
                                        {
                                            Text = "Rating Spread",
                                            TextSize = 14,
                                            Font = @"Exo2.0-Medium",
                                            Anchor = Anchor.TopCentre,
                                            Origin = Anchor.TopCentre
                                        },
                                        ratingsGraph = new RpBeatmapDetailsGraph
                                        {
                                            RelativeSizeAxes = Axes.X,
                                            Direction = FillDirection.Horizontal,
                                            Height = 50
                                        }
                                    }
                                }
                            }
                        },
                        new OsuSpriteText
                        {
                            Text = "Points of Failure",
                            Font = @"Exo2.0-Medium"
                        },
                        new ContainerGroup<RpBeatmapDetailsGraph>
                        {
                            RelativeSizeAxes = Axes.X,
                            Size = new Vector2(1 / 0.6f, 50),
                            Children = new[]
                            {
                                retryGraph = new RpBeatmapDetailsGraph
                                {
                                    RelativeSizeAxes = Axes.Both
                                },
                                failGraph = new RpBeatmapDetailsGraph
                                {
                                    RelativeSizeAxes = Axes.Both
                                }
                            }
                        }
                    }
                }
            };
        }

        private void calcRetryAndFailGraph()
        {
            failGraph.Values = fails.Select(fail => (float)fail);
            retryGraph.Values = retries.Select((retry, index) => (float)retry + fails[index]);
        }

        [BackgroundDependencyLoader]
        private void load(OsuColour colour)
        {
            description.Colour = colour.GrayB;
            source.Colour = colour.GrayB;
            tags.Colour = colour.YellowLight;

            stars.BarColour = colour.Yellow;

            ratingsBar.BackgroundColour = colour.Green;
            ratingsBar.BarColour = colour.YellowDark;
            ratingsGraph.Colour = colour.BlueDark;

            failGraph.Colour = colour.YellowDarker;
            retryGraph.Colour = colour.Yellow;
        }

        private class DifficultyRow : ContainerGroup
        {
            public float Value
            {
                get { return difficultyValue; }
                set
                {
                    difficultyValue = value;
                    bar.Length = value / maxValue;
                    valueText.Text = value.ToString(CultureInfo.InvariantCulture);
                }
            }

            public float MaxValue
            {
                get { return maxValue; }
                set
                {
                    maxValue = value;
                    bar.Length = Value / value;
                }
            }

            public string DifficultyName
            {
                get { return name.Text; }
                set { name.Text = value; }
            }

            public SRGBColour BarColour
            {
                get { return bar.BarColour; }
                set { bar.BarColour = value; }
            }

            private readonly OsuSpriteText name;
            private readonly RpBeatmapDetailsBar bar;
            private readonly OsuSpriteText valueText;

            private float difficultyValue;

            private float maxValue = 10;

            public DifficultyRow()
            {
                Children = new Drawable[]
                {
                    name = new OsuSpriteText
                    {
                        Font = @"Exo2.0-Medium"
                    },
                    bar = new RpBeatmapDetailsBar
                    {
                        Origin = Anchor.CentreLeft,
                        Anchor = Anchor.CentreLeft,
                        RelativeSizeAxes = Axes.Both,
                        Size = new Vector2(1, 0.35f),
                        Padding = new MarginPadding { Left = 100, Right = 25 }
                    },
                    valueText = new OsuSpriteText
                    {
                        Anchor = Anchor.TopRight,
                        Origin = Anchor.TopRight,
                        Font = @"Exo2.0-Medium"
                    }
                };
            }

            [BackgroundDependencyLoader]
            private void load(OsuColour colour)
            {
                name.Colour = colour.GrayB;
                bar.BackgroundColour = colour.Gray7;
                valueText.Colour = colour.GrayB;
            }
        }

        private class RetryAndFailBar : ContainerGroup<RpBeatmapDetailsBar>
        {
            public float RetryLength
            {
                get { return retryBar.Length; }
                set { retryBar.Length = value + FailLength; }
            }

            public float FailLength
            {
                get { return failBar.Length; }
                set { failBar.Length = value; }
            }

            private readonly RpBeatmapDetailsBar retryBar;
            private readonly RpBeatmapDetailsBar failBar;

            public RetryAndFailBar()
            {
                Children = new[]
                {
                    retryBar = new RpBeatmapDetailsBar
                    {
                        RelativeSizeAxes = Axes.Both,
                        Direction = BarDirection.BottomToTop,
                        Length = 0,
                        BackgroundColour = new Color4(0, 0, 0, 0)
                    },
                    failBar = new RpBeatmapDetailsBar
                    {
                        RelativeSizeAxes = Axes.Both,
                        Direction = BarDirection.BottomToTop,
                        Length = 0,
                        BackgroundColour = new Color4(0, 0, 0, 0)
                    }
                };
            }

            [BackgroundDependencyLoader]
            private void load(OsuColour colour)
            {
                retryBar.Colour = colour.Yellow;
                failBar.Colour = colour.YellowDarker;
            }
        }
        */
    }
}
