using System.Collections.Generic;
using osu.Desktop.VisualTests.TestsScript.Beatmaps.DrawableHitObject;
using osu.Game.Rulesets.RP.UI.GamePlay.Playfield.Layout.HitObjects.Drawables;
using OpenTK;

namespace osu.Desktop.VisualTests.Tests.Editor_HitObject
{
    /// <summary>
    /// you can Test draging Rp Object in here
    /// </summary>
    internal class TestCaseDragRpObject : CategoryTestCase
    {
        public override string Category => TestCaseCategory.Editor_HitObject.ToString();

        public override string TestName => @"DragRpObject";

        public List<DrawableBaseRpObject> ListDragableObject=new List<DrawableBaseRpObject>();

        private RpDrawableHitObjectCreatorScript _drawableHitObjectCreatorScript = new RpDrawableHitObjectCreatorScript();

        private Vector2 _defaultPosition = new Vector2(100, 100);
        private double _defaultStartTime = 0;
        private double _defaultEndTime = 1000;

        public TestCaseDragRpObject()
        {
            _drawableHitObjectCreatorScript.SetObjectEditable(true);

            AddStep("Delete All Object", ListDragableObject.Clear);
            AddStep("Add RpHitObject", AddRpContainerLine);
            AddStep("Add RpHoldObject", AddRpContainerLineGroup);
            AddStep("Add RpContainerLine", AddRpContainerLineHoldObject);
            AddStep("Add RpContainerLineGroup", AddRpHitObject);
            AddStep("Add RpContainerLineHoldObject", AddRpHoldObject);
            //TODO : add all ListDragableObject into view
        }

        public void AddRpContainerLine()
        {
            ListDragableObject.Add(_drawableHitObjectCreatorScript.CreateDrawableRpContainerLine(_defaultPosition, _defaultStartTime, _defaultEndTime));
        }

        public void AddRpContainerLineGroup()
        {
            ListDragableObject.Add(_drawableHitObjectCreatorScript.CreateDrawableRpContainerLineGroup(_defaultPosition, _defaultStartTime, _defaultEndTime));
        }

        public void AddRpContainerLineHoldObject()
        {
            ListDragableObject.Add(_drawableHitObjectCreatorScript.CreateDrawableRpContainerLineHoldObject(_defaultPosition, _defaultStartTime, _defaultEndTime));
        }

        public void AddRpHitObject()
        {
            ListDragableObject.Add(_drawableHitObjectCreatorScript.CreateDrawableRpHitObject(_defaultPosition, _defaultStartTime));
        }

        public void AddRpHoldObject()
        {
            ListDragableObject.Add(_drawableHitObjectCreatorScript.CreateDrawableRpHoldObject(_defaultPosition, _defaultStartTime, _defaultEndTime));
        }
    }
}
