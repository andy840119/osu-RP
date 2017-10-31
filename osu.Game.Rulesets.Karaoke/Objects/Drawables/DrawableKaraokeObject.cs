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

        protected DrawableKaraokeObject(KaraokeObject hitObject)
            : base(hitObject)
        {
            Alpha = 0;

            //put all the text as child
            var listComponent = InitialTextContainer(hitObject);
            //add to child
            Children = listComponent.ToArray();
            //Add Background and mask
            Children.ToList().Add(InitialBackground(hitObject));
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

        /// <summary>
        /// generate background and mask
        /// </summary>
        protected Container InitialBackground(KaraokeObject hitObject)
        {
            Container container=new Container();
            container.Width = hitObject.Width;
            container.Height = hitObject.Height;
            container.Masking = true;
            return container;
        }

        /// <summary>
        /// generate list text
        /// </summary>
        /// <param name="hitObject"></param>
        /// <returns></returns>
        protected List<OsuSpriteText> InitialTextContainer(KaraokeObject hitObject)
        {
            List<OsuSpriteText> text = new List<OsuSpriteText>();

            text.Add(GetTextByTextObject(hitObject.MainText));

            foreach (var singleText in hitObject.ListSubTextObject)
            {
                text.Add(GetTextByTextObject(singleText));
            }

            return text;
        }

        protected OsuSpriteText GetTextByTextObject(TextObject textObject)
        {
            return new OsuSpriteText
            {
                Text = textObject.Text,
                Font = @"Venera",
                UseFullGlyphHeight = false,
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                TextSize = textObject.FontSize,
                Alpha = 1
            };
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
}
