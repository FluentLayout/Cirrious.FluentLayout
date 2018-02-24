using System.Drawing;
using Cirrious.FluentLayouts.Touch;
using Cirrious.FluentLayouts.Touch.RowSet;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using Foundation;
using UIKit;
using ObjCRuntime;
using QuickLayout.Core.ViewModels;

namespace QuickLayout.Touch.Views
{
    [Register("FormGridView")]
    public class FormGridView : MvxViewController
    {
        private UILabel _debugLabel;
        private UIView _forceTheWidthView;

        public override void ViewDidLoad()
        {
            var scrollView = new UIScrollView()
            {
                BackgroundColor = UIColor.White,
                ShowsHorizontalScrollIndicator = false,
                AutoresizingMask = UIViewAutoresizing.FlexibleHeight,
            };
            View = scrollView;
            scrollView.TranslatesAutoresizingMaskIntoConstraints = true;
            base.ViewDidLoad();

            // ios7 layout
            if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
                EdgesForExtendedLayout = UIRectEdge.None;

            var _forceTheWidthView = new UIView() {BackgroundColor = UIColor.Clear};
            Add(_forceTheWidthView);

            var fNameLabel = new UILabel { Text = "First" };
            Add(fNameLabel);

            var sNameLabel = new UILabel { Text = "Last" };
            Add(sNameLabel);

            var numberLabel = new UILabel { Text = "#" };
            Add(numberLabel);

            var streetLabel = new UILabel { Text = "Street" };
            Add(streetLabel);

            var townLabel = new UILabel { Text = "Town" };
            Add(townLabel);

            var zipLabel = new UILabel { Text = "Zip" };
            Add(zipLabel);

            var fNameField = new UITextField() { BackgroundColor = UIColor.LightGray, BorderStyle = UITextBorderStyle.RoundedRect };
            Add(fNameField);

            var sNameField = new UITextField() { BackgroundColor = UIColor.LightGray, BorderStyle = UITextBorderStyle.RoundedRect };
            Add(sNameField);

            var numberField = new UITextField() { BackgroundColor = UIColor.LightGray, BorderStyle = UITextBorderStyle.RoundedRect };
            Add(numberField);

            var streetField = new UITextField() { BackgroundColor = UIColor.LightGray, BorderStyle = UITextBorderStyle.RoundedRect };
            Add(streetField);

            var townField = new UITextField() { BackgroundColor = UIColor.LightGray, BorderStyle = UITextBorderStyle.RoundedRect };
            Add(townField);

            var zipField = new UITextField() { BackgroundColor = UIColor.LightGray, BorderStyle = UITextBorderStyle.RoundedRect };
            Add(zipField);

            _debugLabel = new UILabel() { BackgroundColor = UIColor.White, Lines = 0, LineBreakMode = UILineBreakMode.WordWrap };
            Add(_debugLabel);

            var set = this.CreateBindingSet<FormGridView, FormGridViewModel>();
            set.Bind(fNameField).To(vm => vm.FirstName);
            set.Bind(sNameField).To(vm => vm.LastName);
            set.Bind(numberField).To(vm => vm.Number);
            set.Bind(streetField).To(vm => vm.Street);
            set.Bind(townField).To(vm => vm.Town);
            set.Bind(zipField).To(vm => vm.Zip);
            set.Bind(_debugLabel).To("FirstName  + ' ' + LastName + ', '  + Number + ' ' + Street + ' ' + Town + ' ' + Zip");
            set.Apply();

            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

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

            View.AddConstraints(
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
            View.AddConstraints(_forceTheWidthView.Width().EqualTo().WidthOf(View).Minus(30f));
        }

        public override void ViewWillLayoutSubviews()
        {
            // to get word wrap we also have to add this preferred width on the width of the debug field
            // see https://developer.apple.com/library/ios/DOCUMENTATION/UIKit/Reference/UILabel_Class/Reference/UILabel.html#//apple_ref/occ/instp/UILabel/preferredMaxLayoutWidth
            _debugLabel.PreferredMaxLayoutWidth = View.Frame.Width - 30f;

            base.ViewWillLayoutSubviews();
        }
    }
}