// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System;
using System.Collections;
using System.Collections.Generic;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.RP.Mods;

namespace osu.Game.Rulesets.RP.UI.Select.RpMod
{
    /// <summary>
    ///     not available mod for selection 
    /// </summary>
    internal class SelectMod : IEnumerable<Mod>
    {
        private readonly ModType _type;

        public SelectMod(ModType type)
        {
            _type = type;
        }

        IEnumerator<Mod> IEnumerable<Mod>.GetEnumerator()
        {
            switch (_type)
            {
                case ModType.DifficultyReduction:
                    yield return new RpModEasy();
                    yield return new RpModNoFail();
                    yield return new RpModHalfTime();

                    break;
                case ModType.DifficultyIncrease:
                    yield return new RpModHardRock();
                    yield return new MultiMod
                    {
                        Mods = new Mod[]
                        {
                            new RpModSuddenDeath(),
                            new RpModPerfect()
                        }
                    };
                    yield return new MultiMod
                    {
                        Mods = new Mod[]
                        {
                            new RpModDoubleTime(),
                            new RpModNightcore()
                        }
                    };
                    yield return new RpModHidden();
                    yield return new RpModFlashlight();
                    break;
                case ModType.Special:
                    //yield return new RpModRelax();
                    yield return new MultiMod
                    {
                        Mods = new Mod[]
                        {
                            new RpKeyMod2K(),
                            new RpKeyMod3K(),
                            new RpKeyMod4K(),
                        }
                    };
                    yield return new RpModAutoContainerLineHoldObject();
                    yield return new RpModShapeHitObjectCoco();
                    yield return new RpModContainerHitObjectCoco();
                    yield return new MultiMod
                    {
                        Mods = new Mod[]
                        {
                            new RpModAutoplay(),
                            new RpModRelax()
                        }
                    };
                    break;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
