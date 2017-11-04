using OpenTK;
using OpenTK.Graphics;
using osu.Framework.Configuration;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.UserInterface;
using osu.Game.Graphics;
using osu.Game.Graphics.Backgrounds;
using osu.Game.Graphics.Sprites;
using osu.Game.Graphics.UserInterface;
using osu.Game.Overlays;
using osu.Game.Overlays.Settings;
using osu.Game.Rulesets.Karaoke.UI.Panel.Pieces;
using osu.Game.Rulesets.UI;
using osu.Game.Screens.Play.ReplaySettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osu.Game.Rulesets.Karaoke.UI.Extension;
using osu.Game.Rulesets.Karaoke.UI.Interface;
using osu.Framework.Input.Bindings;

namespace osu.Game.Rulesets.Karaoke.UI
{
    /// <summary>
    /// to show the Karaoke panel on Playfield 
    /// </summary>
    public class KaraokePanelOverlay : WaveOverlayContainer, IKeyBindingHandler<KaraokeAction>
    {
        private const float content_width = 0.8f;

        //define the position of object
        private const int oneLayerYPosition = 30;
        private const int twoLayerYPosition = 75;
        private const int objectHeight = 30;
        private const int startXPositin = -60;


        private Container panelContainer;

        //TODO : all the setting object
        public KaraokeButton FirstLyricButton;
        public KaraokeButton PreviousLyricButton;
        public KaraokeButton NextLyricButton;
        public KaraokePlayPauseButton PlayPauseButton;
        public KaraokeTimerSliderBar TimeSlideBar;
        public WithUpAndDownButtonSlider SpeedSlider;
        public WithUpAndDownButtonSlider ToneSlider;
        public WithUpAndDownButtonSlider LyricOffectSlider;

        /// <summary>
        /// TODO : implenent
        /// </summary>
        /// <returns><c>true</c>, if pressed was oned, <c>false</c> otherwise.</returns>
        /// <param name="action">Action.</param>
        public bool OnPressed(KaraokeAction action)
        {
	        switch (action)
	        {
		        case KaraokeAction.FirstLyric:
                    FirstLyricButton.Action?.Invoke();
                    break;
                case KaraokeAction.PreviousLyric:
                    PreviousLyricButton.Action?.Invoke();
                    break;
                case KaraokeAction.NextLyric:
                    NextLyricButton.Action?.Invoke();
                    break;
                case KaraokeAction.PlayAndPause:
                    PlayPauseButton.Action?.Invoke();
                    break;

                case KaraokeAction.IncreaseSpeed:
                    SpeedSlider.IncreaseButton.Action?.Invoke();
                    break;
                case KaraokeAction.DecreaseSpeed:
                    SpeedSlider.DecreaseButton.Action?.Invoke();
                    break;
                case KaraokeAction.IncreaseTone:
                    ToneSlider.IncreaseButton.Action?.Invoke();
                    break;
                case KaraokeAction.DecreaseTone:
                    ToneSlider.DecreaseButton.Action?.Invoke();
                    break;

                case KaraokeAction.IncreaseLyricAppearTime:
                    LyricOffectSlider.IncreaseButton.Action?.Invoke();
                    break;
                case KaraokeAction.DecreaseLyricAppearTime:
                    LyricOffectSlider.DecreaseButton.Action?.Invoke();
                    break;
            }

	        return false;
        }

        public bool OnReleased(KaraokeAction action) => false;

