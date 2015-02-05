// FluentLayoutExtensions.cs
// (c) Copyright Cirrious Ltd. http://www.cirrious.com
// MvvmCross is licensed using Microsoft Public License (Ms-PL)
// Contributions and inspirations noted in readme.md and license.txt
// 
// Project Lead - Stuart Lodge, @slodge, me@slodge.com
//
//Softlion: SubviewsDoNotTranslateAutoresizingMaskIntoConstraints can now  go through all levels recursively
//Softlion: AddConstraints method can take both FluentLayout and IEnumerable<FluentLayout>

using System.Collections.Generic;
using System.Linq;
using UIKit;

namespace Cirrious.FluentLayouts.Touch
{
    public static class FluentLayoutExtensions
    {
        public static void SubviewsDoNotTranslateAutoresizingMaskIntoConstraints(this UIView view, bool recursive = false)
        {
            foreach (var subview in view.Subviews)
            {
                subview.TranslatesAutoresizingMaskIntoConstraints = false;
                if (recursive && subview.Subviews.Length != 0)
                    subview.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints(true);
            }
        }

        public static UIViewAndLayoutAttribute Left(this UIView view)
        {
            return view.WithLayoutAttribute(NSLayoutAttribute.Left);
        }

        public static UIViewAndLayoutAttribute Right(this UIView view)
        {
            return view.WithLayoutAttribute(NSLayoutAttribute.Right);
        }

        public static UIViewAndLayoutAttribute Top(this UIView view)
        {
            return view.WithLayoutAttribute(NSLayoutAttribute.Top);
        }

        public static UIViewAndLayoutAttribute Bottom(this UIView view)
        {
            return view.WithLayoutAttribute(NSLayoutAttribute.Bottom);
        }

        public static UIViewAndLayoutAttribute Baseline(this UIView view)
        {
            return view.WithLayoutAttribute(NSLayoutAttribute.Baseline);
        }

        public static UIViewAndLayoutAttribute Trailing(this UIView view)
        {
            return view.WithLayoutAttribute(NSLayoutAttribute.Trailing);
        }

        public static UIViewAndLayoutAttribute Leading(this UIView view)
        {
            return view.WithLayoutAttribute(NSLayoutAttribute.Leading);
        }

        public static UIViewAndLayoutAttribute CenterX(this UIView view)
        {
            return view.WithLayoutAttribute(NSLayoutAttribute.CenterX);
        }

        public static UIViewAndLayoutAttribute CenterY(this UIView view)
        {
            return view.WithLayoutAttribute(NSLayoutAttribute.CenterY);
        }

        public static UIViewAndLayoutAttribute Height(this UIView view)
        {
            return view.WithLayoutAttribute(NSLayoutAttribute.Height);
        }

        public static UIViewAndLayoutAttribute Width(this UIView view)
        {
            return view.WithLayoutAttribute(NSLayoutAttribute.Width);
        }

        public static UIViewAndLayoutAttribute WithLayoutAttribute(this UIView view, NSLayoutAttribute attribute)
        {
            return new UIViewAndLayoutAttribute(view, attribute);
        }

        public static void AddConstraints(this UIView view, params FluentLayout[] fluentLayouts)
        {
            view.AddConstraints(fluentLayouts
                                    .Where(fluent => fluent != null)
                                    .SelectMany(fluent => fluent.ToLayoutConstraints())
                                    .ToArray());
        }

        public static void AddConstraints(this UIView view, IEnumerable<FluentLayout> fluentLayouts)
        {
            view.AddConstraints(fluentLayouts
                                    .Where(fluent => fluent != null)
                                    .SelectMany(fluent => fluent.ToLayoutConstraints())
                                    .ToArray());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="view"></param>
        /// <param name="fluentLayouts">Either FluentLayout or IEnumerable&lt;FluentLayout&gt;</param>
        public static void AddConstraints(this UIView view, params object[] fluentLayouts)
        {
            view.AddConstraints((fluentLayouts
                                    .Where(fluent => fluent != null)
                                    .OfType<FluentLayout>()
                                    .SelectMany(fluent => fluent.ToLayoutConstraints())
                                ).Concat(fluentLayouts
                                    .OfType<IEnumerable<FluentLayout>>()
                                    .SelectMany(fluent => fluent.SelectMany(fluent2 => fluent2.ToLayoutConstraints()))
                                ).ToArray());
        }

        /// <summary>
        /// Create and add constraints to the constraints list
        /// </summary>
        /// <param name="constraints"></param>
        /// <param name="fluentLayouts"></param>
        public static void AddConstraints(this List<NSLayoutConstraint> constraints, params FluentLayout[] fluentLayouts)
        {
            constraints.AddRange(fluentLayouts
                    .Where(fluent => fluent != null)
                    .SelectMany(fluent => fluent.ToLayoutConstraints()));
        }
    }
}
