// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using System;
using System.Collections.Generic;
using osu.Game.Rulesets.Replays;
using osu.Game.Rulesets.RP.Input;
using OpenTK.Input;

namespace osu.Game.Rulesets.RP.Replays
{
    /// <summary>
    /// a single frame of record or play RP playing record
    /// </summary>
    public class RpReplayFrame : ReplayFrame
    {
        /// <summary>
        ///     list keys
        /// </summary>
        private List<RpAction> _listPressKeys = new List<RpAction>();

        /// <summary>
        ///     list keys
        /// </summary>
        public List<RpAction> ListPressKeys => _listPressKeys;


        //把滑鼠其中一個座標轉成listKey
        //public RpReplayFrame(double time, float posX, float posY, ReplayButtonState buttonState)
        //    : base(time, posX, posY, buttonState)
        //{
        //    //Convert position to keys;
        //    _listPressKeys = convertMouseAnixXToKeyList((int)MouseX);
        //}

        //constructor
        public RpReplayFrame(double time, List<RpAction> listPressKeys, float posY, ReplayButtonState buttonState)
            : base(time, 0, posY, buttonState)
        {
            //Convert position to keys;
            _listPressKeys = listPressKeys;
        }

        //constructor
        public RpReplayFrame(double time, RpAction key, float posY, ReplayButtonState buttonState)
            : base(time, 0, posY, buttonState)
        {
            _listPressKeys.Clear();
            _listPressKeys.Add(key);
        }

        public RpReplayFrame(double time, float posY, ReplayButtonState buttonState)
            : base(time, 0, posY, buttonState)
        {
            _listPressKeys.Clear();
        }

        //convet state to savable format
        //public override string ToString()
        //{
        //    MouseX = ConvertRpKeysToMouseAnixX(_listPressKeys);
        //    return base.ToString();
        //}


        //Convert int to list key
        //private List<RpAction> convertMouseAnixXToKeyList(int positionX)
        //{
        //    var listKey = new List<RpAction>();
        //    if (positionX > 0)
        //    {
        //        var currentConfig = RpKeyManager.GetCurrentKeyConfig();
        //        for (var i = 0; i < 10; i++)
        //            if (Math.Ceiling(positionX / Math.Pow(2, i)) % 2 == 1)
        //                listKey.Add(currentConfig.KeyDictionary[i].Key);
        //    }
        //    return listKey;
        //}

        //convert list key to int
        //public int ConvertRpKeysToMouseAnixX(List<Key> listStorageKeys)
        //{
        //    var currentConfig = RpKeyManager.GetCurrentKeyConfig();
        //    var returnValue = 0;
        //    for (var i = 0; i < currentConfig.KeyDictionary.Count; i++)
        //        if (listStorageKeys.Contains(currentConfig.KeyDictionary[i].Key))
        //            returnValue = returnValue + (int)Math.Pow(2, i);
        //    return returnValue;
        //}
    }
}
