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

        public UIView View { get; }
        public NSLayoutAttribute Attribute { get; }

		public FluentLayout EqualTo(nfloat constant = default(nfloat)) =>
            new FluentLayout(View, Attribute, NSLayoutRelation.Equal, constant);

		public FluentLayout GreaterThanOrEqualTo(nfloat constant = default(nfloat)) =>
            new FluentLayout(View, Attribute, NSLayoutRelation.GreaterThanOrEqual, constant);

		public FluentLayout LessThanOrEqualTo(nfloat constant = default(nfloat)) =>
            new FluentLayout(View, Attribute, NSLayoutRelation.LessThanOrEqual, constant);
    }
}