using OpenTK;
using OpenTK.Graphics;
using osu.Framework.Configuration;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Game.Graphics;
using osu.Game.Graphics.Backgrounds;
using osu.Game.Graphics.Sprites;
using osu.Game.Overlays;
using osu.Game.Overlays.Settings;
using osu.Game.Screens.Play.ReplaySettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osu.Game.Rulesets.Karaoke.UI
{
    /// <summary>
    /// to show the Karaoke panel on Playfield 
    /// </summary>
    public class KaraokePanelOverlay : WaveOverlayContainer
    {
        private const int button_duration = 700;
        private const int ranked_multiplier_duration = 700;
        private const float content_width = 0.8f;

        private Container panelContainer;

        public KaraokePanelOverlay()
        {
            FirstWaveColour = OsuColour.FromHex(@"19b0e2").Opacity(50);
            SecondWaveColour = OsuColour.FromHex(@"2280a2").Opacity(50);
            ThirdWaveColour = OsuColour.FromHex(@"005774").Opacity(50);
            FourthWaveColour = OsuColour.FromHex(@"003a4e").Opacity(50);
            //FourthWaveColour = new Color4(0, 0, 0, 0);

            Height = 90;
            Content.RelativeSizeAxes = Axes.X;
            Content.AutoSizeAxes = Axes.Y;
            Children = new Drawable[]
            {
                new Container
                {
                    RelativeSizeAxes = Axes.Both,
                    Masking = true,
                    Children = new Drawable[]
                    {
                        new Box
                        {
                            RelativeSizeAxes = Axes.Both,
                            Colour = new Color4(36, 50, 68, 30)
                        },
                        //new Triangles
                        //{
                        //    TriangleScale = 5,
                        //    RelativeSizeAxes = Axes.X,
                        //    Height = Height, //set the height from the start to ensure correct triangle density.
                        //    ColourLight = new Color4(53, 66, 82, 150),
                        //    ColourDark = new Color4(41, 54, 70, 150),
                        //},
                    },
                },
                new FillFlowContainer
                {
                    RelativeSizeAxes = Axes.X,
                    AutoSizeAxes = Axes.Y,
                    Anchor = Anchor.BottomCentre,
                    Origin = Anchor.BottomCentre,
                    Direction = FillDirection.Vertical,
                    Spacing = new Vector2(0f, 10f),
                    Children = new Drawable[]
                    {
                        // Body
                        panelContainer = new Container
                        {
                            Origin = Anchor.TopCentre,
                            Anchor = Anchor.TopCentre,
                            RelativeSizeAxes = Axes.X,
                            Width = content_width,
                            Height=90,
                            Children=new Drawable[]
                            {
                                new SettingsSlider<double>()
                                {
                                LabelText = "Background dim",
                                Bindable = new BindableDouble
                                {
                                    MinValue = 0,
                                    MaxValue = 1000,
                                    Default = 500,
                                },
                            },
                        }
                        },
                    },
                },
            };
        }
    }
}
