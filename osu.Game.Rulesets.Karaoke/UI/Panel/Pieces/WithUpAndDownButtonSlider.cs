using osu.Game.Graphics.UserInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osu.Framework.Graphics;
using OpenTK;

namespace osu.Game.Rulesets.Karaoke.UI.Panel.Pieces
{
    /// <summary>
    /// it's a slider with up and down button
    /// </summary>
    public class WithUpAndDownButtonSlider : OsuSliderBar<double>
    {
        public EventHandler<double> OnValueChanged;

        protected int ButtonZixe = 25;

        public WithUpAndDownButtonSlider()
        {
            // Origin = Anchor.Centre;
            // Anchor = Anchor.Centre;

            CurrentNumber.MinValue = 0;
            CurrentNumber.MaxValue = 1;
            //RelativeSizeAxes = Axes.X;
            KeyboardStep = 0.1f;

            //TODO : tp add button in here ?

            Add(new KaraokeButton()
            {
                Position = new Vector2(-10, 0),
                Origin = Anchor.CentreRight,
                Anchor= Anchor.CentreLeft,
                Width = ButtonZixe,
                Height = ButtonZixe,
                Text = "-",
                TooltipText = "Decrease",
                Action = () =>
                {

                }
            });

            Add(new KaraokeButton()
            {
                Position = new Vector2(10, 0),
                Origin = Anchor.CentreLeft,
                Anchor = Anchor.CentreRight,
                Width = ButtonZixe,
                Height = ButtonZixe,
                Text = "+",
                TooltipText = "Increase",
                Action = () =>
                {

                }
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
