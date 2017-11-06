// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Linq;
using osu.Framework.Graphics;
using osu.Game.Rulesets.Karaoke.Objects.Drawables.Pieces;
using osu.Game.Rulesets.Karaoke.Objects.Extension;
using osu.Game.Rulesets.Objects.Drawables;
using OpenTK.Graphics;

namespace osu.Game.Rulesets.Karaoke.Objects.Drawables
{
    /// <summary>
    /// Karaoke Text
    /// </summary>
    public class DrawableKaraokeObject : DrawableHitObject<KaraokeObject> , IAmDrawableKaraokeObject
    {
        //will calculate bu extension
        //簡單來說，preemptive time會是前兩個物件到目前物件開始中間間隔時間
        //就是上個台詞消失後下下句就會在它的位置出現
        public const float TIME_PREEMPT = 600;

        public const float TIME_FADEIN = 100;
        public const float TIME_FADEOUT = 100;

        /// <summary>
        /// if want to update the progress each time
        /// </summary>
        public bool ProgressUpdateByTime = true;

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

            if (!ProgressUpdateByTime)
                return;

            double currentTime = Time.Current;
            if(HitObject.IsInTime(currentTime))
            {
                //TODO : update progress by 
                Progress = HitObject.GetProgressByTime(currentTime- HitObject.StartTime);

                //this.Show();
                //Alpha = 1;
            }
            else
            {
                //this.Hide();
                //Alpha = 0;
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
            if (!ProgressUpdateByTime)
                return;

            //delay
            var sequence = this.Delay(HitObject.Duration).FadeOut(TIME_FADEOUT);//andy840119 : violate method

            //Expire();
        }

        protected virtual void MovingMask(float newValue)
        {
            TextsAndMaskPiece.MovingMask(newValue);
        }
    }
}
