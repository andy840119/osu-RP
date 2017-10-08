// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Game.Rulesets.RP.Objects.Drawables.Component.Interface;
using osu.Game.Rulesets.RP.Objects.Interface;
using osu.Game.Rulesets.RP.SkinManager;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.CommonDwawablePiece;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Component
{
    public class StillHit : Container, IHasDirection, IComponentBase
    {
        /// <summary>
        ///    Still piece
        /// </summary>
        public ImagePicec StillHitPicec;

        private Direction _dircetion;

        public Direction Direction
        {
            get { return _dircetion; }
            set
            {
                _dircetion = value;
                Children = new Drawable[]
                {
                    StillHitPicec = new ImagePicec(RpTexturePathManager.GetStartObjectImageNameByType(ObjectType.Hit, Special.Normal, Direction))
                    {
                    },
                };
                StillHitPicec.Alpha = 0;
            }
        }

        public StillHit()
        {

        }

        /// <summary>
        ///     initial
        /// </summary>
        public void Initial()
        {
            
        }

        /// <summary>
        ///     fade in
        /// </summary>
        public void FadeIn(double time = 0)
        {
            StillHitPicec.FadeIn(time);
        }

        /// <summary>
        ///     fade out
        /// </summary>
        public void FadeOut(double time = 0)
        {
            StillHitPicec.FadeOut(time);
        }
    }
}
