// AdvancedFluentLayoutExtensions.cs
// (c) Copyright Cirrious Ltd. http://www.cirrious.com
// MvvmCross is licensed using Microsoft Public License (Ms-PL)
// Contributions and inspirations noted in readme.md and license.txt
// 
// Project Lead - Stuart Lodge, @slodge, me@slodge.com

using System;
using System.Collections.Generic;
using System.Linq;
using AppKit;
using Cirrious.FluentLayouts.Touch.Extensions;

namespace Cirrious.FluentLayouts.Touch
{
    public static class AdvancedFluentLayoutExtensions
    {
        const float DefaultMargin = 0;
        const float DefaultScale = 1;

        public static FluentLayout AtTopOf(this NSView view, NSView parentView, nfloat? margin = null) =>
            view.Top().EqualTo().TopOf(parentView).Plus(margin.GetValueOrDefault(DefaultMargin));

        public static FluentLayout AtLeftOf(this NSView view, NSView parentView, nfloat? margin = null) =>
			view.Left().EqualTo().LeftOf(parentView).Plus(margin.GetValueOrDefault(DefaultMargin));

        public static FluentLayout AtRightOf(this NSView view, NSView parentView, nfloat? margin = null) =>
			view.Right().EqualTo().RightOf(parentView).Minus(margin.GetValueOrDefault(DefaultMargin));

        public static FluentLayout AtBottomOf(this NSView view, NSView parentView, nfloat? margin = null) =>
			view.Bottom().EqualTo().BottomOf(parentView).Minus(margin.GetValueOrDefault(DefaultMargin));

        public static FluentLayout AtLeadingOf(this NSView view, NSView parentView, nfloat? margin = null) =>
        view.Leading().EqualTo().LeadingOf(parentView).Plus(margin.GetValueOrDefault(DefaultMargin));

        public static FluentLayout AtTrailingOf(this NSView view, NSView parentView, nfloat? margin = null) =>
        view.Trailing().EqualTo().TrailingOf(parentView).Minus(margin.GetValueOrDefault(DefaultMargin));

        public static FluentLayout Below(this NSView view, NSView previous, nfloat? margin = null) =>
			view.Top().EqualTo().BottomOf(previous).Plus(margin.GetValueOrDefault(DefaultMargin));

        public static FluentLayout Above(this NSView view, NSView previous, nfloat? margin = null) =>
			view.Bottom().EqualTo().TopOf(previous).Minus(margin.GetValueOrDefault(DefaultMargin));

        public static FluentLayout WithSameLeft(this NSView view, NSView previous) => view.Left().EqualTo().LeftOf(previous);

        public static FluentLayout WithSameTop(this NSView view, NSView previous) => view.Top().EqualTo().TopOf(previous);

        public static FluentLayout WithSameCenterX(this NSView view, NSView previous) => view.CenterX().EqualTo().CenterXOf(previous);

        public static FluentLayout WithSameCenterY(this NSView view, NSView previous) => view.CenterY().EqualTo().CenterYOf(previous);

        public static FluentLayout WithSameRight(this NSView view, NSView previous) => view.Right().EqualTo().RightOf(previous);

        public static FluentLayout WithSameWidth(this NSView view, NSView previous) => view.Width().EqualTo().WidthOf(previous);

        public static FluentLayout WithSameBottom(this NSView view, NSView previous) => view.Bottom().EqualTo().BottomOf(previous);

        public static FluentLayout WithSameLeading(this NSView view, NSView previous) => view.Leading().EqualTo().LeadingOf(previous);

        public static FluentLayout WithSameTrailing(this NSView view, NSView previous) => view.Trailing().EqualTo().TrailingOf(previous);

        public static FluentLayout WithRelativeWidth(this NSView view, NSView previous, nfloat? scale = null) =>
			view.Width().EqualTo().WidthOf(previous).WithMultiplier(scale.GetValueOrDefault(DefaultScale));

        public static FluentLayout WithSameHeight(this NSView view, NSView previous) => view.Height().EqualTo().HeightOf(previous);

