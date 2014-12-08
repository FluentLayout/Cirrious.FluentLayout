// AdvancedFluentLayoutExtensions.cs
// (c) Copyright Cirrious Ltd. http://www.cirrious.com
// MvvmCross is licensed using Microsoft Public License (Ms-PL)
// Contributions and inspirations noted in readme.md and license.txt
// 
// Project Lead - Stuart Lodge, @slodge, me@slodge.com

using System.Collections.Generic;
using UIKit;
using System;

namespace Cirrious.FluentLayouts.Touch
{
    public static class AdvancedFluentLayoutExtensions
    {
        public static FluentLayout AtTopOf(this UIView view, UIView parentView, nfloat? margin = null)
        {
			return view.Top().EqualTo().TopOf(parentView).Plus(null == margin ? 0 : margin.Value);
        }

		public static FluentLayout AtLeftOf(this UIView view, UIView parentView, nfloat? margin = null)
        {
			return view.Left().EqualTo().LeftOf(parentView).Plus(null == margin ? 0 : margin.Value);
        }

		public static FluentLayout AtRightOf(this UIView view, UIView parentView, nfloat? margin = null)
        {
			return view.Right().EqualTo().RightOf(parentView).Minus(null == margin ? 0 : margin.Value);
        }

		public static FluentLayout AtBottomOf(this UIView view, UIView parentView, nfloat? margin = null)
        {
			return view.Bottom().EqualTo().BottomOf(parentView).Minus(null == margin ? 0 : margin.Value);
        }

		public static FluentLayout Below(this UIView view, UIView previous, nfloat? margin = null)
        {
			return view.Top().EqualTo().BottomOf(previous).Plus(null == margin ? 0 : margin.Value);
        }

		public static FluentLayout Above(this UIView view, UIView previous, nfloat? margin = null)
        {
			return view.Bottom().EqualTo().TopOf(previous).Minus(null == margin ? 0 : margin.Value);
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
			return view.Width().EqualTo().WidthOf(previous).WithMultiplier(null == scale ? 1 : scale.Value);
        }

        public static FluentLayout WithSameHeight(this UIView view, UIView previous)
        {
            return view.Height().EqualTo().HeightOf(previous);
        }

		public static FluentLayout WithRelativeHeight(this UIView view, UIView previous, nfloat? scale = null)
        {
			return view.Height().EqualTo().HeightOf(previous).WithMultiplier(null == scale ? 1 : scale.Value);
        }

		public static FluentLayout ToRightOf(this UIView view, UIView previous, nfloat? margin = null)
        {
			return view.Left().EqualTo().RightOf(previous).Plus(null == margin ? 0 : margin.Value);
        }

		public static FluentLayout ToLeftOf(this UIView view, UIView previous, nfloat? margin = null)
        {
			return view.Right().EqualTo().LeftOf(previous).Minus(null == margin ? 0 : margin.Value);
        }

		public static IEnumerable<FluentLayout> FullWidthOf(this UIView view, UIView parent, nfloat? margin = null)
        {
			yield return view.Left().EqualTo().LeftOf(parent).Plus(null == margin ? 0 : margin.Value);
			yield return view.Right().EqualTo().RightOf(parent).Minus(null == margin ? 0 : margin.Value);
        }

		public static IEnumerable<FluentLayout> FullHeightOf(this UIView view, UIView parent, nfloat? margin = null)
        {
			yield return view.Top().EqualTo().TopOf(parent).Plus(null == margin ? 0 : margin.Value);
			yield return view.Bottom().EqualTo().BottomOf(parent).Minus(null == margin ? 0 : margin.Value);
        }

        public static IEnumerable<FluentLayout> VerticalStackPanelConstraints(this UIView parentView, Margins margins,
                                                                              params UIView[] views)
        {
            margins = margins ?? new Margins();

            UIView previous = null;
            foreach (var view in views)
            {
                yield return view.Left().EqualTo().LeftOf(parentView).Plus(margins.Left);
                yield return view.Width().EqualTo().WidthOf(parentView).Minus(margins.Right + margins.Left);
                if (previous != null)
                    yield return view.Top().EqualTo().BottomOf(previous).Plus(margins.VSpacing);
                else
                    yield return view.Top().EqualTo().TopOf(parentView).Plus(margins.Top);
                previous = view;
            }
            if (parentView is UIScrollView)
                yield return previous.Bottom().EqualTo().BottomOf(parentView).Minus(margins.Bottom);
        }
    }
}
