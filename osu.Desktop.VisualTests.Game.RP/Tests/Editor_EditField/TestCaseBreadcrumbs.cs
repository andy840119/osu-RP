﻿﻿// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using osu.Framework.Graphics;
using osu.Game.Graphics.UserInterface;

namespace osu.Desktop.VisualTests.Tests.Editor_EditField
{
    /// <summary>
    /// looks like "Click >> The >> Circle"
    /// It might be use in the Editor_EditField
    /// Maybe
    /// </summary>
    internal class TestCaseBreadcrumbs : CategoryTestCase
    {
        public override string Description => @"breadcrumb > control";

        public override string Category => TestCaseCategory.Editor_EditField.ToString();

        public override string TestName => @"Breadcrumbs";

        public TestCaseBreadcrumbs()
        {
            BreadcrumbControl<BreadcrumbTab> c;
            Add(c = new BreadcrumbControl<BreadcrumbTab>
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                RelativeSizeAxes = Axes.X,
                Width = 0.5f,
            });

            AddStep(@"first", () => c.Current.Value = BreadcrumbTab.Click);
            AddStep(@"second", () => c.Current.Value = BreadcrumbTab.The);
            AddStep(@"third", () => c.Current.Value = BreadcrumbTab.Circles);
        }

        private enum BreadcrumbTab
        {
            Click,
            The,
            Circles,
        }
    }
}
