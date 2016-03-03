// AdvancedFluentLayoutExtensions.cs
// (c) Copyright Cirrious Ltd. http://www.cirrious.com
// MvvmCross is licensed using Microsoft Public License (Ms-PL)
// Contributions and inspirations noted in readme.md and license.txt
// 
// Project Lead - Stuart Lodge, @slodge, me@slodge.com

using System;
using System.Collections.Generic;
using UIKit;

namespace Cirrious.FluentLayouts.Touch
{
    public static class AdvancedFluentLayoutExtensions
    {
		const float DefaultMargin = 0;
		const float DefaultScale = 1;

        public static FluentLayout AtTopOf(this UIView view, UIView parentView, nfloat? margin = null)
        {
			return view.Top().EqualTo().TopOf(parentView).Plus(margin.GetValueOrDefault(DefaultMargin));
        }

        public static FluentLayout AtLeftOf(this UIView view, UIView parentView, nfloat? margin = null)
        {
			return view.Left().EqualTo().LeftOf(parentView).Plus(margin.GetValueOrDefault(DefaultMargin));
        }

        public static FluentLayout AtRightOf(this UIView view, UIView parentView, nfloat? margin = null)
        {
			return view.Right().EqualTo().RightOf(parentView).Minus(margin.GetValueOrDefault(DefaultMargin));
        }

        public static FluentLayout AtBottomOf(this UIView view, UIView parentView, nfloat? margin = null)
        {
			return view.Bottom().EqualTo().BottomOf(parentView).Minus(margin.GetValueOrDefault(DefaultMargin));
        }

        public static FluentLayout Below(this UIView view, UIView previous, nfloat? margin = null)
        {
			return view.Top().EqualTo().BottomOf(previous).Plus(margin.GetValueOrDefault(DefaultMargin));
        }

        public static FluentLayout Above(this UIView view, UIView previous, nfloat? margin = null)
        {
			return view.Bottom().EqualTo().TopOf(previous).Minus(margin.GetValueOrDefault(DefaultMargin));
        }

        public static FluentLayout WithSameLeft(this UIView view, UIView previous)
        {
            return view.Left().EqualTo().LeftOf(previous);
        }

        public static FluentLayout WithSameTop(this UIView view, UIView previous)
        {
            return view.Top().EqualTo().TopOf(previous);
        }

        public static FluentLayout WithSameCenterX(this UIView view, UIView previous)
        {
            return view.CenterX().EqualTo().CenterXOf(previous);
        }

        public static FluentLayout WithSameCenterY(this UIView view, UIView previous)
        {
            return view.CenterY().EqualTo().CenterYOf(previous);
        }

        public static FluentLayout WithSameRight(this UIView view, UIView previous)
        {
            return view.Right().EqualTo().RightOf(previous);
        }

        public static FluentLayout WithSameWidth(this UIView view, UIView previous)
        {
            return view.Width().EqualTo().WidthOf(previous);
        }

        public static FluentLayout WithSameBottom(this UIView view, UIView previous)
        {
            return view.Bottom().EqualTo().BottomOf(previous);
        }

        public static FluentLayout WithRelativeWidth(this UIView view, UIView previous, nfloat? scale = null)
        {
			return view.Width().EqualTo().WidthOf(previous).WithMultiplier(scale.GetValueOrDefault(DefaultScale));
        }

        public static FluentLayout WithSameHeight(this UIView view, UIView previous)
        {
            return view.Height().EqualTo().HeightOf(previous);
        }

        public static FluentLayout WithRelativeHeight(this UIView view, UIView previous, nfloat? scale = null)
        {
			return view.Height().EqualTo().HeightOf(previous).WithMultiplier(scale.GetValueOrDefault(DefaultScale));
        }

        public static FluentLayout ToRightOf(this UIView view, UIView previous, nfloat? margin = null)
        {
			return view.Left().EqualTo().RightOf(previous).Plus(margin.GetValueOrDefault(DefaultMargin));
        }

        public static FluentLayout ToLeftOf(this UIView view, UIView previous, nfloat? margin = null)
        {
			return view.Right().EqualTo().LeftOf(previous).Minus(margin.GetValueOrDefault(DefaultMargin));
        }

        public static IEnumerable<FluentLayout> FullWidthOf(this UIView view, UIView parent, nfloat? margin = null)
        {
			var marginValue = margin.GetValueOrDefault(DefaultMargin);
			yield return view.Left().EqualTo().LeftOf(parent).Plus(marginValue);
			yield return view.Right().EqualTo().RightOf(parent).Minus(marginValue);
        }

        public static IEnumerable<FluentLayout> FullHeightOf(this UIView view, UIView parent, nfloat? margin = null)
        {
			var marginValue = margin.GetValueOrDefault(DefaultMargin);
			yield return view.Top().EqualTo().TopOf(parent).Plus(marginValue);
			yield return view.Bottom().EqualTo().BottomOf(parent).Minus(marginValue);
        }

        public static IEnumerable<FluentLayout> VerticalStackPanelConstraints(this UIView parentView, Margins margins,
                                                                              params UIView[] views)
        {
	        return AdvancedVerticalStackPanelConstraints(parentView, margins, views: views);
		}

		/// <summary>
		/// Vertical stack panel constraints with support for children independent left, right and top margins
		/// and a multiplier factor for all margins applied. The multiplier can be useful when dealing with ipad screens.
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
			margins = margins ?? new Margins();

			var count = views.Length;
			for (var i = 0; i < count; i++)
			{
				float childLeftMargin;
				childrenLeftMargins.TryGetElement(i, out childLeftMargin);
				var marginLeft = Math.Max(margins.Left, childLeftMargin) * marginMultiplier;
				yield return views[i].Left().EqualTo().LeftOf(parentView).Plus(marginLeft);

				float childRightMargin;
				childrenRightMargins.TryGetElement(i, out childRightMargin);
				var marginRight = Math.Max(margins.Right, childRightMargin) * marginMultiplier;
				yield return views[i].Width().EqualTo().WidthOf(parentView).Minus(marginRight + marginLeft);

				float childTopMargin;
				childrenTopMargins.TryGetElement(i, out childTopMargin);

				if (i == 0)
					yield return views[i].Top().EqualTo().TopOf(parentView).Plus(Math.Max(margins.Top, childTopMargin) * marginMultiplier);
				else
					yield return views[i].Top().EqualTo().BottomOf(views[i - 1]).Plus(Math.Max(margins.VSpacing, childTopMargin) * marginMultiplier);
			}

			if (parentView is UIScrollView)
				yield return views[views.Length - 1].Bottom().EqualTo().BottomOf(parentView).Minus(margins.Bottom * marginMultiplier);
		}
	}
}
