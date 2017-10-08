// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using osu.Game.Rulesets.Objects.Types;
using osu.Game.Rulesets.RP.Objects.Interface;
using OpenTK;
using OpenTK.Graphics;

namespace osu.Game.Rulesets.RP.Objects
{
    /// <summary>
    ///     包住RP物件的容器
    /// </summary>
    public class RpContainerLineGroup : BaseRpObject, IHasID, IHasEndTime, IHasPosition, IHasRotation, IHasColor, IHasLength, IHasContainList<RpContainerLine>, IHasScale
    {
        //ID
        public int ID { get; set; }

        //end time
        public double EndTime { get; set; }

        //Duration
        public double Duration => EndTime - StartTime;

        //position
        public Vector2 Position { get; set; }

        //X anix
        public float X => Position.X;

        //Y anix
        public float Y => Position.Y;

        //rotation
        public float Rotation { get; set; }

        //Color
        public Color4 Color { get; set; }

        //length
        public float Lenght => 512;

        //list Contain Object
        public List<RpContainerLine> ListContainObject { get; set; }

        //scale
        public float Scale { get; set; }

        //Object type
        public override ObjectType ObjectType => ObjectType.ContainerGroup;

        /// <summary>
        ///     Initialize
        /// </summary>
        /// <param name="startTime"></param>
        public RpContainerLineGroup(double startTime)
            : base(startTime)
        {
        }

        /// <summary>
        ///     初始化物件參數
        /// </summary>
        protected override void InitialDefaultValue()
        {
            base.InitialDefaultValue();

            Scale = 1;
            //顏色
            Color = new Color4(0, 0, 0, 255);
            //速度
            Velocity = 1f;
            //預設試3秒後結束
            EndTime = StartTime + 3000;
            //初始化layout
            InitialLayer();
        }

        protected void InitialLayer()
        {
            ListContainObject = new List<RpContainerLine>();
            //每個Container裡面至少會有一層Layout
            ListContainObject.Add(new RpContainerLine(this));
        }
    }
}
