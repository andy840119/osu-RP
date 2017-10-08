// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System;
using System.Collections.Generic;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Game.Screens.Play;

namespace osu.Game.Rulesets.RP.UI.GamePlay.KeyCounter
{
    /// <summary>
    ///     RP專用的計數器
    /// </summary>
    //internal class RpKeyCounterCollection : KeyCounterCollection //: IEnumerable<Screens.Play.KeyCounter>
    //{
    //    public List<KeyCounterKeyboard> ListKey = new List<KeyCounterKeyboard>();

    //    private readonly RpKeyLayoutConfig.SingleRpKeyLayoutConfig _singleLayout;

    //    public RpKeyCounterCollection(RpKeyLayoutConfig.SingleRpKeyLayoutConfig singleLayout)
    //    {
    //        _singleLayout = singleLayout;
    //        Direction = FillDirection.Horizontal;
    //        AutoSizeAxes = Axes.Both;
    //        GeneratorKey();
    //    }

    //    public IEnumerator<Screens.Play.KeyCounter> GetEnumerator()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    /// <summary>
    //    ///     Create the key from default config
    //    /// </summary>
    //    private void GeneratorKey()
    //    {
    //        for (var i = 0; i < _singleLayout.KeyDictionary.Count; i++)
    //        {
    //            //var rpKeyCounterKeyboard = new KeyCounterKeyboard(_singleLayout.KeyDictionary[i].Key);
    //            var rpKeyCounterKeyboard = new RpKeyCounterKeyboard(_singleLayout.KeyDictionary[i].Key.ToString(), _singleLayout.KeyDictionary[i], RpKeyCounterKeyboard.SingleKeyLayout.KeyIcon_Count);
    //            //增加有
    //            //Add(rpKeyCounterKeyboard);
    //            ListKey.Add(rpKeyCounterKeyboard);
    //        }
    //    }

    //    //}
    //    //    throw new NotImplementedException();
    //    //{

    //    //IEnumerator IEnumerable.GetEnumerator()
    //}
}
