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
    public class ContainerLineJudgementLine : Container, IHasBPM,IHasStartTime, IHasVelocity, IHasPreemptTime, IHasCoop, IHasEndTime, IComponentBase, IHasLayerIndex
    {
        /// <summary>
        ///     背景
        /// </summary>
        private RectanglePiece _containerDecisionLineComponent;

        public int LayerIndex { get; set; }

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
            
            _containerDecisionLineComponent.Position = this.PositionOfTime(-PreemptTime);
            var targetPosition = this.PositionOfTime(Duration);
            _containerDecisionLineComponent.MoveTo(targetPosition, PreemptTime + Duration);
        }

        private void createDrawable()
        {
            //指標
            _containerDecisionLineComponent = new RectanglePiece(2000, this.SingleLayerHeight())
            {
                Scale = new Vector2(1, 1), //new OpenTK.Vector2(1, 0.13f * layerCount),
                Alpha = 0.5f,
                //TODO : Edit position
                //Position = new Vector2(0, 0.13f / 2 * 1),
                //Colour = HitObject.Colour
                Anchor = Anchor.CentreRight,
                Origin = Anchor.CentreRight
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
