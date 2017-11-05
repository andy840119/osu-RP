// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Linq;
using osu.Framework.Graphics;
using osu.Game.Rulesets.Karaoke.Objects.Drawables.Pieces;
using osu.Game.Rulesets.Objects.Drawables;
using OpenTK.Graphics;

namespace osu.Game.Rulesets.Karaoke.Objects.Drawables
{
    /// <summary>
    /// Karaoke Text
    /// </summary>
    public class DrawableKaraokeObject : DrawableHitObject<KaraokeObject> ,IAmDrawableKaraokeObject
    {
        public const float TIME_PREEMPT = 600;
        public const float TIME_FADEIN = 400;
        public const float TIME_FADEOUT = 500;

        protected TextsAndMask TextsAndMaskPiece = new TextsAndMask();

        private double _nowProgress;

        public DrawableKaraokeObject(KaraokeObject hitObject)
            : base(hitObject)
        {
            Alpha = 0;
            TextsAndMaskPiece.SetColor(Color4.Blue);

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

        protected override void Update()
        {
            base.Update();
            double currentTime = Time.Current;
            if(currentTime> HitObject.StartTime && currentTime< HitObject.EndTime)
            {
                //TODO : update progress by 

            }
        }

        /// <summary>
        /// progress
        /// </summary>
        /// <value>The progress.</value>
        public double Progress
        {
            get => _nowProgress;
            set
            {
                _nowProgress = value;
                TextsAndMaskPiece.MovingMask((float)_nowProgress);
            }
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
