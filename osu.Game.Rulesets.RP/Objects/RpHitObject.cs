// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using osu.Game.Rulesets.RP.Input;
using osu.Game.Rulesets.RP.Objects.Interface;

namespace osu.Game.Rulesets.RP.Objects
{
    public class RpHitObject : BaseRpHitableObject, IHasDirection
    {
        //ObjectType
        public override ObjectType ObjectType => ObjectType.Hit;

        //Direction
        public Direction Direction { get; set; }

        //constructure
        public RpHitObject(RpContainerLine parent, double startTime)
            : base(parent, startTime)
        {
        }

       
        public override bool CanHitBy(RpAction action)
        {
            //isMatch
            bool left = false;
            bool right = false;

            switch (Direction)
            {
                case Direction.Up:
                    left = action == RpAction.Left_Up;
                    right = action == RpAction.Right_Up;
                    break;
                case Direction.Down:
                    left = action == RpAction.Left_Down;
                    right = action == RpAction.Right_Down;
                    break;
                case Direction.Left:
                    left = action == RpAction.Left_Left;
                    right = action == RpAction.Right_Left;
                    break;
                case Direction.Right:
                    left = action == RpAction.Left_Right;
                    right = action == RpAction.Right_Right;
                    break;
            }

            if (Coop == Coop.LeftOnly)
                return left;
            if (Coop == Coop.RightOnly)
                return right;

            return left && right;
        }

        public override List<RpAction> GetListCompareKeys()
        {
            List<RpAction> listKey=new List<RpAction>();

            switch (Direction)
            {
                case Direction.Up:
                    if(Coop == Coop.Both || Coop == Coop.LeftOnly)
                        listKey.Add(RpAction.Left_Up);
                    if (Coop == Coop.Both || Coop == Coop.RightOnly)
                        listKey.Add(RpAction.Right_Up);
                    break;
                case Direction.Down:
                    if (Coop == Coop.Both || Coop == Coop.LeftOnly)
                        listKey.Add(RpAction.Left_Down);
                    if (Coop == Coop.Both || Coop == Coop.RightOnly)
                        listKey.Add(RpAction.Right_Down);
                    break;
                case Direction.Left:
                    if (Coop == Coop.Both || Coop == Coop.LeftOnly)
                        listKey.Add(RpAction.Left_Left);
                    if (Coop == Coop.Both || Coop == Coop.RightOnly)
                        listKey.Add(RpAction.Right_Left);
                    break;
                case Direction.Right:
                    if (Coop == Coop.Both || Coop == Coop.LeftOnly)
                        listKey.Add(RpAction.Left_Right);
                    if (Coop == Coop.Both || Coop == Coop.RightOnly)
                        listKey.Add(RpAction.Right_Right);
                    break;
            }

            return listKey;
        }

        //InitialDefaultValue
        protected override void InitialDefaultValue()
        {
            base.InitialDefaultValue();
        }
    }

    public enum Direction
    {
        Up = 1, //up
        Down = 2, //down
        Left = 4, //left
        Right = 8, //right
    }
}
