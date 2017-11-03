using osu.Game.Graphics.UserInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osu.Game.Rulesets.Karaoke.UI.Panel.Pieces
{
    /// <summary>
    /// it's a slider with up and down button
    /// </summary>
    public class WithUpAndDownButtonSlider : OsuSliderBar<double>
    {
        public WithUpAndDownButtonSlider()
        {
            CurrentNumber.MinValue = 0;
            CurrentNumber.MaxValue = 1;
            //RelativeSizeAxes = Axes.X;
            KeyboardStep = 0.1f;

            //TODO : tp add button in here ?
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
        }
    }
}
