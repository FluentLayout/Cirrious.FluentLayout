// FluentLayoutExtensions.cs
// (c) Copyright Cirrious Ltd. http://www.cirrious.com
// MvvmCross is licensed using Microsoft Public License (Ms-PL)
// Contributions and inspirations noted in readme.md and license.txt
// 
// Project Lead - Stuart Lodge, @slodge, me@slodge.com

using System.Collections.Generic;
using System.Linq;
using AppKit;

namespace Cirrious.FluentLayouts.Touch
{
    public static class FluentLayoutExtensions
    {
        public static void SubviewsDoNotTranslateAutoresizingMaskIntoConstraints(this NSView view)
        {
            foreach (var subview in view.Subviews)
            {
                subview.TranslatesAutoresizingMaskIntoConstraints = false;
            }
        }

        public static NSViewAndLayoutAttribute Left(this NSView view) => view.WithLayoutAttribute(NSLayoutAttribute.Left);

        public static NSViewAndLayoutAttribute Right(this NSView view) => view.WithLayoutAttribute(NSLayoutAttribute.Right);

		public static NSViewAndLayoutAttribute Top(this NSView view) => view.WithLayoutAttribute(NSLayoutAttribute.Top);

        public static NSViewAndLayoutAttribute Bottom(this NSView view) => view.WithLayoutAttribute(NSLayoutAttribute.Bottom);

        public static NSViewAndLayoutAttribute Baseline(this NSView view) => view.WithLayoutAttribute(NSLayoutAttribute.Baseline);

        public static NSViewAndLayoutAttribute Trailing(this NSView view) => view.WithLayoutAttribute(NSLayoutAttribute.Trailing);

        public static NSViewAndLayoutAttribute Leading(this NSView view) => view.WithLayoutAttribute(NSLayoutAttribute.Leading);

        public static NSViewAndLayoutAttribute CenterX(this NSView view) => view.WithLayoutAttribute(NSLayoutAttribute.CenterX);

        public static NSViewAndLayoutAttribute CenterY(this NSView view) => view.WithLayoutAttribute(NSLayoutAttribute.CenterY);

        public static NSViewAndLayoutAttribute Height(this NSView view) => view.WithLayoutAttribute(NSLayoutAttribute.Height);

        public static NSViewAndLayoutAttribute Width(this NSView view) => view.WithLayoutAttribute(NSLayoutAttribute.Width);

        public static NSViewAndLayoutAttribute WithLayoutAttribute(this NSView view, NSLayoutAttribute attribute) => new NSViewAndLayoutAttribute(view, attribute);

		//public static NSViewAndLayoutAttribute LeadingMargin(this NSView view) => view.WithLayoutAttribute(NSLayoutAttribute.LeadingMargin);

		//public static NSViewAndLayoutAttribute TrailingMargin(this NSView view) => view.WithLayoutAttribute(NSLayoutAttribute.TrailingMargin);

		//public static NSViewAndLayoutAttribute TopMargin(this NSView view) => view.WithLayoutAttribute(NSLayoutAttribute.TopMargin);

		//public static NSViewAndLayoutAttribute BottomMargin(this NSView view) => view.WithLayoutAttribute(NSLayoutAttribute.BottomMargin);

		public static void AddConstraints(this NSView view, params FluentLayout[] fluentLayouts) => view.AddConstraints(fluentLayouts.AsEnumerable());

        public static void AddConstraints(this NSView view, IEnumerable<FluentLayout> fluentLayouts) =>
		    view.AddConstraints(fluentLayouts
                .Where(fluent => fluent != null)
            	.Select(fluent => fluent.Constraint.Value)
                .ToArray());

		public static void RemoveConstraints(this NSView view, params FluentLayout[] fluentLayouts) => view.RemoveConstraints(fluentLayouts.AsEnumerable());

		public static void RemoveConstraints(this NSView view, IEnumerable<FluentLayout> fluentLayouts) =>
			view.RemoveConstraints(fluentLayouts
                .Where(fluent => fluent != null)
                .Select(fluent => fluent.Constraint.Value)
                .ToArray());
    }
}
