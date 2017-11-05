// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.ComponentModel;
using System.Linq;
using osu.Framework.Graphics;
using osu.Game.Rulesets.Karaoke.Objects;
using osu.Game.Rulesets.Objects.Drawables;

namespace osu.Game.Rulesets.Karaoke.Osu_Objects.Drawables
{
    public class DrawableOsuHitObject : DrawableHitObject<KaraokeObject>
    {
        public const float TIME_PREEMPT = 600;
        public const float TIME_FADEIN = 400;
        public const float TIME_FADEOUT = 500;

        public new OsuHitObject HitObject => (OsuHitObject)base.HitObject;

        protected DrawableOsuHitObject(OsuHitObject hitObject)
            : base(hitObject)
        {
            AccentColour = HitObject.ComboColour;
            Alpha = 0;
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

        private KaraokeInputManager karaokeActionInputManager;
        internal KaraokeInputManager KaraokeActionInputManager => karaokeActionInputManager ?? (karaokeActionInputManager = GetContainingInputManager() as KaraokeInputManager);
    }

    public enum ComboResult
    {
        [Description(@"")] None,
        [Description(@"Good")] Good,
        [Description(@"Amazing")] Perfect
    }
}
