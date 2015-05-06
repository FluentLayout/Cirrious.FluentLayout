// AdvancedFluentLayoutExtensions.cs
// (c) Copyright Cirrious Ltd. http://www.cirrious.com
// MvvmCross is licensed using Microsoft Public License (Ms-PL)
// Contributions and inspirations noted in readme.md and license.txt
// 
// Project Lead - Stuart Lodge, @slodge, me@slodge.com
//
//Softlion: VerticalStackPanelConstraints auto height panel view (ie: parent view) in all cases !

using System;
using System.Collections.Generic;
using System.Linq;
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

        public static FluentLayout WithSameCenterX(this UIView view, UIView previous, nfloat? margin = null)
        {
            return view.CenterX().EqualTo().CenterXOf(previous).Plus(margin.GetValueOrDefault(DefaultMargin));
        }

        public static FluentLayout WithSameCenterY(this UIView view, UIView previous, nfloat? margin = null)
        {
            return view.CenterY().EqualTo().CenterYOf(previous).Plus(margin.GetValueOrDefault(DefaultMargin));
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

        public static FluentLayout WidthEqualHeight(this UIView view, UIView previous, nfloat? margin=null, nfloat? scale = null)
        {
            return view.Width().EqualTo().HeightOf(previous).Minus(2*margin.GetValueOrDefault(DefaultMargin)).WithMultiplier(scale.GetValueOrDefault(DefaultScale));
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

        public static IEnumerable<FluentLayout> WithSameRectOf(this UIView view, UIView parent, nfloat? margin = null)
        {
            return
                view.FullWidthOf(parent, margin)
                .Concat(view.FullHeightOf(parent, margin))
                .Concat(view.AtTopLeftOf(parent, margin));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentView"></param>
        /// <param name="margins"></param>
        /// <param name="views"></param>
        /// <returns></returns>
        /// <remarks>The last view is attached to the bottom of its parent only if the parent is based on UIScrollView</remarks>
        public static IEnumerable<FluentLayout> VerticalStackPanelConstraints(this UIView parentView, Margins margins,
                                                                              params UIView[] views)
        {
            margins = margins ?? new Margins();

            UIView previous = null;
            foreach (var view in views)
            {
                yield return view.AtLeftOf(parentView, margins.Left);
                yield return view.AtRightOf(parentView, margins.Right);
                if (previous != null)
                    yield return view.Below(previous,margins.VSpacing);
                else
                    yield return view.AtTopOf(parentView, margins.Top);
                previous = view;
            }

            if (parentView is UIScrollView)
                yield return previous.Bottom().EqualTo().BottomOf(parentView).Minus(margins.Bottom);
        }

        public static IEnumerable<FluentLayout> AtTopLeftOf(this UIView view, UIView parentView, nfloat? margin = null)
        {
            yield return view.Top().EqualTo().TopOf(parentView).Plus(margin.GetValueOrDefault(DefaultMargin));
            yield return view.Left().EqualTo().LeftOf(parentView).Plus(margin.GetValueOrDefault(DefaultMargin));
        }

        public static FluentLayout AtLeastRightOf(this UIView view, UIView parentView, nfloat? margin = null)
        {
            return view.Right().GreaterThanOrEqualTo().RightOf(parentView).Plus(margin.GetValueOrDefault(DefaultMargin));
        }

        public static FluentLayout AtMostRightOf(this UIView view, UIView previous, nfloat? margin = null)
        {
            return view.Right().LessThanOrEqualTo().RightOf(previous).Minus(margin.GetValueOrDefault(DefaultMargin));
        }

        public static FluentLayout AtMostLeftOf(this UIView view, UIView previous, nfloat? margin = null)
        {
            return view.Right().LessThanOrEqualTo().LeftOf(previous).Minus(margin.GetValueOrDefault(DefaultMargin));
        }

        public static FluentLayout AtLeastLeftOf(this UIView view, UIView previous, nfloat? margin = null)
        {
            return view.Left().GreaterThanOrEqualTo().LeftOf(previous).Plus(margin.GetValueOrDefault(DefaultMargin));
        }

        public static FluentLayout AtLeastBottomOf(this UIView view, UIView parentView, nfloat? margin = null)
        {
            return view.Bottom().GreaterThanOrEqualTo().BottomOf(parentView).Plus(margin.GetValueOrDefault(DefaultMargin));
        }

        public static FluentLayout AtMostBottomOf(this UIView view, UIView parentView, nfloat? margin = null)
        {
            return view.Bottom().LessThanOrEqualTo().BottomOf(parentView).Minus(margin.GetValueOrDefault(DefaultMargin));
        }
    }
}
