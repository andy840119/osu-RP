// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Linq;
using osu.Framework.Graphics;
using osu.Game.Graphics.Sprites;
using osu.Game.Rulesets.Karaoke.Objects.Drawables.Pieces;
using osu.Game.Rulesets.Karaoke.Objects.Extension;
using osu.Game.Rulesets.Karaoke.Tools.Translator;
using osu.Game.Rulesets.Objects.Drawables;
using OpenTK;
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

        public KaraokeObject KaraokeObject => HitObject;

        /// <summary>
        /// if want to update the progress each time
        /// </summary>
        public bool ProgressUpdateByTime = true;

        public TextsAndMask TextsAndMaskPiece { get; set; } = new TextsAndMask();
        public OsuSpriteText TranslateText { get; set; }= new OsuSpriteText
        {
            UseFullGlyphHeight = false,
            Anchor = Anchor.TopLeft,
            Origin = Anchor.TopLeft,
            TextSize = 25,
            Alpha = 1,
            Position = new Vector2(0,80),
        };

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
                TranslateText,
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

                this.Show();
                Alpha = 1;
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

            double transformTime = HitObject.StartTime - TIME_PREEMPT;

            base.ApplyTransformsAt(transformTime, true);
            base.ClearTransformsAfter(transformTime, true);

            using (BeginAbsoluteSequence(transformTime, true))
            {
                UpdatePreemptState();

                using (BeginDelayedSequence(TIME_PREEMPT + (Judgements.FirstOrDefault()?.TimeOffset ?? 0), true))
                    UpdateCurrentState(state);
            }
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
            var sequence = this.Delay(HitObject.Duration).FadeOut(TIME_FADEOUT).Expire();

            //Expire();
        }

        protected virtual void MovingMask(float newValue)
        {
            TextsAndMaskPiece.MovingMask(newValue);
        }

        public void AddTranslate(TranslateCode code, string translateResult)
        {
            //Add and show translate in here
            TranslateText.Text = translateResult;
            
        }
    }
}
