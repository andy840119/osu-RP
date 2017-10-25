// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.Parameter;

namespace osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator.PreAnalyse
{
    /// <summary>
    ///     to gudge that is a comboing object;
    /// </summary>
    public class AnaylseCombo
    {
        private const double DELTA_COMBO_TIME = 150;

        private double _lastHitObjectTime;

        public bool IsCombo(ConvertParameter single, int i)
        {
            var result = false;
            if (single.ListRefrenceObject[i].StartTime - _lastHitObjectTime < DELTA_COMBO_TIME)
                result = true;
            else
                result = false;
            _lastHitObjectTime = single.ListRefrenceObject[i].StartTime;
            return result;
        }
    }
}
