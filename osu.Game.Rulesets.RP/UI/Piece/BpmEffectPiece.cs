// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Framework.Graphics.Containers;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.CommonDwawablePiece
{
    /// <summary>
    /// this class will beat
    /// </summary>
    public class BpmEffectPiece<T> : HitEffectPiece<T> where T : Container
    {
        double BPM;

        public BpmEffectPiece()
        {
        }

        public void SetBPM(double bpm)
        {
            BPM = bpm;
        }

        public override void GenerateHitEffect()
        {
            Effect.Loop = true;
        }
    }
}
