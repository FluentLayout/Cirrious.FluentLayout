// AdvancedFluentLayoutExtensions.cs
// (c) Copyright Cirrious Ltd. http://www.cirrious.com
// MvvmCross is licensed using Microsoft Public License (Ms-PL)
// Contributions and inspirations noted in readme.md and license.txt
// 
// Project Lead - Stuart Lodge, @slodge, me@slodge.com

using System;
using System.Collections.Generic;
using UIKit;
using Cirrious.FluentLayouts.Touch.Extensions;

namespace Cirrious.FluentLayouts.Touch
{
    public static class AdvancedFluentLayoutExtensions
    {
		const float DefaultMargin = 0;
		const float DefaultScale = 1;

        /// <summary>
        /// Used to create a LayoutConstraint that offsets the View's top most edge from the top most edge of the parent view a.k.a. as the secondItem or relatedItem. 
        /// Implies a Container and child layout relationship
        /// </summary>
        /// <param name="view">The view to be laid out</param>
        /// <param name="parentView">The related\parent view</param>
        /// <param name="margin">Any vertical space to increase the offset by</param>
        /// <remarks>Uses NSLayoutAttribute.Top</remarks>
        /// <returns>A FluentLayout</returns>
        public static FluentLayout AtTopOf(this UIView view, UIView parentView, nfloat? margin = null) =>
			view.Top().EqualTo().TopOf(parentView).Plus(margin.GetValueOrDefault(DefaultMargin));

        /// <summary>
        /// Used to create a LayoutConstraint that offsets the View's left most edge from the left most edge of the parent view a.k.a. as the secondItem or relatedItem. 
        /// Implies a Container and child layout relationship
        /// </summary>
        /// <param name="view">The view to be laid out</param>
        /// <param name="parentView">The related\parent view</param>
        /// <param name="margin">Any horizontal space to increase the offset by</param>
        /// <remarks>Uses NSLayoutAttribute.Left</remarks>
        /// <returns>A FluentLayout</returns>
        public static FluentLayout AtLeftOf(this UIView view, UIView parentView, nfloat? margin = null) =>
			view.Left().EqualTo().LeftOf(parentView).Plus(margin.GetValueOrDefault(DefaultMargin));

        /// <summary>
        /// Used to create a LayoutConstraint that offsets the View's right most edge from the rightmost edge of the parent view a.k.a. as the secondItem or relatedItem. 
        /// Implies a Container and child layout relationship
        /// </summary>
        /// <param name="view">The view to be laid out</param>
        /// <param name="parentView">The related\parent view</param>
        /// <param name="margin">Any horizontal space to increase the offset by</param>
        /// <remarks>Uses NSLayoutAttribute.Right</remarks>
        /// <returns>A FluentLayout</returns>
        public static FluentLayout AtRightOf(this UIView view, UIView parentView, nfloat? margin = null) =>
			view.Right().EqualTo().RightOf(parentView).Minus(margin.GetValueOrDefault(DefaultMargin));

        /// <summary>
        /// Used to create a LayoutConstraint that offsets the View's bottom most edge from the bottom most edge of the parent view a.k.a. as the secondItem or relatedItem. 
        /// Implies a Container and child layout relationship
        /// </summary>
        /// <param name="view">The view to be laid out</param>
        /// <param name="parentView">The related\parent view</param>
        /// <param name="margin">Any vertical space to increase the offset by</param>
        /// <remarks>Uses NSLayoutAttribute.Bottom</remarks>
        /// <returns>A FluentLayout</returns>
        public static FluentLayout AtBottomOf(this UIView view, UIView parentView, nfloat? margin = null) =>
			view.Bottom().EqualTo().BottomOf(parentView).Minus(margin.GetValueOrDefault(DefaultMargin));

