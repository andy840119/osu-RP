// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Game.Rulesets.RP.Objects.Drawables.Component.Interface;
using osu.Game.Rulesets.RP.Objects.Interface;
using osu.Game.Rulesets.RP.SkinManager;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.CommonDwawablePiece;
using OpenTK;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Component
{
    public class StillHit : Container, IHasDirection,IHasCoop, IComponentBase
    {
        /// <summary>
        ///    Still piece
        /// </summary>
        public ImagePicec StillHitPicec;

        private Direction _dircetion;

        private Coop _coop;

        public Coop Coop
        {
            get { return _coop; }
            set
            {
                _coop = value;
                if (StillHitPicec == null)
                {
                    CreaterDrawable();
                }
                StillHitPicec.Colour = RpTextureColorManager.GetCoopHitObjectColor(_coop);
            }
        }

        public Direction Direction
        {
            get { return _dircetion; }
            set
            {
                _dircetion = value;
                CreaterDrawable();
            }
        }

        void CreaterDrawable()
        {
            Children = new Drawable[]
               {
                    StillHitPicec = new ImagePicec(RpTexturePathManager.GetStartObjectImageNameByType(ObjectType.Hit, Special.Normal, Direction))
                    {

                    },
               };
            StillHitPicec.Alpha = 0;
            StillHitPicec.Scale = new Vector2(0.5f);
            StillHitPicec.Colour = RpTextureColorManager.GetCoopHitObjectColor(_coop);
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
