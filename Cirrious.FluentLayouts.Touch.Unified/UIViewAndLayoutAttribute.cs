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

        public FluentLayout EqualTo(nfloat? constant = null)
        {
			return new FluentLayout(View, Attribute, NSLayoutRelation.Equal, null == constant ? 0 : constant.Value);
        }

		public FluentLayout GreaterThanOrEqualTo(nfloat? constant = null)
        {
			return new FluentLayout(View, Attribute, NSLayoutRelation.GreaterThanOrEqual, null == constant ? 0 : constant.Value);
        }

		public FluentLayout LessThanOrEqualTo(nfloat? constant = null)
        {
			return new FluentLayout(View, Attribute, NSLayoutRelation.LessThanOrEqual, null == constant ? 0 : constant.Value);
        }

    }
}