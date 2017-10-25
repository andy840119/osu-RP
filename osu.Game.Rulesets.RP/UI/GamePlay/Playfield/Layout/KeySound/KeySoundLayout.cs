// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System.Collections.Generic;
using osu.Framework.Allocation;
using osu.Framework.Audio;
using osu.Framework.Audio.Sample;
using osu.Framework.Input;
using osu.Framework.Input.Bindings;
using osu.Game.Rulesets.RP.KeyManager;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.KeySound
{
    /// <summary>
    ///     放置顯示在打擊物件之前的東西
    ///     例如DecisionLine
    /// </summary>
    internal class KeySoundLayout : BaseGamePlayLayout, IKeyBindingHandler<RpAction>
    {
        //TODO : 增加聲音
        protected List<SampleChannel> ShapeSample = new List<SampleChannel>();

        private InputState _lastState;

        public KeySoundLayout()
        {
        }

        public bool OnPressed(RpAction action)
        {
            int key = (int)action;

            PlayShapeSample(key);
            return false;
        }

        public bool OnReleased(RpAction action)
        {
            return false;
        }

        protected virtual void PlayShapeSample(int keyIndex)
        {
            ShapeSample[keyIndex]?.Play();
        }

        protected virtual void PlayContainerPressSample(int keyIndex)
        {
            ShapeSample[keyIndex]?.Play();
        }

        [BackgroundDependencyLoader]
        private void load(AudioManager audio)
        {
            for (int i = 0; i < 10; i++)
                ShapeSample.Add(audio.Sample.Get($@"RPKey/Key-Shape"));
            ShapeSample[4] = audio.Sample.Get($@"RPKey/Key-ContainerHold");
            ShapeSample[9] = audio.Sample.Get($@"RPKey/Key-ContainerHold");
        }
    }
}
