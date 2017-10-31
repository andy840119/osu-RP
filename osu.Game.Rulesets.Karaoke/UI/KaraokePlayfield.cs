// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System.Linq;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Game.Rulesets.Judgements;
using osu.Game.Rulesets.Karaoke.Judgements;
using osu.Game.Rulesets.Karaoke.Objects;
using osu.Game.Rulesets.Karaoke.Osu_Objects;
using osu.Game.Rulesets.Karaoke.Osu_Objects.Drawables;
using osu.Game.Rulesets.Karaoke.Osu_Objects.Drawables.Connections;
using osu.Game.Rulesets.Karaoke.UI.Cursor;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.UI;
using OpenTK;

namespace osu.Game.Rulesets.Karaoke.UI
{
    public class KaraokePlayfield : Playfield
    {
        private readonly Container approachCircles;
        private readonly Container judgementLayer;
        private readonly ConnectionRenderer<OsuHitObject> connectionLayer;

        public override bool ProvidingUserCursor => true;

        public static readonly Vector2 BASE_SIZE = new Vector2(512, 384);

        public override Vector2 Size
        {
            get
            {
                var parentSize = Parent.DrawSize;
                var aspectSize = parentSize.X * 0.75f < parentSize.Y ? new Vector2(parentSize.X, parentSize.X * 0.75f) : new Vector2(parentSize.Y * 4f / 3f, parentSize.Y);

                return new Vector2(aspectSize.X / parentSize.X, aspectSize.Y / parentSize.Y) * base.Size;
            }
        }

        public KaraokePlayfield() : base(BASE_SIZE.X)
        {
            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;

            AddRange(new Drawable[]
            {
                connectionLayer = new FollowPointRenderer
                {
                    RelativeSizeAxes = Axes.Both,
                    Depth = 2,
                },
                judgementLayer = new Container
                {
                    RelativeSizeAxes = Axes.Both,
                    Depth = 1,
                },
                approachCircles = new Container
                {
                    RelativeSizeAxes = Axes.Both,
                    Depth = -1,
                },
            });
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();
            AddInternal(new GameplayCursor());
        }

        public override void Add(DrawableHitObject h)
        {
            h.Depth = (float)h.HitObject.StartTime;

            var c = h as IDrawableHitObjectWithProxiedApproach;
            if (c != null)
                approachCircles.Add(c.ProxiedLayer.CreateProxy());

            base.Add(h);
        }

        public override void PostProcess()
        {
            connectionLayer.HitObjects = HitObjects.Objects
                .Select(d => d.HitObject)
                .OrderBy(h => h.StartTime).OfType<OsuHitObject>();
        }

        public override void OnJudgement(DrawableHitObject judgedObject, Judgement judgement)
        {
            var osuJudgement = (KaraokeJudgement)judgement;
            var osuObject = (OsuHitObject)judgedObject.HitObject;

            if (!judgedObject.DisplayJudgement)
                return;

            DrawableOsuJudgement explosion = new DrawableOsuJudgement(osuJudgement)
            {
                Origin = Anchor.Centre,
                Position = osuObject.StackedEndPosition + osuJudgement.PositionOffset
            };

            judgementLayer.Add(explosion);
        }
    }
}
