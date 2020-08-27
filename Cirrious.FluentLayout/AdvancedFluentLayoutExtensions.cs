// AdvancedFluentLayoutExtensions.cs
// (c) Copyright Cirrious Ltd. http://www.cirrious.com
// MvvmCross is licensed using Microsoft Public License (Ms-PL)
// Contributions and inspirations noted in readme.md and license.txt
// 
// Project Lead - Stuart Lodge, @slodge, me@slodge.com

using System;
using System.Collections.Generic;
using System.Linq;
using UIKit;
using Cirrious.FluentLayouts.Touch.Extensions;

namespace Cirrious.FluentLayouts.Touch
{
    public static class AdvancedFluentLayoutExtensions
    {
        const float DefaultMargin = 0;
        const float DefaultScale = 1;

        public static FluentLayout AtTopOf(this UIView view, UIView parentView, nfloat? margin = null) =>
            view.Top().EqualTo().TopOf(parentView).Plus(margin.GetValueOrDefault(DefaultMargin));

        public static FluentLayout AtTopOfSafeArea(this UIView view, UIView parentView, nfloat? margin = null) =>
            UIDevice.CurrentDevice.CheckSystemVersion(11, 0)
                    ? view.Top().EqualTo().TopOf(parentView.SafeAreaLayoutGuide).Plus(margin.GetValueOrDefault(DefaultMargin))
                    : view.AtTopOf(parentView, margin);        

        public static FluentLayout AtLeftOf(this UIView view, UIView parentView, nfloat? margin = null) =>
			view.Left().EqualTo().LeftOf(parentView).Plus(margin.GetValueOrDefault(DefaultMargin));

        public static FluentLayout AtLeftOfSafeArea(this UIView view, UIView parentView, nfloat? margin = null) =>
            UIDevice.CurrentDevice.CheckSystemVersion(11, 0)
                    ? view.Left().EqualTo().LeftOf(parentView.SafeAreaLayoutGuide).Plus(margin.GetValueOrDefault(DefaultMargin))
                    : view.AtLeftOf(parentView, margin);

        public static FluentLayout AtRightOf(this UIView view, UIView parentView, nfloat? margin = null) =>
			view.Right().EqualTo().RightOf(parentView).Minus(margin.GetValueOrDefault(DefaultMargin));

        public static FluentLayout AtRightOfSafeArea(this UIView view, UIView parentView, nfloat? margin = null) =>
            UIDevice.CurrentDevice.CheckSystemVersion(11, 0)
                    ? view.Right().EqualTo().RightOf(parentView.SafeAreaLayoutGuide).Minus(margin.GetValueOrDefault(DefaultMargin))
                    : view.AtRightOf(parentView, margin);

        public static FluentLayout AtBottomOf(this UIView view, UIView parentView, nfloat? margin = null) =>
			view.Bottom().EqualTo().BottomOf(parentView).Minus(margin.GetValueOrDefault(DefaultMargin));

        public static FluentLayout AtBottomOfSafeArea(this UIView view, UIView parentView, nfloat? margin = null) =>
            UIDevice.CurrentDevice.CheckSystemVersion(11, 0)
                    ? view.Bottom().EqualTo().BottomOf(parentView.SafeAreaLayoutGuide).Minus(margin.GetValueOrDefault(DefaultMargin))
                    : view.AtBottomOf(parentView, margin);

        public static FluentLayout AtLeadingOf(this UIView view, UIView parentView, nfloat? margin = null) =>
        view.Leading().EqualTo().LeadingOf(parentView).Plus(margin.GetValueOrDefault(DefaultMargin));

        public static FluentLayout AtTrailingOf(this UIView view, UIView parentView, nfloat? margin = null) =>
        view.Trailing().EqualTo().TrailingOf(parentView).Minus(margin.GetValueOrDefault(DefaultMargin));

        public static FluentLayout Below(this UIView view, UIView previous, nfloat? margin = null) =>
			view.Top().EqualTo().BottomOf(previous).Plus(margin.GetValueOrDefault(DefaultMargin));

        public static FluentLayout Above(this UIView view, UIView previous, nfloat? margin = null) =>
			view.Bottom().EqualTo().TopOf(previous).Minus(margin.GetValueOrDefault(DefaultMargin));
	    
	public static FluentLayout WithAspectRatio(this UIView view, nfloat ratio) =>
            		view.Height().EqualTo().WidthOf(view).WithMultiplier(ratio);

        public static FluentLayout WithSameLeft(this UIView view, UIView previous) => view.Left().EqualTo().LeftOf(previous);

        public static FluentLayout WithSameTop(this UIView view, UIView previous) => view.Top().EqualTo().TopOf(previous);

        public static FluentLayout WithSameCenterX(this UIView view, UIView previous) => view.CenterX().EqualTo().CenterXOf(previous);

        public static FluentLayout WithSameCenterY(this UIView view, UIView previous) => view.CenterY().EqualTo().CenterYOf(previous);

        public static FluentLayout WithSameRight(this UIView view, UIView previous) => view.Right().EqualTo().RightOf(previous);

        public static FluentLayout WithSameWidth(this UIView view, UIView previous) => view.Width().EqualTo().WidthOf(previous);

        public static FluentLayout WithSameBottom(this UIView view, UIView previous) => view.Bottom().EqualTo().BottomOf(previous);

