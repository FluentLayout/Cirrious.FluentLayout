// UIViewAndLayoutAttribute.cs
// (c) Copyright Cirrious Ltd. http://www.cirrious.com
// MvvmCross is licensed using Microsoft Public License (Ms-PL)
// Contributions and inspirations noted in readme.md and license.txt
// 
// Project Lead - Stuart Lodge, @slodge, me@slodge.com

using UIKit;
using System;

namespace Cirrious.FluentLayouts.Touch
{
    public class UIViewAndLayoutAttribute
    {
        public UIViewAndLayoutAttribute(UIView view, NSLayoutAttribute attribute)
        {
            Attribute = attribute;
            View = view;
        }

        public UIView View { get; private set; }
        public NSLayoutAttribute Attribute { get; private set; }

		public FluentLayout EqualTo()
		{
			return EqualTo(0);
		}

        public FluentLayout EqualTo(nfloat constant)
        {
            return new FluentLayout(View, Attribute, NSLayoutRelation.Equal, constant);
        }

		public FluentLayout GreaterThanOrEqualTo()
		{
			return GreaterThanOrEqualTo(0);
		}

        public FluentLayout GreaterThanOrEqualTo(nfloat constant)
        {
            return new FluentLayout(View, Attribute, NSLayoutRelation.GreaterThanOrEqual, constant);
        }

		public FluentLayout LessThanOrEqualTo()
		{
			return LessThanOrEqualTo(0);
		}

        public FluentLayout LessThanOrEqualTo(nfloat constant)
        {
            return new FluentLayout(View, Attribute, NSLayoutRelation.LessThanOrEqual, constant);
        }
    }
}