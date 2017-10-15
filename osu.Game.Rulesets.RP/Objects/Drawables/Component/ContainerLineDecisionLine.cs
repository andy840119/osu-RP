// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Game.Rulesets.RP.Objects.Drawables.Component.Extension;
using osu.Game.Rulesets.RP.Objects.Drawables.Component.Interface;
using osu.Game.Rulesets.RP.Objects.Interface;
using osu.Game.Rulesets.RP.SkinManager;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.CommonDwawablePiece;
using OpenTK;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Component
{
    public class ContainerLineDecisionLine : Container, IHasBPM,IHasStartTime, IHasVelocity, IHasPreemptTime, IHasCoop, IHasEndTime, IComponentBase
    {
        /// <summary>
        ///     判定線
        /// </summary>
        private ImagePicec _containerDecisionLineComponent;

        public Coop Coop { get; set; }

        private double _startTime;
        private double _endTime;
        private double _duration;
        private double _bgm;
        private float _velocity;
        private float _preemptTime;


        public double StartTime
        {
            get => _startTime;
            set
            {
                _startTime = value;
                RecalculatePositionMoving();
            }
        }

        public double EndTime
        {
            get => _endTime;
            set
            {
                _endTime = value;
                RecalculatePositionMoving();
            }
        }

        public double Duration
        {
            get => _duration;
            set
            {
                _duration = value;
                RecalculatePositionMoving();
            }
        }

        public double BPM
        {
            get => _bgm;
            set
            {
                _bgm = value;
                RecalculatePositionMoving();
            }
        }

        public float Velocity
        {
            get => _velocity;
            set
            {
                _velocity = value;
                RecalculatePositionMoving();
            }
        }

        public float PreemptTime
        {
            get => _preemptTime;
            set
            {
                _preemptTime = value;
                RecalculatePositionMoving();
            }
        }

        /// <summary>
        ///     recalculate the position moving from start position to end position
        /// </summary>
        /// <param name="time"></param>
        public void RecalculatePositionMoving()
        {
            if (_containerDecisionLineComponent == null)
                createDrawable();
            
            _containerDecisionLineComponent.Position = this.PositionOfTime(0);
            var targetPosition = this.PositionOfTime(Duration);
            _containerDecisionLineComponent.MoveTo(targetPosition, Duration);
        }

        private void createDrawable()
        {
            //指標
            _containerDecisionLineComponent = new ImagePicec(RpTexturePathManager.GetDecisionLineTexture())
            {
                Position = new Vector2(0, 0),
                //Scale = new Vector2(1f, 1f * layerCount)
                Scale = new Vector2(1f, 1f * 1),
                Colour = RpTextureColorManager.GetCoopJudgementLineColor(Coop),
            };

            var listDrawable = new List<Container>();
            listDrawable.Add(_containerDecisionLineComponent);
            Children = listDrawable;
        }

        public void FadeIn(double time = 0)
        {
            _containerDecisionLineComponent.Alpha = 1;
            RecalculatePositionMoving();
        }

        public void FadeOut(double time = 0)
        {
            _containerDecisionLineComponent.Alpha = 0;
        }

        
    }
}
