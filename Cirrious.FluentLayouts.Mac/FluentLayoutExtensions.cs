// FluentLayoutExtensions.cs
// (c) Copyright Cirrious Ltd. http://www.cirrious.com
// MvvmCross is licensed using Microsoft Public License (Ms-PL)
// Contributions and inspirations noted in readme.md and license.txt
// 
// Project Lead - Stuart Lodge, @slodge, me@slodge.com

using System.Collections.Generic;
using System.Linq;
using AppKit;

namespace Cirrious.FluentLayouts.Mac
{
	public static class FluentLayoutExtensions
	{
		//
		// Static Methods
		//
		public static void AddConstraints (this NSView view, IEnumerable<FluentLayout> fluentLayouts)
		{
			view.AddConstraints ((from fluent in fluentLayouts
				where fluent != null
				select fluent).SelectMany ((FluentLayout fluent) => fluent.ToLayoutConstraints ()).ToArray<NSLayoutConstraint> ());
		}

		public static void AddConstraints (this NSView view, params FluentLayout[] fluentLayouts)
		{
			view.AddConstraints ((from fluent in fluentLayouts
				where fluent != null
				select fluent).SelectMany ((FluentLayout fluent) => fluent.ToLayoutConstraints ()).ToArray<NSLayoutConstraint> ());
		}

		public static NSViewAndLayoutAttribute Baseline (this NSView view)
		{
			return view.WithLayoutAttribute (NSLayoutAttribute.Baseline);
		}

		public static NSViewAndLayoutAttribute Bottom (this NSView view)
		{
			return view.WithLayoutAttribute (NSLayoutAttribute.Bottom);
		}

		public static NSViewAndLayoutAttribute CenterX (this NSView view)
		{
			return view.WithLayoutAttribute (NSLayoutAttribute.CenterX);
		}

		public static NSViewAndLayoutAttribute CenterY (this NSView view)
		{
			return view.WithLayoutAttribute (NSLayoutAttribute.CenterY);
		}

		public static NSViewAndLayoutAttribute Height (this NSView view)
		{
			return view.WithLayoutAttribute (NSLayoutAttribute.Height);
		}

		public static NSViewAndLayoutAttribute Leading (this NSView view)
		{
			return view.WithLayoutAttribute (NSLayoutAttribute.Leading);
		}

		public static NSViewAndLayoutAttribute Left (this NSView view)
		{
			return view.WithLayoutAttribute (NSLayoutAttribute.Left);
		}

		public static NSViewAndLayoutAttribute Right (this NSView view)
		{
			return view.WithLayoutAttribute (NSLayoutAttribute.Right);
		}

		public static void SubviewsDoNotTranslateAutoresizingMaskIntoConstraints (this NSView view)
		{
			NSView[] subviews = view.Subviews;
			for (int i = 0; i < subviews.Length; i++) {
				NSView NSView = subviews [i];
				NSView.TranslatesAutoresizingMaskIntoConstraints = false;
			}
		}

		public static NSViewAndLayoutAttribute Top (this NSView view)
		{
			return view.WithLayoutAttribute (NSLayoutAttribute.Top);
		}

		public static NSViewAndLayoutAttribute Trailing (this NSView view)
		{
			return view.WithLayoutAttribute (NSLayoutAttribute.Trailing);
		}

		public static NSViewAndLayoutAttribute Width (this NSView view)
		{
			return view.WithLayoutAttribute (NSLayoutAttribute.Width);
		}

		public static NSViewAndLayoutAttribute WithLayoutAttribute (this NSView view, NSLayoutAttribute attribute)
		{
			return new NSViewAndLayoutAttribute (view, attribute);
		}
	}
}
