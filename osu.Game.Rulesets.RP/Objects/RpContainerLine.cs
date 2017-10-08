// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Game.Rulesets.Objects.Types;
using osu.Game.Rulesets.RP.Objects.Interface;

namespace osu.Game.Rulesets.RP.Objects
{
    /// <summary>
    ///     裡面朁E��存所有該在上面皁E��件
    /// </summary>
    public class RpContainerLine : BaseRpObject, IHasID, IHasEndTime, IHasParent<RpContainerLineGroup>, IHasLength, IHasCoop
    {
        //ID
        public int ID { get; set; }

        //end time
        public double EndTime { get; set; }

        //Duration
        public double Duration => EndTime - StartTime;

        //parent object
        public RpContainerLineGroup ParentObject { get; set; }

        //relative to parent object time
        public double RelativeToParentStartTime { get; set; }

        //StartTime = RelativeToParentStartTime + ParentObject.StartTime
        public override double StartTime //{ get; set; }
        {
            get
            {
                if (ParentObject == null)
                    return RelativeToParentStartTime;
                return ParentObject.StartTime + RelativeToParentStartTime;
            }
            set
            {
                if (ParentObject == null)
                {
                    RelativeToParentStartTime = value;
                }
                else
                {
                    RelativeToParentStartTime = value - ParentObject.StartTime;
                }
            }
        }

        //Lenght
        public float Lenght { get; set; }

        //Co-op 
        public Coop Coop { get; set; }

        //constructure
        public RpContainerLine(RpContainerLineGroup objectContainer, double startTime)
            : base(startTime)
        {
            UpdateContainerLayout(objectContainer);
        }

        //constructure
        public RpContainerLine(RpContainerLineGroup objectContainer)
            : base(objectContainer.StartTime)
        {
            UpdateContainerLayout(objectContainer);
        }

        protected override void InitialDefaultValue()
        {
            base.InitialDefaultValue();
        }

        /// <summary>
        ///     更新裡面皁E��E��E
        /// </summary>
        /// <param name="objectContainer"></param>
        public void UpdateContainerLayout(RpContainerLineGroup objectContainer)
        {
            ParentObject = objectContainer;
            PreemptTime = objectContainer.PreemptTime;
            //Need to readd in here
            StartTime = ParentObject.StartTime;
            Velocity = ParentObject.Velocity;
            EndTime = ParentObject.EndTime;
            Lenght = ParentObject.Lenght;
            //
            Coop = Coop.Both;
        }
    }
}
