// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System;
using System.Collections.Generic;
using osu.Game.Audio;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.RP.KeyManager;
using osu.Game.Rulesets.RP.Objects.Interface;

namespace osu.Game.Rulesets.RP.Objects
{
    /// <summary>
    ///     all the hittable object will inherit it
    /// </summary>
    public abstract class BaseRpHitableObject : BaseRpObject, IHasParent<RpContainerLine>, IHasCoop, IHasMultiHit, IHasSpecial
    {
        //parent object
        public RpContainerLine ParentObject { get; set; }

        public int ParentID { get; set; }

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

        //the index of container, will mapping on  HitRanderer
        public int RelativeContainerLineGroupIndex => ParentObject.ParentObject.ID;

        //the layout fo the index ,will mapping on HitRanderer
        public int RelativeContainerLineIndex => ParentObject.ID;

        //set the shape type
        //TODO : 之後把這屬性拿掉
        public Shape Shape = Shape.Unknown;

        //can be trigger by what key 
        public abstract bool CanHitBy(RpAction action);

        //get list compare keys
        public abstract List<RpAction> GetListCompareKeys();

        //normal or special
        public Special Special { get; set; }

        //sligle or multi
        public RpMultiHit RpMultiHit { get; set; }

        //co-op or not
        public Coop Coop
        {
            get { return ParentObject.Coop; }
            set { }
        }

        //if converted for osu!beatmap,set to Convert
        public Convert Convert = Convert.Original;

        public BaseRpHitableObject(RpContainerLine parent, double startTime)
            : base(startTime)
        {
            Special = Special.Normal;
            RpMultiHit = RpMultiHit.SingleClick;
            ParentObject = parent;
            //Need to readd in here
            StartTime = startTime;
            Samples.Add(
                new SampleInfo
                {
                    Bank = "soft",
                    Name = "hitwhistle"
                }
            );
        }

        protected override void InitialDefaultValue()
        {
            base.InitialDefaultValue();
        }

        /// <summary>
        ///     討延遲時間用
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public double HitWindowFor(HitResult result)
        {
            switch (result)
            {
                case HitResult.Meh:
                    return 250;
                case HitResult.Ok:
                    return 200;
                case HitResult.Good:
                    return 180;
                case HitResult.Great:
                    return 150;
                case HitResult.Perfect:
                    return 100;
                default:
                    return 300;
            }
        }

        public HitResult ScoreResultForOffset(double offset)
        {
            if (Math.Abs(offset) < HitWindowFor(HitResult.Perfect))
                return HitResult.Perfect;
            if (Math.Abs(offset) < HitWindowFor(HitResult.Great))
                return HitResult.Great;
            if (Math.Abs(offset) < HitWindowFor(HitResult.Good))
                return HitResult.Good;
            if (Math.Abs(offset) < HitWindowFor(HitResult.Ok))
                return HitResult.Ok;
            if (Math.Abs(offset) < HitWindowFor(HitResult.Meh))
                return HitResult.Meh;
            return HitResult.Miss;
        }
    }

    //Special
    [Flags]
    public enum Special
    {
        Normal = 0,
        Gold = 1
    }

    //Shape
    [Flags]
    public enum Shape
    {
        Unknown = 0, //Unknown
        Hit = 1, //Hit
        Hold = 2, //Hold
        ContainerPress = 4 //containerPress
    }

    //RpMultiHit , not impliment yet
    [Flags]
    public enum RpMultiHit
    {
        SingleClick,
        Multi
    }
}
