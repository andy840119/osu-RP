// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using osu.Framework.Graphics.Containers;
using osu.Game.Rulesets.RP.Objects.Drawables.Calculator;
using osu.Game.Rulesets.RP.Objects.Drawables.Component.Extension;
using osu.Game.Rulesets.RP.Objects.Drawables.Component.Interface;
using osu.Game.Rulesets.RP.Objects.Interface;
using osu.Game.Rulesets.RP.SkinManager;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.CommonDwawablePiece;
using OpenTK;

namespace osu.Game.Rulesets.RP.Objects.Drawables.Component
{
    public class ContainerLineBeatLine : Container, IHasStartTime, IHasEndTime, IHasBPM, IComponentBase, IHasVelocity
    {
        /// <summary>
        ///     中間的節拍
        /// </summary>
        private readonly List<ImagePicec> _containerBeatDecisionLineComponent = new List<ImagePicec>();

        private double _startTime;
        private double _endTime;
        private double _duration;
        private double _bgm;
        private float _velocity;



        public double StartTime
        {
            get=> _startTime;
            set
            {
                if (_startTime != value)
                {
                    _startTime = value;
                    createDrawable();
                }
            }
        }

        public double EndTime
        {
            get=> _endTime;
            set
            {
                if (_endTime != value)
                {
                    _endTime = value;
                    createDrawable();
                }
            }
        }

        public double Duration
        {
            get => _duration;
            set
            {
                if (_duration != value)
                {
                    _duration = value;
                    createDrawable();
                }
            }
        }

        public double BPM
        {
            get => _bgm;
            set
            {
                if (_bgm != value)
                {
                    _bgm = value;
                    createDrawable();
                }
            }
        }

        public float Velocity
        {
            get => _velocity;
            set
            {
                if (_velocity != value)
                {
                    _velocity = value;
                    createDrawable();
                }
            }
        }

        private void createDrawable()
        {
            _containerBeatDecisionLineComponent.Clear();
            for (var i = 0; i < 20; i++)
            {
                if (this.XPositionOfTime(i * this.GetDeltaBeatTime()) > this.XPositionOfTime(Duration))
                    break;

                //物件
                var line = new ImagePicec(RpTexturePathManager.GetBeatLineTexture());
                line.Scale = new Vector2(0.6f);
                //設定位置
                line.Position = this.PositionOfTime(i * this.GetDeltaBeatTime());
                //加入
                _containerBeatDecisionLineComponent.Add(line);
            }

            Children = _containerBeatDecisionLineComponent;
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
