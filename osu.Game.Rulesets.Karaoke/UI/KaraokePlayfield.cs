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
using osu.Game.Beatmaps;
using osu.Game.Graphics.UserInterface;
using osu.Framework.Timing;
using osu.Game.Rulesets.Karaoke.UI.Interface;

namespace osu.Game.Rulesets.Karaoke.UI
{
    /// <summary>
    /// Karaoke PlayField
    /// </summary>
    public class KaraokePlayfield : Playfield, IAmKaraokeField
    {
        public Ruleset Ruleset { get; set; }
        public WorkingBeatmap Beatmap { get; set; }

        private readonly Container approachCircles;
        private readonly Container judgementLayer;
        private readonly Container connectionLayer;

        private readonly KaraokePanelOverlay karaokePanelOverlay;

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
        

        public KaraokePlayfield(Ruleset ruleset, WorkingBeatmap beatmap) : base(BASE_SIZE.X)
        {
           
            Ruleset = ruleset;
            Beatmap = beatmap;

            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;

            AddRange(new Drawable[]
            {
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
                connectionLayer = new Container
                {
                    RelativeSizeAxes = Axes.Both,
                    Depth = -2,
                    Clock=new FramedClock(new StopwatchClock(true)),
                    Children=new Drawable[]
                    {
                         new OsuButton()
                         {
                            //Origin = Anchor.BottomRight,
                            //Anchor = Anchor.BottomRight,
                            
                            Position=new Vector2(0,0),
                            Width=70,
                            Height=30,
                            Text="Panel",
                            Action=()=>
                            {
                                karaokePanelOverlay.ToggleVisibility();
                            }
                         }
                    }
                },
                karaokePanelOverlay=new KaraokePanelOverlay(this)
                {
                    Clock=new FramedClock(new StopwatchClock(true)),
                    RelativeSizeAxes = Axes.X,
                    Origin = Anchor.BottomCentre,
                    Anchor = Anchor.BottomCentre,
                    Position=new Vector2(-100,-100),
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
            return ;
            //connectionLayer.HitObjects = HitObjects.Objects
            //    .Select(d => d.HitObject)
            //    .OrderBy(h => h.StartTime).OfType<OsuHitObject>();
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
