using AppKit;
using Cirrious.FluentLayouts.Touch;
using Cirrious.FluentLayouts.Touch.RowSet;
using CoreGraphics;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Mac.Views;
using QuickLayout.Core.ViewModels;

namespace QuickLayout.Mac.Views
{
    [Register("FormGridView")]
    public class FormGridView : MvxViewController
    {
        private NSTextField _debugLabel;

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

            var _forceTheWidthView = new NSView();
            container.AddSubview(_forceTheWidthView);

            var fNameLabel = new NSTextField { StringValue = "First", Editable = false };
            container.AddSubview(fNameLabel);

            var sNameLabel = new NSTextField { StringValue = "Last", Editable = false };
            container.AddSubview(sNameLabel);

            var numberLabel = new NSTextField { StringValue = "#", Editable = false };
            container.AddSubview(numberLabel);

            var streetLabel = new NSTextField { StringValue = "Street", Editable = false };
            container.AddSubview(streetLabel);

            var townLabel = new NSTextField { StringValue = "Town", Editable = false };
            container.AddSubview(townLabel);

            var zipLabel = new NSTextField { StringValue = "Zip", Editable = false };
            container.AddSubview(zipLabel);

            var fNameField = new NSTextField() { BackgroundColor = NSColor.LightGray };
            container.AddSubview(fNameField);

            var sNameField = new NSTextField() { BackgroundColor = NSColor.LightGray };
            container.AddSubview(sNameField);

            var numberField = new NSTextField() { BackgroundColor = NSColor.LightGray };
            container.AddSubview(numberField);

            var streetField = new NSTextField() { BackgroundColor = NSColor.LightGray };
            container.AddSubview(streetField);

            var townField = new NSTextField() { BackgroundColor = NSColor.LightGray };
            container.AddSubview(townField);

            var zipField = new NSTextField() { BackgroundColor = NSColor.LightGray };
            container.AddSubview(zipField);

            _debugLabel = new NSTextField() { BackgroundColor = NSColor.White, MaximumNumberOfLines = 0, LineBreakMode = NSLineBreakMode.ByWordWrapping };
            container.AddSubview(_debugLabel);

            var set = this.CreateBindingSet<FormGridView, FormGridViewModel>();
            set.Bind(fNameField).To(vm => vm.FirstName);
            set.Bind(sNameField).To(vm => vm.LastName);
            set.Bind(numberField).To(vm => vm.Number);
            set.Bind(streetField).To(vm => vm.Street);
            set.Bind(townField).To(vm => vm.Town);
            set.Bind(zipField).To(vm => vm.Zip);
            set.Bind(_debugLabel).To("FirstName  + ' ' + LastName + ', '  + Number + ' ' + Street + ' ' + Town + ' ' + Zip");
            set.Apply();

            View = container;
            container.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            var rowSet = new RowSetTemplate()
            {
                TopMargin = 10f,
                BottomMargin = 20f,
                VInterspacing = 10f
            };
            var equalWeightRowTemplate = new RowTemplate()
            {
                HInterspacing = 12f,
                LeftMargin = 6f,
                RightMargin = 24f
            };
            var addressRowTemplate = new RowTemplate()
            {
                HInterspacing = 12f,
                LeftMargin = 6f,
                RightMargin = 24f
            };
            addressRowTemplate.ColumnWeight(0, 0.3f);
            var townAndZipRowTemplate = new RowTemplate()
            {
                HInterspacing = 12f,
                LeftMargin = 6f,
                RightMargin = 24f
            };
            townAndZipRowTemplate.ColumnWidth(1, 120f);

            scrollView.ContentView.AddConstraints(
                container.AtTopOf(scrollView.ContentView),
                container.AtLeftOf(scrollView.ContentView),
                container.AtRightOf(scrollView.ContentView)
            );

            container.AddConstraints(
                rowSet.Generate(View,
                    new Row(equalWeightRowTemplate, _forceTheWidthView),
                    new Row(equalWeightRowTemplate, fNameLabel, sNameLabel),
                    new Row(equalWeightRowTemplate, fNameField, sNameField),
                    new Row(addressRowTemplate, numberLabel, streetLabel),
                    new Row(addressRowTemplate, numberField, streetField),
                    new Row(townAndZipRowTemplate, townLabel, zipLabel),
                    new Row(townAndZipRowTemplate, townField, zipField),
                    new Row(equalWeightRowTemplate, _debugLabel)
                ));
            container.AddConstraints(_forceTheWidthView.Width().EqualTo().WidthOf(container).Minus(30f));
        }
    }
}