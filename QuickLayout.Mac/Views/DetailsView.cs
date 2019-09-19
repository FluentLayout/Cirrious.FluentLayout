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
    [Register("DetailsView")]
    public class DetailsView : MvxViewController
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

            var set = this.CreateBindingSet<DetailsView, DetailsViewModel>();

            foreach (var propertyInfo in typeof(DetailsViewModel).GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                if (propertyInfo.PropertyType != typeof(string))
                    continue;

                var introLabel = new NSTextField
                {
                    StringValue = propertyInfo.Name + ":",
                    TranslatesAutoresizingMaskIntoConstraints = false,
                    Editable = false
                };
                container.AddSubview(introLabel);
                var textField = new NSTextField
                {
                    TranslatesAutoresizingMaskIntoConstraints = false,
                    BackgroundColor = NSColor.LightGray
                };
                container.AddSubview(textField);
                var label = new NSTextField
                {
                    TranslatesAutoresizingMaskIntoConstraints = false,
                    BackgroundColor = NSColor.Yellow
                };
                container.AddSubview(label);

                set.Bind(label).To(propertyInfo.Name);
                set.Bind(textField).To(propertyInfo.Name);
            }
            set.Apply();

            var constraints = container.VerticalStackPanelConstraints(
                                                   new Margins(20, 10, 20, 10, 5, 5),
                                                   container.Subviews);
            container.AddConstraints(constraints);

            scrollView.ContentView.AddConstraints(
                container.AtTopOf(scrollView.ContentView),
                container.AtLeftOf(scrollView.ContentView),
                container.AtRightOf(scrollView.ContentView)
            );
        }
    }
}
