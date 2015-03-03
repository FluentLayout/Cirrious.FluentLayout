// UIViewAndLayoutAttribute.cs
// (c) Copyright Cirrious Ltd. http://www.cirrious.com
// MvvmCross is licensed using Microsoft Public License (Ms-PL)
// Contributions and inspirations noted in readme.md and license.txt
// 
// Project Lead - Stuart Lodge, @slodge, me@slodge.com

using System;
using AppKit;

namespace Cirrious.FluentLayouts.Mac
{
	public class NSViewAndLayoutAttribute
	{
		//
		// Properties
		//
		public NSLayoutAttribute Attribute {
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
		public NSViewAndLayoutAttribute (NSView view, NSLayoutAttribute attribute)
		{
			this.Attribute = attribute;
			this.View = view;
		}

		//
		// Methods
		//
		public FluentLayout EqualTo (float constant = 0)
		{
			return new FluentLayout (this.View, this.Attribute, NSLayoutRelation.Equal, constant);
		}

		public FluentLayout GreaterThanOrEqualTo (float constant = 0)
		{
			return new FluentLayout (this.View, this.Attribute, NSLayoutRelation.GreaterThanOrEqual, constant);
		}

		public FluentLayout LessThanOrEqualTo (float constant = 0)
		{
			return new FluentLayout (this.View, this.Attribute, NSLayoutRelation.LessThanOrEqual, constant);
		}
	}
}