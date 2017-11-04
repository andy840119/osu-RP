using osu.Game.Graphics.UserInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  osu.Game.Graphics;
using osu.Game.Graphics.Sprites;
using osu.Framework.Graphics;

namespace osu.Game.Rulesets.Karaoke.UI.Panel.Pieces
{
    public class KaraokeTimerSliderBar : OsuSliderBar<double>
    {
        public EventHandler<double> OnValueChanged;
        public KaraokeTimerSliderBar()
        {
            CurrentNumber.MinValue = 0;
            CurrentNumber.MaxValue = 1;
            //RelativeSizeAxes = Axes.X;
            KeyboardStep = 0.1f;

            //now time
            Add(new OsuSpriteText
            {
                //Position = new Vector2(startXPositin + 240, oneLayerYPosition),
                Position=new OpenTK.Vector2(-10,-2),
                Text = "00:00",
                UseFullGlyphHeight = false,
                Origin = Anchor.CentreRight,
                Anchor = Anchor.CentreLeft,
                TextSize = 15,
                Alpha = 1,
                //ShadowColour = _textColor,
                //BorderColour = _textColor,
            });

            //end time
            Add(new OsuSpriteText
            {
                //Position = new Vector2(startXPositin + 240, oneLayerYPosition),
                //Position = new Vector2(startXPositin + 600, oneLayerYPosition),
                Position = new OpenTK.Vector2(35,-2),
                Text = "03:20",
                UseFullGlyphHeight = false,
                Origin = Anchor.CentreRight,
                Anchor = Anchor.CentreRight,
                TextSize = 15,
                Alpha = 1,
                //ShadowColour = _textColor,
                //BorderColour = _textColor,
            });

        }
        public override string TooltipText
        {
            get
            {
                return Current.Value.ToString(@"0.## stars");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        protected override void UpdateValue(float value)
        {
            base.UpdateValue(value);

            if (OnValueChanged != null)
                OnValueChanged(this, value);
        }
    }
}
