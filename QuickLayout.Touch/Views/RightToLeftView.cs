using Cirrious.FluentLayouts.Touch;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Views;
using Foundation;
using ObjCRuntime;
using UIKit;

using QuickLayout.Core.ViewModels;
using System.Runtime.InteropServices;
using System;

namespace QuickLayout.Touch.Views
{
    [Register("RightToLeftView")]
    public class RightToLeftView : MvxViewController
    {
        public RightToLeftView()
        {
            SetRTL(false);
        }

        public override void ViewDidLoad()
        {
            View.BackgroundColor = UIColor.White;
            base.ViewDidLoad();

            // ios7 layout
            if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
                EdgesForExtendedLayout = UIRectEdge.None;

            var fNameLabel = new UILabel {Text = "First"};
            Add(fNameLabel);

            var sNameLabel = new UILabel {Text = "Last"};
            Add(sNameLabel);

            var numberLabel = new UILabel {Text = "#"};
            Add(numberLabel);

            var streetLabel = new UILabel {Text = "Street"};
            Add(streetLabel);

            var townLabel = new UILabel {Text = "Town"};
            Add(townLabel);

            var zipLabel = new UILabel {Text = "Zip"};
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

            var debug = new UILabel() { BackgroundColor = UIColor.White, Lines = 0 };
            Add(debug);

            var set = this.CreateBindingSet<RightToLeftView, RightToLeftViewModel>();
            set.Bind(fNameField).To(vm => vm.FirstName);
            set.Bind(sNameField).To(vm => vm.LastName);
            set.Bind(numberField).To(vm => vm.Number);
            set.Bind(streetField).To(vm => vm.Street);
            set.Bind(townField).To(vm => vm.Town);
            set.Bind(zipField).To(vm => vm.Zip);
            set.Bind(debug).To("FirstName  + ' ' + LastName + ', '  + Number + ' ' + Street + ' ' + Town + ' ' + Zip");
            set.Apply();

            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            var hMargin = 10;
            var vMargin = 10;


            View.AddConstraints(

                fNameLabel.AtTopOf(View, vMargin),
                fNameLabel.AtLeadingOf(View, hMargin),
                fNameLabel.ToLeadingOf(sNameLabel, hMargin),

                sNameLabel.WithSameTop(fNameLabel),
                sNameLabel.AtTrailingOf(View, hMargin),
                sNameLabel.WithSameWidth(fNameLabel),

                fNameField.WithSameWidth(fNameLabel),
                fNameField.WithSameLeading(fNameLabel),
                fNameField.Below(fNameLabel, vMargin),

                sNameField.WithSameLeading(sNameLabel),
                sNameField.WithSameWidth(sNameLabel),
                sNameField.WithSameTop(fNameField),

                numberLabel.WithSameLeading(fNameLabel),
                numberLabel.ToLeadingOf(streetLabel, hMargin),
                numberLabel.Below(fNameField, vMargin),
                numberLabel.WithRelativeWidth(streetLabel, 0.3f),

                streetLabel.WithSameTop(numberLabel),
                streetLabel.AtTrailingOf(View, hMargin),

                numberField.WithSameLeading(numberLabel),
                numberField.WithSameWidth(numberLabel),
                numberField.Below(numberLabel, vMargin),

                streetField.WithSameLeading(streetLabel),
                streetField.WithSameWidth(streetLabel),
                streetField.WithSameTop(numberField),

                townLabel.WithSameLeading(fNameLabel),
                townLabel.WithSameTrailing(streetLabel),
                townLabel.Below(numberField, vMargin),

                townField.WithSameLeading(townLabel),
                townField.WithSameWidth(townLabel),
                townField.Below(townLabel, vMargin),

                zipLabel.WithSameLeading(fNameLabel),
                zipLabel.WithSameWidth(townLabel),
                zipLabel.Below(townField, vMargin),

                zipField.WithSameLeading(townLabel),
                zipField.WithSameWidth(zipLabel),
                zipField.Below(zipLabel, vMargin),

                debug.WithSameLeading(townLabel),
                debug.WithSameWidth(zipLabel),
                debug.AtBottomOf(View, vMargin)

                );
        }

        [DllImport(Constants.ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
        internal extern static IntPtr IntPtr_objc_msgSend(IntPtr receiver, IntPtr selector, UISemanticContentAttribute arg1);

        private static void SetRTL(bool isRTL)
        {
            Selector selector = new Selector("setSemanticContentAttribute:");
            IntPtr_objc_msgSend(UIView.Appearance.Handle, selector.Handle, isRTL ? UISemanticContentAttribute.ForceRightToLeft : UISemanticContentAttribute.ForceLeftToRight);
        }
    }
}