        public static FluentLayout WithSameLeading(this UIView view, UIView previous) => view.Leading().EqualTo().LeadingOf(previous);

        public static FluentLayout WithSameTrailing(this UIView view, UIView previous) => view.Trailing().EqualTo().TrailingOf(previous);

        public static FluentLayout WithRelativeWidth(this UIView view, UIView previous, nfloat? scale = null) =>
			view.Width().EqualTo().WidthOf(previous).WithMultiplier(scale.GetValueOrDefault(DefaultScale));

        public static FluentLayout WithSameHeight(this UIView view, UIView previous) => view.Height().EqualTo().HeightOf(previous);

        public static FluentLayout WithRelativeHeight(this UIView view, UIView previous, nfloat? scale = null) =>
			view.Height().EqualTo().HeightOf(previous).WithMultiplier(scale.GetValueOrDefault(DefaultScale));

        public static FluentLayout ToRightOf(this UIView view, UIView previous, nfloat? margin = null) =>
			view.Left().EqualTo().RightOf(previous).Plus(margin.GetValueOrDefault(DefaultMargin));

        public static FluentLayout ToLeftOf(this UIView view, UIView previous, nfloat? margin = null) =>
			view.Right().EqualTo().LeftOf(previous).Minus(margin.GetValueOrDefault(DefaultMargin));

        public static FluentLayout ToTrailingOf(this UIView view, UIView previous, nfloat? margin = null) =>
            view.Leading().EqualTo().TrailingOf(previous).Plus(margin.GetValueOrDefault(DefaultMargin));

        public static FluentLayout ToLeadingOf(this UIView view, UIView previous, nfloat? margin = null) =>
        view.Trailing().EqualTo().LeadingOf(previous).Minus(margin.GetValueOrDefault(DefaultMargin));

		public static FluentLayout ToLeftMargin(this UIView view, UIView previous) =>
			view.Leading().EqualTo().LeadingMarginOf(previous);

		public static FluentLayout ToRightMargin(this UIView view, UIView previous) =>
			view.Trailing().EqualTo().TrailingMarginOf(previous);

		public static FluentLayout ToTopMargin(this UIView view, UIView previous) =>
			view.Top().EqualTo().TopMarginOf(previous);

		public static FluentLayout ToBottomMargin(this UIView view, UIView previous) =>
			view.Bottom().EqualTo().BottomMarginOf(previous);
	    
	public static FluentLayout ToLeftOfCenterOf(this UIView view, UIView previous, nfloat? margin = null) =>
		view.Right().EqualTo().CenterXOf(previous).Minus(margin.GetValueOrDefault(0));
	    
	public static FluentLayout ToRightOfCenterOf(this UIView view, UIView previous, nfloat? margin = null) =>
		view.Left().EqualTo().CenterXOf(previous).Plus(margin.GetValueOrDefault(0));
	    
	public static FluentLayout AboveCenterOf(this UIView view, UIView previous, nfloat? margin = null) =>
		view.Bottom().EqualTo().CenterYOf(previous).Minus(margin.GetValueOrDefault(0));
	    
	public static FluentLayout BelowCenterOf(this UIView view, UIView previous, nfloat? margin = null) =>
		view.Top().EqualTo().CenterYOf(previous).Plus(margin.GetValueOrDefault(0));

        public static IEnumerable<FluentLayout> FullWidthOf(this UIView view, UIView parent, nfloat? margin = null)
        {
			var marginValue = margin.GetValueOrDefault(DefaultMargin);

	        return new List<FluentLayout>
	        {
				view.AtLeftOf(parent, marginValue).WithIdentifier("Left"),
		        view.AtRightOf(parent, marginValue).WithIdentifier("Right")
	        };
        }

        public static IEnumerable<FluentLayout> FullHeightOf(this UIView view, UIView parent, nfloat? margin = null)
        {
			var marginValue = margin.GetValueOrDefault(DefaultMargin);

			return new List<FluentLayout>
			{
				view.AtTopOf(parent, marginValue).WithIdentifier("Top"),
				view.AtBottomOf(parent, marginValue).WithIdentifier("Bottom")
			};
        }

		public static IEnumerable<FluentLayout> FullSizeOf(this UIView view, UIView parent, nfloat? margin = null) => 
			FullSizeOf(view, parent, new Margins((float)margin.GetValueOrDefault(DefaultMargin)));

	    public static IEnumerable<FluentLayout> FullSizeOf(this UIView view, UIView parent, Margins margins)
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

	    public static IEnumerable<FluentLayout> VerticalStackPanelConstraints(this UIView parentView, Margins margins, params UIView[] views) =>
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
		public static IEnumerable<FluentLayout> AdvancedVerticalStackPanelConstraints(this UIView parentView,
		                                                                              Margins margins,
		                                                                              float[] childrenLeftMargins = null,
		                                                                              float[] childrenTopMargins = null,
		                                                                              float[] childrenRightMargins = null,
		                                                                              float marginMultiplier = 1,
		                                                                              params UIView[] views)
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

			if (parentView is UIScrollView)
				layouts.Add(views[views.Length - 1].Bottom()
					.EqualTo()
					.BottomOf(parentView)
					.Minus(margins.Bottom * marginMultiplier)
					.WithIdentifier(previousIdentifierPrefix + "Bottom"));

			return layouts;
		}
    }
}
