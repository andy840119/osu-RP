// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Framework.Graphics.Containers;
using osu.Game.Rulesets.RP.Objects.Drawables.Play;

namespace osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.Judgement.HitExplosion.HitEffectTemplate
{
    /// <summary>
    ///     打擊特效
    /// </summary>
    public abstract class BaseHitEffectTemplate : Container
    {
        /// <summary>
        ///     目前結果
        /// </summary>
        protected abstract RpScoreResult RpScoreResult { get; }

        //開始特效
        public virtual void StartEffect()
        {
        }
    }
}
