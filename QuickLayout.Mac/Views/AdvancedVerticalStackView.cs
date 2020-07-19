using System.Collections.Generic;
using System.Reflection;
using AppKit;
using Cirrious.FluentLayouts.Touch;
using CoreGraphics;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Mac.Views;
using QuickLayout.Core.ViewModels;

namespace QuickLayout.Mac.Views
{
    [Register("AdvancedVerticalStackView")]
	public class AdvancedVerticalStackView : MvxViewController
	{
        public override void LoadView()
        {
            var scrollView = new NSScrollView(new CGRect(0, 0, 1000, 1000))
            {
                BackgroundColor = NSColor.White,
                HasHorizontalScroller = false,
                AutoresizingMask = NSViewResizingMask.HeightSizable,
            };
            View = scrollView;

            var container = new FlippedView(scrollView.ContentView.Bounds)
            {
                TranslatesAutoresizingMaskIntoConstraints = false
            };
            scrollView.DocumentView = container;

            var set = this.CreateBindingSet<AdvancedVerticalStackView, DetailsViewModel>();

            var topMargins = new List<float>();
            var leftMargins = new List<float>();
            var rightMargins = new List<float>();

            foreach (var propertyInfo in typeof(DetailsViewModel).GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                if (propertyInfo.PropertyType != typeof(string))
                    continue;

                topMargins.Add(20);
                leftMargins.Add(0);
                rightMargins.Add(0);
                var introLabel = new NSTextField
                {
                    StringValue = propertyInfo.Name + ":",
                    Editable = false,
                    TranslatesAutoresizingMaskIntoConstraints = false,
                };
                container.AddSubview(introLabel);

                topMargins.Add(0);
                leftMargins.Add(25);
                rightMargins.Add(25);
                var textField = new NSTextField
                {
                    TranslatesAutoresizingMaskIntoConstraints = false,
                    BackgroundColor = NSColor.LightGray
                };
                container.AddSubview(textField);

                topMargins.Add(0);
                leftMargins.Add(40);
                rightMargins.Add(40);
                var label = new NSTextField
                {
                    TranslatesAutoresizingMaskIntoConstraints = false,
                    Editable = false,
                    BackgroundColor = NSColor.Yellow,
                    Alignment = NSTextAlignment.Center
                };
                container.AddSubview(label);

                set.Bind(label).To(propertyInfo.Name);
                set.Bind(textField).To(propertyInfo.Name);
            }
            set.Apply();

            scrollView.ContentView.AddConstraints(
                container.AtTopOf(scrollView.ContentView),
                container.AtLeftOf(scrollView.ContentView),
                container.AtRightOf(scrollView.ContentView)
            );

            var constraints = container.AdvancedVerticalStackPanelConstraints(
                new Margins(20, 10, 20, 10, 5, 5),
                leftMargins.ToArray(),
                topMargins.ToArray(),
                rightMargins.ToArray(),
                1,
                container.Subviews);
            container.AddConstraints(constraints);
        }
	}
}

