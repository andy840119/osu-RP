// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using osu.Framework.Graphics.Containers;
using osu.Game.Rulesets.RP.Objects.Drawables.Component.Extension;
using osu.Game.Rulesets.RP.Objects.Drawables.Component.Interface;
using osu.Game.Rulesets.RP.Objects.Interface;
using osu.Game.Rulesets.RP.UI.Piece;
using OpenTK.Graphics;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Component
{
    public class ContainerLineStartEnd : Container, IHasPreemptTime, IHasEndTime, IHasStartTime, IComponentBase, IHasLayerIndex, IHasVelocity
    {
        /// <summary>
        ///     Start Point
        /// </summary>
        private RectanglePiece _containerStartDecisionLineComponent;

        /// <summary>
        ///    EndPoint
        /// </summary>
        private RectanglePiece _containerEndDecisionLineComponent;


        private double _startTime;
        private double _endTime;
        private double _duration;
        private float _velocity;
        private float _preemptTime;
        private int _layerIndex;


        public double StartTime
        {
            get => _startTime;
            set
            {
                _startTime = value;
                movingDrawable();
            }
        }

        public double EndTime
        {
            get => _endTime;
            set
            {
                _endTime = value;
                movingDrawable();
            }
        }

        public double Duration
        {
            get => _duration;
            set
            {
                _duration = value;
                movingDrawable();
            }
        }

        public float Velocity
        {
            get => _velocity;
            set
            {
                _velocity = value;
                movingDrawable();
            }
        }

        public float PreemptTime
        {
            get => _preemptTime;
            set
            {
                _preemptTime = value;
                movingDrawable();
            }
        }

        public int LayerIndex
        {
            get => _layerIndex;
            set
            {
                _layerIndex = value;
                movingDrawable();
            }
        }

        private void movingDrawable()
        {
            if (_containerStartDecisionLineComponent == null)
                createDrawable();

            _containerStartDecisionLineComponent.Position = this.PositionOfTime(0);

            _containerEndDecisionLineComponent.Position = this.PositionOfTime(Duration);
        }

        private void createDrawable()
        {
            //開始點
            _containerStartDecisionLineComponent = new RectanglePiece(5, 50)
            {
                //Scale = new Vector2(0.002f, 0.2f * layerCount),
                //Position = CalculatePosition(0)
                //Position = this.PositionOfTime(0)
                Colour = new Color4(226, 66, 54, 255),
            };

            //結束物件
            _containerEndDecisionLineComponent = new RectanglePiece(5, 50)
            {
                //Scale = new Vector2(0.002f, 0.2f * layerCount),
                //Position = CalculatePosition((HitObject as RpContainerGroup).EndTime - HitObject.StartTime)
                //Position = this.PositionOfTime(Duration)
                Colour = new Color4(226, 66, 54, 255),
            };

            //修改高度
            _containerStartDecisionLineComponent.Height = this.SingleLayerHeight();
            _containerEndDecisionLineComponent.Height = this.SingleLayerHeight();

            var listContainer = new List<Container>();
            listContainer.Add(_containerStartDecisionLineComponent);
            listContainer.Add(_containerEndDecisionLineComponent);
            Children = listContainer;
        }

        public void FadeIn(double time = 0)
        {
            //throw new NotImplementedException();
        }

        public void FadeOut(double time = 0)
        {
            //throw new NotImplementedException();
        }
    }
}
