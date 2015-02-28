// AdvancedFluentLayoutExtensions.cs
// (c) Copyright Cirrious Ltd. http://www.cirrious.com
// MvvmCross is licensed using Microsoft Public License (Ms-PL)
// Contributions and inspirations noted in readme.md and license.txt
// 
// Project Lead - Stuart Lodge, @slodge, me@slodge.com

using System;
using System.Collections.Generic;
using AppKit;

namespace Cirrious.FluentLayouts.Mac
{
    public static class AdvancedFluentLayoutExtensions
    {
		//
		// Static Methods
		//
		public static FluentLayout Above (this NSView view, NSView previous, float margin = 0)
		{
			return view.Bottom ().EqualTo (0).TopOf (previous).Minus (margin);
		}

		public static FluentLayout AtBottomOf (this NSView view, NSView parentView, float margin = 0)
		{
			return view.Bottom ().EqualTo (0).BottomOf (parentView).Minus (margin);
		}

		public static FluentLayout AtLeftOf (this NSView view, NSView parentView, float margin = 0)
		{
			return view.Left ().EqualTo (0).LeftOf (parentView).Plus (margin);
		}

		public static FluentLayout AtRightOf (this NSView view, NSView parentView, float margin = 0)
		{
			return view.Right ().EqualTo (0).RightOf (parentView).Minus (margin);
		}

		public static FluentLayout AtTopOf (this NSView view, NSView parentView, float margin = 0)
		{
			return view.Top ().EqualTo (0).TopOf (parentView).Plus (margin);
		}

		public static FluentLayout Below (this NSView view, NSView previous, float margin = 0)
		{
			return view.Top ().EqualTo (0).BottomOf (previous).Plus (margin);
		}

		public static IEnumerable<FluentLayout> FullHeightOf (this NSView view, NSView parent, float margin = 0)
		{
			yield return view.Top ().EqualTo (0).TopOf (parent).Plus (margin);
			yield return view.Bottom ().EqualTo (0).BottomOf (parent).Minus (margin);
			yield break;
		}

		public static IEnumerable<FluentLayout> FullWidthOf (this NSView view, NSView parent, float margin = 0)
		{
			yield return view.Left ().EqualTo (0).LeftOf (parent).Plus (margin);
			yield return view.Right ().EqualTo (0).RightOf (parent).Minus (margin);
			yield break;
		}

		public static FluentLayout ToLeftOf (this NSView view, NSView previous, float margin = 0)
		{
			return view.Right ().EqualTo (0).LeftOf (previous).Minus (margin);
		}

		public static FluentLayout ToRightOf (this NSView view, NSView previous, float margin = 0)
		{
			return view.Left ().EqualTo (0).RightOf (previous).Plus (margin);
		}

		public static IEnumerable<FluentLayout> VerticalStackPanelConstraints (this NSView parentView, Margins margins, params NSView[] views)
		{
			margins = (margins ?? new Margins ());
			NSView uIView = null;
			try {
				for (int i = 0; i < views.Length; i++) {
					NSView uIView2 = views [i];
					yield return uIView2.Left ().EqualTo (0).LeftOf (parentView).Plus (margins.Left);
					yield return uIView2.Width ().EqualTo (0).WidthOf (parentView).Minus (margins.Right + margins.Left);
					if (uIView != null) {
						yield return uIView2.Top ().EqualTo (0).BottomOf (uIView).Plus (margins.VSpacing);
					}
					else {
						yield return uIView2.Top ().EqualTo (0).TopOf (parentView).Plus (margins.Top);
					}
					uIView = uIView2;
				}
			}
			finally {
			}
			if (parentView is NSScrollView) {
				yield return uIView.Bottom ().EqualTo (0).BottomOf (parentView).Minus (margins.Bottom);
			}
			yield break;
		}

		public static FluentLayout WithRelativeHeight (this NSView view, NSView previous, float scale = 1)
		{
			return view.Height ().EqualTo (0).HeightOf (previous).WithMultiplier (scale);
		}

		public static FluentLayout WithRelativeWidth (this NSView view, NSView previous, float scale = 1)
		{
			return view.Width ().EqualTo (0).WidthOf (previous).WithMultiplier (scale);
		}

		public static FluentLayout WithSameBottom (this NSView view, NSView previous)
		{
			return view.Bottom ().EqualTo (0).BottomOf (previous);
		}

		public static FluentLayout WithSameCenterX (this NSView view, NSView previous)
		{
			return view.CenterX ().EqualTo (0).CenterXOf (previous);
		}

		public static FluentLayout WithSameCenterY (this NSView view, NSView previous)
		{
			return view.CenterY ().EqualTo (0).CenterYOf (previous);
		}

		public static FluentLayout WithSameHeight (this NSView view, NSView previous)
		{
			return view.Height ().EqualTo (0).HeightOf (previous);
		}

		public static FluentLayout WithSameLeft (this NSView view, NSView previous)
		{
			return view.Left ().EqualTo (0).LeftOf (previous);
		}

		public static FluentLayout WithSameRight (this NSView view, NSView previous)
		{
			return view.Right ().EqualTo (0).RightOf (previous);
		}

		public static FluentLayout WithSameTop (this NSView view, NSView previous)
		{
			return view.Top ().EqualTo (0).TopOf (previous);
		}

		public static FluentLayout WithSameWidth (this NSView view, NSView previous)
		{
			return view.Width ().EqualTo (0).WidthOf (previous);
		}
    }
}
