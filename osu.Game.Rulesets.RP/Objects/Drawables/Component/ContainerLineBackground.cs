// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Game.Rulesets.RP.Objects.Drawables.Component.Extension;
using osu.Game.Rulesets.RP.Objects.Drawables.Component.Interface;
using osu.Game.Rulesets.RP.Objects.Interface;
using osu.Game.Rulesets.RP.SkinManager;
using osu.Game.Rulesets.RP.UI.Piece;
using OpenTK;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Component
{
    /// <summary>
    /// container line Background
    /// </summary>
    public class ContainerLineBackground : Container, IHasCoop, IComponentBase, IHasLayerIndex
    {
        /// <summary>
        ///     背景
        /// </summary>
        private RectanglePiece _rpRectangleComponent;

        private Coop _coop;

        //TODO : Change color
        public Coop Coop
        {
            get { return _coop; }
            set
            {
                _coop = value;
                if (_rpRectangleComponent == null)
                    createDrawable();

                _rpRectangleComponent.Colour = RpTextureColorManager.GetCoopLayoutColor(_coop);
            }
        }

        public int LayerIndex { get; set; }

        private void createDrawable()
        {
            _rpRectangleComponent = new RectanglePiece(2000, this.SingleLayerHeight())
            {
                Scale = new Vector2(1, 0), //new OpenTK.Vector2(1, 0.13f * layerCount),
                Alpha = 0.5f,
                //TODO : Edit position
                //Position = new Vector2(0, 0.13f / 2 * 1),
                //Colour = HitObject.Colour
            };

            Children = new Drawable[]
            {
                _rpRectangleComponent,
            };
        }

        public void FadeIn(double time = 0)
        {
            //RP FadeIn Animation
            _rpRectangleComponent.ScaleTo(new Vector2(1, 1), time, Easing.InOutElastic);
        }

        public void FadeOut(double time = 0)
        {
            //Animation
            _rpRectangleComponent.ScaleTo(new Vector2(1, 0), time * 3, Easing.OutElastic);
        }
    }
}
