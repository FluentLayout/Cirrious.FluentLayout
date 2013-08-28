using Cirrious.FluentLayouts.Touch;
using Cirrious.FluentLayouts.Touch.RowSet;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Touch.Views;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using QuickLayout.Core.ViewModels;

namespace QuickLayout.Touch.Views
{
    public class ResizingUILabel : UILabel
    {
        public string AutoText
        {
            get { return base.Text; }
            set { base.Text = value; SizeToFit(); LayoutIfNeeded(); }
        }
    }

    [Register("FormGridView")]
    public class FormGridView : MvxViewController
    {
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

            var debug = new ResizingUILabel() { BackgroundColor = UIColor.White, Lines = 0, LineBreakMode = UILineBreakMode.WordWrap };
            Add(debug);

            var set = this.CreateBindingSet<FormGridView, FormGridViewModel>();
            set.Bind(fNameField).To(vm => vm.FirstName);
            set.Bind(sNameField).To(vm => vm.LastName);
            set.Bind(numberField).To(vm => vm.Number);
            set.Bind(streetField).To(vm => vm.Street);
            set.Bind(townField).To(vm => vm.Town);
            set.Bind(zipField).To(vm => vm.Zip);
            set.Bind(debug).For(l => l.AutoText).To("FirstName  + ' ' + LastName + ', '  + Number + ' ' + Street + ' ' + Town + ' ' + Zip");
            set.Apply();

            FluentLayoutExtensions.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints(View);

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
            addressRowTemplate.ColumWeight(0, 0.3f);
            var townAndZipRowTemplate = new RowTemplate()
            {
                HInterspacing = 12f,
                LeftMargin = 6f,
                RightMargin = 24f
            };
            townAndZipRowTemplate.ColumWidth(1, 120f);

            View.AddConstraints(
                rowSet.Generate(View, 
                    new Row(equalWeightRowTemplate, fNameLabel, sNameLabel),
                    new Row(equalWeightRowTemplate, fNameField, sNameField),
                    new Row(addressRowTemplate, numberLabel, streetLabel),
                    new Row(addressRowTemplate, numberField, streetField),
                    new Row(townAndZipRowTemplate, townLabel, zipLabel),
                    new Row(townAndZipRowTemplate, townField, zipField),
                    new Row(equalWeightRowTemplate, debug)
                ));

            // to get word wrap we also have to add this constraint on the width of the debug field
            View.AddConstraints(debug.Width().LessThanOrEqualTo().WidthOf(View).Minus(24f));
        }
    }
}