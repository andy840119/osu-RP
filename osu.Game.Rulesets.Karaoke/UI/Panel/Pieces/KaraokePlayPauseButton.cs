using OpenTK;
using osu.Game.Graphics;
using osu.Game.Graphics.UserInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osu.Framework.Graphics;

namespace osu.Game.Rulesets.Karaoke.UI.Panel.Pieces
{
    public class KaraokePlayPauseButton : KaraokeButton
    {
        //use as show icon
        //From MusicController.cs
        private IconButton playButton;

        public KaraokePlayPauseButton()
        {
            this.Add(playButton = new IconButton
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Scale = new Vector2(1.0f),
                IconScale = new Vector2(1.0f),
                //Action = play,
            });
        }

        /// <summary>
        /// if is pause , show pause icon
        /// </summary>
        public KaraokePlayState KaraokeShowingState
        {
            set
            {
                switch (value)
                {
                    case KaraokePlayState.Play:
                        playButton.Icon = FontAwesome.fa_play;
                        TooltipText = "Play";
                        break;
                    case KaraokePlayState.Pause:
                        playButton.Icon = FontAwesome.fa_pause;
                        TooltipText = "Pause";
                        break;
                }
            }
        }
    }

    public enum KaraokePlayState
    {
        Play,
        Pause,
    }
}
