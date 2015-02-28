// FluentLayout.cs
// (c) Copyright Cirrious Ltd. http://www.cirrious.com
// MvvmCross is licensed using Microsoft Public License (Ms-PL)
// Contributions and inspirations noted in readme.md and license.txt
// 
// Project Lead - Stuart Lodge, @slodge, me@slodge.com

using System;
using System.Collections.Generic;
using Foundation;
using AppKit;

namespace Cirrious.FluentLayouts.Mac
{
	public class FluentLayout
	{
		//
		// Properties
		//
		public NSLayoutAttribute Attribute {
			get;
			private set;
		}

		public float Constant {
			get;
			private set;
		}

		public float Multiplier {
			get;
			private set;
		}

		public float Priority {
			get;
			private set;
		}

		public NSLayoutRelation Relation {
			get;
			private set;
		}

		public NSLayoutAttribute SecondAttribute {
			get;
			private set;
		}

		public NSObject SecondItem {
			get;
			private set;
		}

		public NSView View {
			get;
			private set;
		}

		//
		// Constructors
		//
		public FluentLayout (NSView view, NSLayoutAttribute attribute, NSLayoutRelation relation, float constant = 0)
		{
			this.View = view;
			this.Attribute = attribute;
			this.Relation = relation;
			this.Multiplier = 1;
			this.Constant = constant;
		}

		public FluentLayout (NSView view, NSLayoutAttribute attribute, NSLayoutRelation relation, NSObject secondItem, NSLayoutAttribute secondAttribute)
		{
			this.View = view;
			this.Attribute = attribute;
			this.Relation = relation;
			this.SecondItem = secondItem;
			this.SecondAttribute = secondAttribute;
			this.Multiplier = 1;
		}

		//
		// Methods
		//
		public FluentLayout BaselineOf (NSObject view2)
		{
			return this.SetSecondItem (view2, NSLayoutAttribute.Baseline);
		}

		public FluentLayout BottomOf (NSObject view2)
		{
			return this.SetSecondItem (view2, NSLayoutAttribute.Bottom);
		}

		public FluentLayout CenterXOf (NSObject view2)
		{
			return this.SetSecondItem (view2, NSLayoutAttribute.CenterX);
		}

		public FluentLayout CenterYOf (NSObject view2)
		{
			return this.SetSecondItem (view2, NSLayoutAttribute.CenterY);
		}

		public FluentLayout HeightOf (NSObject view2)
		{
			return this.SetSecondItem (view2, NSLayoutAttribute.Height);
		}

		public FluentLayout LeadingOf (NSObject view2)
		{
			return this.SetSecondItem (view2, NSLayoutAttribute.Leading);
		}

		public FluentLayout LeftOf (NSObject view2)
		{
			return this.SetSecondItem (view2, NSLayoutAttribute.Left);
		}

		public FluentLayout Minus (float constant)
		{
			this.Constant -= constant;
			return this;
		}

		public FluentLayout Plus (float constant)
		{
			this.Constant += constant;
			return this;
		}

		public FluentLayout RightOf (NSObject view2)
		{
			return this.SetSecondItem (view2, NSLayoutAttribute.Right);
		}

		//		public FluentLayout SetPriority (float priority)
		//		{
		//			this.Priority = (float)priority;
		//			return this;
		//		}

		public FluentLayout SetPriority (float priority)
		{
			this.Priority = priority;
			return this;
		}

		private FluentLayout SetSecondItem (NSObject view2, NSLayoutAttribute attribute2)
		{
			this.ThrowIfSecondItemAlreadySet ();
			this.SecondAttribute = attribute2;
			this.SecondItem = view2;
			return this;
		}

		private void ThrowIfSecondItemAlreadySet ()
		{
			if (this.SecondItem != null) {
				throw new Exception ("You cannot set the second item in a layout relation more than once");
			}
		}

		public IEnumerable<NSLayoutConstraint> ToLayoutConstraints ()
		{
			yield return NSLayoutConstraint.Create (this.View, this.Attribute, this.Relation, this.SecondItem, this.SecondAttribute, this.Multiplier, this.Constant);
			yield break;
		}

		public FluentLayout TopOf (NSObject view2)
		{
			return this.SetSecondItem (view2, NSLayoutAttribute.Top);
		}

		public FluentLayout TrailingOf (NSObject view2)
		{
			return this.SetSecondItem (view2, NSLayoutAttribute.Trailing);
		}

		public FluentLayout WidthOf (NSObject view2)
		{
			return this.SetSecondItem (view2, NSLayoutAttribute.Width);
		}

		public FluentLayout WithMultiplier (float multiplier)
		{
			this.Multiplier = multiplier;
			return this;
		}
	}
}