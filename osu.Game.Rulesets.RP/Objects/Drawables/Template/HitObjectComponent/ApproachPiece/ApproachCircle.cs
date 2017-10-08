// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Framework.Graphics;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.Component;
using osu.Game.Rulesets.RP.Objects.Drawables.Template.Interface;
using osu.Game.Rulesets.RP.SkinManager;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.CommonDwawablePiece;
using OpenTK;
using System;
using osu.Framework.Graphics.Containers;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Template.RpHitObject.Component.ApproachPiece
{
    /// <summary>
    /// </summary>
    public class ApproachCircle : Container, IComponentBase, IComponentUpdateEachFrame 
    {
        /// <summary>
        ///     ëúosu! approach circle ìﬂûÈ
        /// </summary>
        public ImagePicec ApproachHitPicec;

        public BaseRpObject HitObject { get; set; }

        public ApproachCircle(BaseRpHitableObject baseHitObject) 
        {
            HitObject = baseHitObject;
            Children = new Drawable[]
            {
                ApproachHitPicec = new ImagePicec(RpTexturePathManager.GetStartObjectImageNameByType(HitObject as BaseRpHitableObject))
                {
                },
            };
        }

        /// <summary>
        ///     èâénâªË˚é¶
        /// </summary>
        public void Initial()
        {
            ApproachHitPicec.Alpha = 0;
            ApproachHitPicec.Scale = new Vector2(3);
        }

        /// <summary>
        ///     äJénì¡ù¡
        /// </summary>
        public void FadeIn(double time = 0)
        {
            ApproachHitPicec.Delay(HitObject.PreemptTime / 5 * 4);
            ApproachHitPicec.FadeTo(1, HitObject.PreemptTime / 5 * 4);
            //ApproachHitPicec.FadeIn(Math.Min(BaseHitObject.FadeInTime * 2, BaseHitObject.PreemptTime));
            ApproachHitPicec.ScaleTo(0.5f, HitObject.PreemptTime / 5 * 1);
        }

        /// <summary>
        ///     åãë©
        /// </summary>
        public void FadeOut(double time = 0)
        {
            ApproachHitPicec.FadeOut(time);
        }

        public void UpdateProgress(double startProgress = 0, double endProgress = 1)
        {
            //throw new NotImplementedException();
        }
    }
}