        /// <summary>
        /// Used to create a LayoutConstraint that offsets the View's top most edge from the 
        /// bottom edge of <paramref name="previous"/> a.k.a. the secondItem. 
        /// </summary>
        /// <param name="view">The view to be laid out</param>
        /// <param name="previous">The related view</param>
        /// <param name="margin">Any vertical space to increase the offset by</param>
        /// <remarks>Uses NSLayoutAttribute.Top, Implies a sibling, vertically stacked layout relationship</remarks>
        /// <returns>A FluentLayout</returns>
        public static FluentLayout Below(this UIView view, UIView previous, nfloat? margin = null) =>
			view.Top().EqualTo().BottomOf(previous).Plus(margin.GetValueOrDefault(DefaultMargin));

        /// <summary>
        /// Used to create a LayoutConstraint that offsets the View's bottom most edge from the 
        /// top edge of <paramref name="following"/> a.k.a. the secondItem. 
        /// </summary>
        /// <param name="view">The view to be laid out</param>
        /// <param name="previous">The related view</param>
        /// <param name="margin">Any vertical space to increase the offset by</param>
        /// <remarks>Uses NSLayoutAttribute.Bottom. Implies a sibling, vertically stacked layout relationship</remarks>
        /// <returns>A FluentLayout</returns>
        public static FluentLayout Above(this UIView view, UIView previous, nfloat? margin = null) =>
			view.Bottom().EqualTo().TopOf(previous).Minus(margin.GetValueOrDefault(DefaultMargin));

        /// <summary>
        /// Used to create a LayoutConstraint that makes the View's left most edge the 
        /// same as the left edge of <paramref name="related"/> a.k.a. the secondItem. 
        /// </summary>
        /// <param name="view">The view to be laid out</param>
        /// <param name="related">The related view</param>
        /// <remarks>Uses NSLayoutAttribute.Left. For examples of this see <a href="https://github.com/FluentLayout/Cirrious.FluentLayout/blob/master/QuickLayout.Touch/Views/FormView.cs">QuickLayout FormView</a></remarks>
        /// <returns>A FluentLayout</returns>
        public static FluentLayout WithSameLeft(this UIView view, UIView related) => view.Left().EqualTo().LeftOf(related);

        /// <summary>
        /// Used to create a LayoutConstraint that makes the View's top most edge the 
        /// same as the top edge of <paramref name="related"/> a.k.a. the secondItem. 
        /// </summary>
        /// <param name="view">The view to be laid out</param>
        /// <param name="related">The related view</param>
        /// <remarks>Uses NSLayoutAttribute.Top.</remarks>
        /// <returns>A FluentLayout</returns>
        public static FluentLayout WithSameTop(this UIView view, UIView related) => view.Top().EqualTo().TopOf(related);

        public static FluentLayout WithSameCenterX(this UIView view, UIView previous) => view.CenterX().EqualTo().CenterXOf(previous);

        public static FluentLayout WithSameCenterY(this UIView view, UIView previous) => view.CenterY().EqualTo().CenterYOf(previous);

        /// <summary>
        /// Used to create a LayoutConstraint that makes the View's right most edge the 
        /// same as the left edge of <paramref name="related"/> a.k.a. the secondItem. 
        /// </summary>
        /// <param name="view">The view to be laid out</param>
        /// <param name="related">The related view</param>
        /// <remarks>Uses NSLayoutAttribute.Right. For examples of this see <a href="https://github.com/FluentLayout/Cirrious.FluentLayout/blob/master/QuickLayout.Touch/Views/FormView.cs">QuickLayout FormView</a></remarks>
        /// <returns>A FluentLayout</returns>
        public static FluentLayout WithSameRight(this UIView view, UIView related) => view.Right().EqualTo().RightOf(related);

        /// <summary>
        /// Used to create a LayoutConstraint that makes the View's Width the 
        /// same as <paramref name="related"/> a.k.a. the secondItem. 
        /// </summary>
        /// <param name="view">The view to be laid out</param>
        /// <param name="related">The related view</param>
        /// <remarks>Uses NSLayoutAttribute.Width. For examples of this see <a href="https://github.com/FluentLayout/Cirrious.FluentLayout/blob/master/QuickLayout.Touch/Views/FormView.cs">QuickLayout FormView</a></remarks>
        /// <returns>A FluentLayout</returns>
        public static FluentLayout WithSameWidth(this UIView view, UIView related) => view.Width().EqualTo().WidthOf(related);

