using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Game.Graphics.Sprites;
using osu.Game.Rulesets.Karaoke.Objects.Drawables.Pieces;
using osu.Game.Rulesets.Karaoke.Osu_Objects;
using osu.Game.Rulesets.Objects.Drawables;

namespace osu.Game.Rulesets.Karaoke.Objects.Drawables
{
    /// <summary>
    /// Karaoke Text
    /// </summary>
    public class DrawableKaraokeObject : DrawableHitObject<KaraokeObject>
    {
        public const float TIME_PREEMPT = 600;
        public const float TIME_FADEIN = 400;
        public const float TIME_FADEOUT = 500;

        protected TextsAndMask TextsAndMaskPiece=new TextsAndMask();

        public DrawableKaraokeObject(KaraokeObject hitObject)
            : base(hitObject)
        {
            Alpha = 0;

            TextsAndMaskPiece.AddText(hitObject.MainText);
            foreach (var singleText in hitObject.ListSubTextObject)
            {
                TextsAndMaskPiece.AddText(singleText);
            }

            TextsAndMaskPiece.SetWidth(hitObject.Width);
            TextsAndMaskPiece.SetHeight(hitObject.Height);

            Width = hitObject.Width;
            Height = hitObject.Height;

            Children = new Drawable[]
            {
                TextsAndMaskPiece,
            };
        }

        protected sealed override void UpdateState(ArmedState state)
        {
            FinishTransforms();

            using (BeginAbsoluteSequence(HitObject.StartTime - TIME_PREEMPT, true))
            {
                UpdateInitialState();

                UpdatePreemptState();

                using (BeginDelayedSequence(TIME_PREEMPT + (Judgements.FirstOrDefault()?.TimeOffset ?? 0), true))
                    UpdateCurrentState(state);
            }
        }

        protected virtual void UpdateInitialState()
        {
            Hide();
        }

        protected virtual void UpdatePreemptState()
        {
            this.FadeIn(TIME_FADEIN);
        }

        protected virtual void UpdateCurrentState(ArmedState state)
        {

        }

        protected virtual void MovingMask(float newValue)
        {
            TextsAndMaskPiece.MovingMask(newValue);
        }

        private KaraokeInputManager karaokeActionInputManager;
        internal KaraokeInputManager KaraokeActionInputManager => karaokeActionInputManager ?? (karaokeActionInputManager = GetContainingInputManager() as KaraokeInputManager);
    }
}
