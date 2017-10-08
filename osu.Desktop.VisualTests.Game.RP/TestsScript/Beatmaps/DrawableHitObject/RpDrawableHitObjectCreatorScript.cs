using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osu.Desktop.VisualTests.TestsScript.Beatmaps.HitObject;
using osu.Game.Rulesets.RP.Objects;
using osu.Game.Rulesets.RP.Objects.Drawables;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables;
using OpenTK;

namespace osu.Desktop.VisualTests.TestsScript.Beatmaps.DrawableHitObject
{
    public class RpDrawableHitObjectCreatorScript
    {
        public RpHitObjectCreatorScript RpHitObjectCreatorScript = new RpHitObjectCreatorScript();

        public void SetObjectEditable(bool editable)
        {
            RpHitObjectCreatorScript.SetObjectEditable(editable);
        }

        public DrawableRpContainerLine CreateDrawableRpContainerLine(Vector2 position, Double startTime, Double endTime)
        {
            RpContainerLine rpContainerLine = RpHitObjectCreatorScript.CreateRpContainerLine(position, startTime, endTime);
            return new DrawableRpContainerLine(rpContainerLine);
        }

        public DrawableRpContainerLineGroup CreateDrawableRpContainerLineGroup(Vector2 position, Double startTime, Double endTime)
        {
            RpContainerLineGroup rpContainerLineGroup = RpHitObjectCreatorScript.CreateRpContainerLineGroup(position, startTime, endTime);
            return new DrawableRpContainerLineGroup(rpContainerLineGroup);
        }

        public DrawableRpContainerLineHoldObject CreateDrawableRpContainerLineHoldObject(Vector2 position, Double startTime, Double endTime)
        {
            RpContainerLineHoldObject rpContainerLineHoldObject = RpHitObjectCreatorScript.CreateRpContainerLineHoldObject(position, startTime, endTime);
            return new DrawableRpContainerLineHoldObject(rpContainerLineHoldObject);
        }

        public DrawableRpHitObject CreateDrawableRpHitObject(Vector2 position, Double startTime)
        {
            RpHitObject rpHitObject = RpHitObjectCreatorScript.CreateRpHitObject(position, startTime);
            return new DrawableRpHitObject(rpHitObject);
        }

        public DrawableRpHoldObject CreateDrawableRpHoldObject(Vector2 position, Double startTime, Double endTime)
        {
            RpHoldObject rpHoldObject = RpHitObjectCreatorScript.CreateRpHoldObject(position, startTime, endTime);
            return new DrawableRpHoldObject(rpHoldObject);
        }
    }
}