        /// <summary>
        /// Used to create a LayoutConstraint that makes the View's bottom most edge the 
        /// same as the bottom edge of <paramref name="previous"/> a.k.a. the secondItem. 
        /// </summary>
        /// <param name="view">The view to be laid out</param>
        /// <param name="previous">The related view</param>
        /// <remarks>Uses NSLayoutAttribute.Bottom.</remarks>
        /// <returns>A FluentLayout</returns>
        public static FluentLayout WithSameBottom(this UIView view, UIView previous) => view.Bottom().EqualTo().BottomOf(previous);

        public static FluentLayout WithRelativeWidth(this UIView view, UIView previous, nfloat? scale = null) =>
			view.Width().EqualTo().WidthOf(previous).WithMultiplier(scale.GetValueOrDefault(DefaultScale));

        public static FluentLayout WithSameHeight(this UIView view, UIView previous) => view.Height().EqualTo().HeightOf(previous);

        public static FluentLayout WithRelativeHeight(this UIView view, UIView previous, nfloat? scale = null) =>
			view.Height().EqualTo().HeightOf(previous).WithMultiplier(scale.GetValueOrDefault(DefaultScale));

        /// <summary>
        /// Used to create a LayoutConstraint that makes the View's left most edge the
        /// same as the right edge of <paramref name="related" /> a.k.a. the secondItem.
        /// </summary>
        /// <param name="view">The view to be laid out</param>
        /// <param name="related">The related view</param>
        /// <param name="margin">The margin.</param>
        /// <returns>
        /// A FluentLayout
        /// </returns>
        /// <remarks>
        /// Uses NSLayoutAttribute.Right. For examples of this see <a href="https://github.com/slodge/Cirrious.FluentLayout/blob/master/QuickLayout.Touch/Views/FormView.cs">QuickLayout FormView</a></remarks>
        public static FluentLayout ToRightOf(this UIView view, UIView related, nfloat? margin = null) =>
            view.Left().EqualTo().RightOf(related).Plus(margin.GetValueOrDefault(DefaultMargin));

        public static FluentLayout ToLeftOf(this UIView view, UIView previous, nfloat? margin = null) =>
			view.Right().EqualTo().LeftOf(previous).Minus(margin.GetValueOrDefault(DefaultMargin));

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

			var count = views.Length;
			for (var i = 0; i < count; i++)
			{
				var view = views[i];
				var viewIdentifierPrefix = $"{parentView.AccessibilityIdentifier ?? "VerticalStackPanel"}-{view.AccessibilityIdentifier ?? i.ToString()}-";

				float childLeftMargin;
				childrenLeftMargins.TryGetElement(i, out childLeftMargin);
				var marginLeft = Math.Max(margins.Left, childLeftMargin) * marginMultiplier;
				yield return view.Left().EqualTo().LeftOf(parentView).Plus(marginLeft).WithIdentifier(viewIdentifierPrefix + "Left");

				float childRightMargin;
				childrenRightMargins.TryGetElement(i, out childRightMargin);
				var marginRight = Math.Max(margins.Right, childRightMargin) * marginMultiplier;
				yield return view.Width().EqualTo().WidthOf(parentView).Minus(marginRight + marginLeft).WithIdentifier(viewIdentifierPrefix + "Width");

				float childTopMargin;
				childrenTopMargins.TryGetElement(i, out childTopMargin);

				if (i == 0)
					yield return view.Top().EqualTo().TopOf(parentView).Plus(Math.Max(margins.Top, childTopMargin) * marginMultiplier).WithIdentifier(viewIdentifierPrefix + "Top");
				else
					yield return view.Top().EqualTo().BottomOf(views[i - 1]).Plus(Math.Max(margins.VSpacing, childTopMargin) * marginMultiplier).WithIdentifier(viewIdentifierPrefix + "Top");

				previousIdentifierPrefix = viewIdentifierPrefix;
			}

			if (parentView is UIScrollView)
				yield return views[views.Length - 1].Bottom().EqualTo().BottomOf(parentView).Minus(margins.Bottom * marginMultiplier).WithIdentifier(previousIdentifierPrefix + "Bottom");
		}
    }
}
