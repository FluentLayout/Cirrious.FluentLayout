// FluentLayout.cs
// (c) Copyright Cirrious Ltd. http://www.cirrious.com
// MvvmCross is licensed using Microsoft Public License (Ms-PL)
// Contributions and inspirations noted in readme.md and license.txt
// 
// Project Lead - Stuart Lodge, @slodge, me@slodge.com

using System;
using System.Collections.Generic;
using AppKit;
using Foundation;

namespace Cirrious.FluentLayouts.Touch
{
    public class FluentLayout
    {
        public FluentLayout(
            NSView view,
            NSLayoutAttribute attribute,
            NSLayoutRelation relation,
            NSObject secondItem,
            NSLayoutAttribute secondAttribute)
        {
			Constraint = new Lazy<NSLayoutConstraint>(CreateConstraint);
            View = view;
            Attribute = attribute;
            Relation = relation;
            SecondItem = secondItem;
            SecondAttribute = secondAttribute;
            Priority = (float) NSLayoutPriority.Required;
        }

        public FluentLayout(NSView view,
                            NSLayoutAttribute attribute,
                            NSLayoutRelation relation,
							nfloat constant = default(nfloat))
        {
			Constraint = new Lazy<NSLayoutConstraint>(CreateConstraint);
            View = view;
            Attribute = attribute;
            Relation = relation;
            Constant = constant;
            Priority = (float) NSLayoutPriority.Required;
        }

        public NSView View { get; }

		public nfloat Multiplier { get; private set; } = 1f;

		private nfloat _constant;
		public nfloat Constant 
		{ 
			get { return _constant; }
			set
			{
				_constant = value;

				if (Constraint.IsValueCreated)
					Constraint.Value.Constant = _constant;
			}
		}

		private float _priority;
		public float Priority 
		{ 
			get { return _priority; }
			set
			{
				_priority = value;

				if (Constraint.IsValueCreated)
					Constraint.Value.Priority = _priority;
			}
		}

		private bool _active = true;
		public bool Active
		{
			get { return _active; }
			set
			{
				_active = value;

				if (Constraint.IsValueCreated)
					Constraint.Value.Active = _active;
			}
		}

		private string _identifier;
		public string Identifier
		{
			get { return _identifier; }
			set
			{
				_identifier = value;

				if (Constraint.IsValueCreated)
					Constraint.Value.Identifier = _identifier;
			}
		}

        public NSLayoutAttribute Attribute { get; private set; }
        public NSLayoutRelation Relation { get; private set; }
        public NSObject SecondItem { get; private set; }
        public NSLayoutAttribute SecondAttribute { get; private set; }

		internal Lazy<NSLayoutConstraint> Constraint { get; }

		private NSLayoutConstraint CreateConstraint()
		{
			var constraint = NSLayoutConstraint.Create(
				View,
				Attribute,
				Relation,
				SecondItem,
				SecondAttribute,
				Multiplier,
				Constant);
			constraint.Priority = Priority;

			if (!string.IsNullOrWhiteSpace(Identifier))
				constraint.Identifier = Identifier;

			return constraint;
		}

		public FluentLayout Plus(nfloat constant)
        {
            Constant += constant;
            return this;
        }

        public FluentLayout Minus(nfloat constant)
        {
            Constant -= constant;
            return this;
        }

        public FluentLayout WithMultiplier(nfloat multiplier)
        {
            Multiplier = multiplier;
            return this;
        }

        public FluentLayout SetPriority(float priority)
        {
            Priority = priority;
            return this;
        }

        public FluentLayout SetPriority(NSLayoutPriority priority)
        {
            Priority = (float) priority;
            return this;
        }

		public FluentLayout SetActive(bool active)
		{
			Active = active;
			return this;
		}

		public FluentLayout WithIdentifier(string identifier)
		{
			Identifier = identifier;
			return this;
		}

        public FluentLayout LeftOf(NSObject view2) => SetSecondItem(view2, NSLayoutAttribute.Left);

        public FluentLayout RightOf(NSObject view2) => SetSecondItem(view2, NSLayoutAttribute.Right);

        public FluentLayout TopOf(NSObject view2) => SetSecondItem(view2, NSLayoutAttribute.Top);

        public FluentLayout BottomOf(NSObject view2) => SetSecondItem(view2, NSLayoutAttribute.Bottom);

        public FluentLayout BaselineOf(NSObject view2) => SetSecondItem(view2, NSLayoutAttribute.Baseline);

        public FluentLayout TrailingOf(NSObject view2) => SetSecondItem(view2, NSLayoutAttribute.Trailing);

        public FluentLayout LeadingOf(NSObject view2) => SetSecondItem(view2, NSLayoutAttribute.Leading);

        public FluentLayout CenterXOf(NSObject view2) => SetSecondItem(view2, NSLayoutAttribute.CenterX);

        public FluentLayout CenterYOf(NSObject view2) => SetSecondItem(view2, NSLayoutAttribute.CenterY);

        public FluentLayout HeightOf(NSObject view2) => SetSecondItem(view2, NSLayoutAttribute.Height);

        public FluentLayout WidthOf(NSObject view2) => SetSecondItem(view2, NSLayoutAttribute.Width);

        //public FluentLayout TrailingMarginOf(NSObject view2) => SetSecondItem(view2, NSLayoutAttribute.TrailingMargin);

        //public FluentLayout LeadingMarginOf(NSObject view2) => SetSecondItem(view2, NSLayoutAttribute.LeadingMargin);

        //public FluentLayout TopMarginOf(NSObject view2) => SetSecondItem(view2, NSLayoutAttribute.TopMargin);

        //public FluentLayout BottomMarginOf(NSObject view2) => SetSecondItem(view2, NSLayoutAttribute.BottomMargin);

        private FluentLayout SetSecondItem(NSObject view2, NSLayoutAttribute attribute2)
        {
            ThrowIfSecondItemAlreadySet();
            SecondAttribute = attribute2;
            SecondItem = view2;
            return this;
        }

        private void ThrowIfSecondItemAlreadySet()
        {
            if (SecondItem != null)
                throw new Exception("You cannot set the second item in a layout relation more than once");
        }

		[Obsolete("This method will be removed in future versions, please let us know if you still need it!")]
		public IEnumerable<NSLayoutConstraint> ToLayoutConstraints()
		{
			yield return Constraint.Value;
		}
    }
}