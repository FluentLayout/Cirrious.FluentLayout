// FluentLayout.cs
// (c) Copyright Cirrious Ltd. http://www.cirrious.com
// MvvmCross is licensed using Microsoft Public License (Ms-PL)
// Contributions and inspirations noted in readme.md and license.txt
// 
// Project Lead - Stuart Lodge, @slodge, me@slodge.com

using System;
using System.Collections.Generic;
using UIKit;
using Foundation;
using System.Linq;

namespace Cirrious.FluentLayouts.Touch
{
	public class FluentLayout : IDisposable
    {
		NSLayoutConstraint _nativeLayoutConstraint;

        public FluentLayout(
            UIView view,
            NSLayoutAttribute attribute,
            NSLayoutRelation relation,
            NSObject secondItem,
            NSLayoutAttribute secondAttribute)
        {
            View = view;
            Attribute = attribute;
            Relation = relation;
            SecondItem = secondItem;
            SecondAttribute = secondAttribute;
            Multiplier = 1f;
            Priority = (float) UILayoutPriority.Required;
			Active = true;
        }

        public FluentLayout(UIView view,
                            NSLayoutAttribute attribute,
                            NSLayoutRelation relation,
							nfloat constant = default(nfloat))
        {
            View = view;
            Attribute = attribute;
            Relation = relation;
            Multiplier = 1f;
            Constant = constant;
            Priority = (float) UILayoutPriority.Required;
        }

        public UIView View { get; private set; }
        public NSLayoutAttribute Attribute { get; private set; }
        public NSLayoutRelation Relation { get; private set; }
        public NSObject SecondItem { get; private set; }
        public NSLayoutAttribute SecondAttribute { get; private set; }
        public nfloat Multiplier { get; private set; }

		bool _active = true;
		public bool Active {
			get { return _active; }
			set {
				_active = value;

				if (_nativeLayoutConstraint != null)
					_nativeLayoutConstraint.Active = value;
			}
		}

		nfloat _constant;
        public nfloat Constant {
			get {
				return _constant;
			}
			set {
				_constant = value;

				if (_nativeLayoutConstraint != null)
					_nativeLayoutConstraint.Constant = value;
			}
		}

		float _priority;
        public float Priority {
			get {
				return _priority;
			}
			set {
				_priority = value;

				if (_nativeLayoutConstraint != null)
					_nativeLayoutConstraint.Priority = value;
			}
		}

		public NSLayoutConstraint NativeConstraint {
			get{ 
				return _nativeLayoutConstraint ?? this.ToLayoutConstraints ().FirstOrDefault ();
			}
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

        public FluentLayout SetPriority(UILayoutPriority priority)
        {
            Priority = (float) priority;
            return this;
        }

        public FluentLayout LeftOf(NSObject view2)
        {
            return SetSecondItem(view2, NSLayoutAttribute.Left);
        }

        public FluentLayout RightOf(NSObject view2)
        {
            return SetSecondItem(view2, NSLayoutAttribute.Right);
        }

        public FluentLayout TopOf(NSObject view2)
        {
            return SetSecondItem(view2, NSLayoutAttribute.Top);
        }

        public FluentLayout BottomOf(NSObject view2)
        {
            return SetSecondItem(view2, NSLayoutAttribute.Bottom);
        }

        public FluentLayout BaselineOf(NSObject view2)
        {
            return SetSecondItem(view2, NSLayoutAttribute.Baseline);
        }

        public FluentLayout TrailingOf(NSObject view2)
        {
            return SetSecondItem(view2, NSLayoutAttribute.Trailing);
        }

        public FluentLayout LeadingOf(NSObject view2)
        {
            return SetSecondItem(view2, NSLayoutAttribute.Leading);
        }

        public FluentLayout CenterXOf(NSObject view2)
        {
            return SetSecondItem(view2, NSLayoutAttribute.CenterX);
        }

        public FluentLayout CenterYOf(NSObject view2)
        {
            return SetSecondItem(view2, NSLayoutAttribute.CenterY);
        }

        public FluentLayout HeightOf(NSObject view2)
        {
            return SetSecondItem(view2, NSLayoutAttribute.Height);
        }

        public FluentLayout WidthOf(NSObject view2)
        {
            return SetSecondItem(view2, NSLayoutAttribute.Width);
        }

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

        public IEnumerable<NSLayoutConstraint> ToLayoutConstraints()
        {
			if (_nativeLayoutConstraint == null)
				_nativeLayoutConstraint = NSLayoutConstraint.Create (
					View,
					Attribute,
					Relation,
					SecondItem,
					SecondAttribute,
					Multiplier,
					Constant);
			else
				_nativeLayoutConstraint.Constant = Constant;

			_nativeLayoutConstraint.Priority = Priority;
			_nativeLayoutConstraint.Active = Active;

			yield return _nativeLayoutConstraint;
        }
			
		public void Dispose ()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing){
			if (disposing) {
				if (_nativeLayoutConstraint != null)
					_nativeLayoutConstraint.Dispose ();
			}
		}
    }
}