        public KaraokePanelOverlay(IAmKaraokeField playField = null)
        {
            FirstWaveColour = OsuColour.FromHex(@"19b0e2").Opacity(50);
            SecondWaveColour = OsuColour.FromHex(@"2280a2").Opacity(50);
            ThirdWaveColour = OsuColour.FromHex(@"005774").Opacity(50);
            FourthWaveColour = OsuColour.FromHex(@"003a4e").Opacity(50);
            //FourthWaveColour = new Color4(0, 0, 0, 0);

            Height = 110;
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
                            Colour = Color4.Black.Opacity(0.4f)
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
                            Height= (playField!=null)? 110.0f/0.7f : 110,
                            Scale= (playField!=null)? new Vector2(0.7f):new Vector2(1.0f),// if on playfield , make UI smaller
                            Children=new Drawable[]
                            {
                                //"sentence" introduce text
                                new KaraokeIntroduceText
                                {
                                    Position=new Vector2(startXPositin - 35,oneLayerYPosition),
                                    Text = "Sentence",
                                    TooltipText="Choose the sentence you want to sing."
                                },

                                //switch to first sentence
                                FirstLyricButton = new KaraokeButton()
                                {
                                     Position=new Vector2(startXPositin + 40,oneLayerYPosition),
                                     Origin = Anchor.CentreLeft,
                                     Width =objectHeight,
                                     Height=objectHeight,
                                     Text="1",
                                     TooltipText="Move to first sentence",
                                     Action=()=>
                                     {
                                         playField?.NavigationToFirst();
                                     }
                                },

                                //switch to previous sentence
                                PreviousLyricButton = new KaraokeButton()
                                {
                                     Position=new Vector2(startXPositin + 80,oneLayerYPosition),
                                     Origin = Anchor.CentreLeft,
                                     Width=objectHeight,
                                     Height=objectHeight,
                                     Text="<-",
                                     TooltipText="Move to previous sentence",
                                     Action=()=>
                                     {
                                         playField?.NavigationToPrevious();
                                     }
                                },

                                //switch to next sentence
                                NextLyricButton = new KaraokeButton()
                                {
                                     Position=new Vector2(startXPositin + 120, oneLayerYPosition),
                                     Origin = Anchor.CentreLeft,
                                     Width=objectHeight,
                                     Height=objectHeight,
                                     Text="->",
                                     TooltipText="Move to next sentence",
                                     Action=()=>
                                     {
                                         playField?.NavigationToNext();
                                     }
                                },

                                //"play" introduce text
                                new KaraokeIntroduceText
                                {
                                    Position=new Vector2(startXPositin + 160, oneLayerYPosition),
                                    Text = "Play",
                                    TooltipText="Pause,play the song and adjust time"
                                },

                                //Play and pause
                                PlayPauseButton = new KaraokePlayPauseButton()
                                {
                                     Position=new Vector2(startXPositin + 200, oneLayerYPosition),
                                     Origin = Anchor.CentreLeft,
                                     Width=objectHeight,
                                     Height=objectHeight,
                                     Text="P",
                                     TooltipText="Play",
                                     Action=()=>
                                     {
                                         //TODO : 
                                         playField?.Play();
                                     }
                                },

                                //time slider
                                TimeSlideBar = new KaraokeTimerSliderBar()
                                {
                                    Position=new Vector2(startXPositin + 280, oneLayerYPosition),
                                    Origin = Anchor.CentreLeft,
                                    Width=500,
                                    OnValueChanged = (eaa,newValue)=>
                                    {
                                        playField?.NavigateToTime(newValue);
                                    },
                                },

                                 //"speed" introduce
                                 new KaraokeIntroduceText
                                 {
                                     Position=new Vector2(startXPositin - 30, twoLayerYPosition),
                                     Text = "Speed",
                                     TooltipText="Adjust song speed."
                                 },

                                //speed
                                SpeedSlider = new WithUpAndDownButtonSlider()
                                {
                                    Position=new Vector2(startXPositin + 60, twoLayerYPosition),
                                    Origin = Anchor.CentreLeft,
                                    Width=150,
                                     OnValueChanged = (eaa,newValue)=>
                                     {
                                         playField?.AdjustSpeed(newValue);
                                     },
                                },

                                 //"tone" introduce
                                 new KaraokeIntroduceText
                                 {
                                     Position=new Vector2(startXPositin + 255, twoLayerYPosition),
                                     Text = "Tone",
                                     TooltipText="Adjust song tone."
                                 },

                                //Tone
                                ToneSlider = new WithUpAndDownButtonSlider()
                                {
                                    Position=new Vector2(startXPositin + 340, twoLayerYPosition),
                                    Origin = Anchor.CentreLeft,
                                    Width=150,
                                     OnValueChanged = (eaa,newValue)=>
                                     {
                                         playField?.AdjustTone(newValue);
                                     },
                                },

                                 //"offset" introduce
                                 new KaraokeIntroduceText
                                 {
                                     Position=new Vector2(startXPositin + 535, twoLayerYPosition),
                                     Text = "Offset",
                                     TooltipText="Adjust lyrics appear offset."
                                 },

                                //offset
                                LyricOffectSlider = new WithUpAndDownButtonSlider()
                                {
                                    Position=new Vector2(startXPositin + 630, twoLayerYPosition),
                                    Origin = Anchor.CentreLeft,
                                    Width=150,
                                     OnValueChanged = (eaa,newValue)=>
                                     {
                                         playField?.AdjustlyricsOffset(newValue);
                                     },
                                },
                            },
                        },
                    },
                },
            };
        }
    }
}
