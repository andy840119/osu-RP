// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using osu.Framework.Input;
using osu.Game.Rulesets.Replays;
using osu.Game.Rulesets.RP.KeyManager;

namespace osu.Game.Rulesets.RP.Replays
{
    public class RpReplayInputHandler : FramedReplayInputHandler
    {
        public RpReplayInputHandler(Replay replay)
            : base(replay)
        {
        }


        public override List<InputState> GetPendingStates()
        {
            //get RpReplayFrame
            var correntFrame = (RpReplayFrame)CurrentFrame;

            return new List<InputState>
            {
                new ReplayState<RpAction>
                {
                    //get keys from frame
                    //Keyboard = new ReplayKeyboardState(),
                    PressedActions = correntFrame.ListPressKeys
                }
            };
        }
    }
}