        public static FluentLayout WithRelativeHeight(this NSView view, NSView previous, nfloat? scale = null) =>
			view.Height().EqualTo().HeightOf(previous).WithMultiplier(scale.GetValueOrDefault(DefaultScale));

        public static FluentLayout ToRightOf(this NSView view, NSView previous, nfloat? margin = null) =>
			view.Left().EqualTo().RightOf(previous).Plus(margin.GetValueOrDefault(DefaultMargin));

        public static FluentLayout ToLeftOf(this NSView view, NSView previous, nfloat? margin = null) =>
			view.Right().EqualTo().LeftOf(previous).Minus(margin.GetValueOrDefault(DefaultMargin));

        public static FluentLayout ToTrailingOf(this NSView view, NSView previous, nfloat? margin = null) =>
            view.Leading().EqualTo().TrailingOf(previous).Plus(margin.GetValueOrDefault(DefaultMargin));

        public static FluentLayout ToLeadingOf(this NSView view, NSView previous, nfloat? margin = null) =>
        view.Trailing().EqualTo().LeadingOf(previous).Minus(margin.GetValueOrDefault(DefaultMargin));

        //public static FluentLayout ToLeftMargin(this NSView view, NSView previous) =>
        //    view.Leading().EqualTo().LeadingMarginOf(previous);

        //public static FluentLayout ToRightMargin(this NSView view, NSView previous) =>
        //	view.Trailing().EqualTo().TrailingMarginOf(previous);

        //public static FluentLayout ToTopMargin(this NSView view, NSView previous) =>
        //	view.Top().EqualTo().TopMarginOf(previous);

        //public static FluentLayout ToBottomMargin(this NSView view, NSView previous) =>
        //	view.Bottom().EqualTo().BottomMarginOf(previous);

        public static FluentLayout ToLeftOfCenterOf(this NSView view, NSView previous, nfloat? margin = null) =>
		view.Right().EqualTo().CenterXOf(previous).Minus(margin.GetValueOrDefault(0));
	    
	public static FluentLayout ToRightOfCenterOf(this NSView view, NSView previous, nfloat? margin = null) =>
		view.Left().EqualTo().CenterXOf(previous).Plus(margin.GetValueOrDefault(0));
	    
	public static FluentLayout AboveCenterOf(this NSView view, NSView previous, nfloat? margin = null) =>
		view.Bottom().EqualTo().CenterYOf(previous).Minus(margin.GetValueOrDefault(0));
	    
	public static FluentLayout BelowCenterOf(this NSView view, NSView previous, nfloat? margin = null) =>
		view.Top().EqualTo().CenterYOf(previous).Plus(margin.GetValueOrDefault(0));

        public static IEnumerable<FluentLayout> FullWidthOf(this NSView view, NSView parent, nfloat? margin = null)
        {
			var marginValue = margin.GetValueOrDefault(DefaultMargin);

	        return new List<FluentLayout>
	        {
				view.AtLeftOf(parent, marginValue).WithIdentifier("Left"),
		        view.AtRightOf(parent, marginValue).WithIdentifier("Right")
	        };
        }

        public static IEnumerable<FluentLayout> FullHeightOf(this NSView view, NSView parent, nfloat? margin = null)
        {
			var marginValue = margin.GetValueOrDefault(DefaultMargin);

			return new List<FluentLayout>
			{
				view.AtTopOf(parent, marginValue).WithIdentifier("Top"),
				view.AtBottomOf(parent, marginValue).WithIdentifier("Bottom")
			};
        }

		public static IEnumerable<FluentLayout> FullSizeOf(this NSView view, NSView parent, nfloat? margin = null) => 
			FullSizeOf(view, parent, new Margins((float)margin.GetValueOrDefault(DefaultMargin)));

	    public static IEnumerable<FluentLayout> FullSizeOf(this NSView view, NSView parent, Margins margins)
		{
			margins = margins ?? new Margins();

			return new List<FluentLayout>
			{
				view.AtTopOf(parent, margins.Top).WithIdentifier("Top"),
				view.AtBottomOf(parent, margins.Bottom).WithIdentifier("Bottom"),
				view.AtLeftOf(parent, margins.Left).WithIdentifier("Left"),
				view.AtRightOf(parent, margins.Right).WithIdentifier("Right")
			};
		}

	    public static FluentLayout GetLayoutById(this IEnumerable<FluentLayout> layouts, string identifier) => 
			layouts.FirstOrDefault(x => x.Identifier.Equals(identifier));

	    public static IEnumerable<FluentLayout> VerticalStackPanelConstraints(this NSView parentView, Margins margins, params NSView[] views) =>
			AdvancedVerticalStackPanelConstraints(parentView, margins, views: views);
   
		/// <summary>
		/// Vertical stack panel constraints with support for children independent left, right and top margins
		/// and a multiplier factor for all margins applied. The multiplier can be useful when dealing with iPad screens.
		/// Example:
		/// 
		/// scrollView.AddConstraints(scrollView.AdvancedVerticalStackPanelConstraints(null,
		///      childrenLeftMargins: new float[] { 15, 0, 15, 0, 0, 15 },
		///      childrenTopMargins: new float[] { 15, 5, 15, 5, 8, 15, 22, 8, 8, 28, 28 },
		///      marginMultiplier: 2f,
		///      views: scrollView.Subviews)
		/// );
		/// </summary>
		public static IEnumerable<FluentLayout> AdvancedVerticalStackPanelConstraints(this NSView parentView,
		                                                                              Margins margins,
		                                                                              float[] childrenLeftMargins = null,
		                                                                              float[] childrenTopMargins = null,
		                                                                              float[] childrenRightMargins = null,
		                                                                              float marginMultiplier = 1,
		                                                                              params NSView[] views)
		{
			string previousIdentifierPrefix = null;
			margins = margins ?? new Margins();
			var layouts = new List<FluentLayout>();

			var count = views.Length;
			for (var i = 0; i < count; i++)
			{
				var view = views[i];
				var viewIdentifierPrefix = $"{parentView.AccessibilityIdentifier ?? "VerticalStackPanel"}-{view.AccessibilityIdentifier ?? i.ToString()}-";

				float childLeftMargin;
				childrenLeftMargins.TryGetElement(i, out childLeftMargin);
				var marginLeft = Math.Max(margins.Left, childLeftMargin) * marginMultiplier;
				layouts.Add(view.Left()
					.EqualTo()
					.LeftOf(parentView)
					.Plus(marginLeft)
					.WithIdentifier(viewIdentifierPrefix + "Left"));

				float childRightMargin;
				childrenRightMargins.TryGetElement(i, out childRightMargin);
				var marginRight = Math.Max(margins.Right, childRightMargin) * marginMultiplier;
				layouts.Add(view.Width()
					.EqualTo()
					.WidthOf(parentView)
					.Minus(marginRight + marginLeft)
					.WithIdentifier(viewIdentifierPrefix + "Width"));

				float childTopMargin;
				childrenTopMargins.TryGetElement(i, out childTopMargin);

				layouts.Add(i == 0
					? view.Top()
						.EqualTo()
						.TopOf(parentView)
						.Plus(Math.Max(margins.Top, childTopMargin)*marginMultiplier)
						.WithIdentifier(viewIdentifierPrefix + "Top")
					: view.Top()
						.EqualTo()
						.BottomOf(views[i - 1])
						.Plus(Math.Max(margins.VSpacing, childTopMargin)*marginMultiplier)
						.WithIdentifier(viewIdentifierPrefix + "Top"));

				previousIdentifierPrefix = viewIdentifierPrefix;
			}

			if (parentView is NSScrollView)
				layouts.Add(views[views.Length - 1].Bottom()
					.EqualTo()
					.BottomOf(parentView)
					.Minus(margins.Bottom * marginMultiplier)
					.WithIdentifier(previousIdentifierPrefix + "Bottom"));

			return layouts;
		}
    }
}
