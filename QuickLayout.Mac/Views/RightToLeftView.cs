using AppKit;
using Cirrious.FluentLayouts.Touch;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Mac.Views;
using QuickLayout.Core.ViewModels;

namespace QuickLayout.Mac.Views
{
    [Register("RightToLeftView")]
    public class RightToLeftView : MvxViewController
    {
        public RightToLeftView()
        {
            // TODO: Implement RTL
            //SetRTL(false);
        }

        public override void LoadView()
        {
            View = new NSView();

            var fNameLabel = new NSTextField { Editable = false, StringValue = "First" };
            View.AddSubview(fNameLabel);

            var sNameLabel = new NSTextField { Editable = false, StringValue = "Last" };
            View.AddSubview(sNameLabel);

            var numberLabel = new NSTextField { Editable = false, StringValue = "#" };
            View.AddSubview(numberLabel);

            var streetLabel = new NSTextField { Editable = false, StringValue = "Street" };
            View.AddSubview(streetLabel);

            var townLabel = new NSTextField { Editable = false, StringValue = "Town" };
            View.AddSubview(townLabel);

            var zipLabel = new NSTextField { Editable = false, StringValue = "Zip" };
            View.AddSubview(zipLabel);

            var fNameField = new NSTextField() { BackgroundColor = NSColor.LightGray };
            View.AddSubview(fNameField);

            var sNameField = new NSTextField() { BackgroundColor = NSColor.LightGray };
            View.AddSubview(sNameField);

            var numberField = new NSTextField() { BackgroundColor = NSColor.LightGray };
            View.AddSubview(numberField);

            var streetField = new NSTextField() { BackgroundColor = NSColor.LightGray };
            View.AddSubview(streetField);

            var townField = new NSTextField() { BackgroundColor = NSColor.LightGray };
            View.AddSubview(townField);

            var zipField = new NSTextField() { BackgroundColor = NSColor.LightGray };
            View.AddSubview(zipField);

            var debug = new NSTextField { Editable = false, BackgroundColor = NSColor.White, MaximumNumberOfLines = 0 };
            View.AddSubview(debug);

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

        // TODO: implement RTL
        //[DllImport(Constants.ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
        //internal extern static IntPtr IntPtr_objc_msgSend(IntPtr receiver, IntPtr selector, NSSemanticContentAttribute arg1);

        //private static void SetRTL(bool isRTL)
        //{
        //    Selector selector = new Selector("setSemanticContentAttribute:");
        //    IntPtr_objc_msgSend(NSView.Appearance.Handle, selector.Handle, isRTL ? NSSemanticContentAttribute.ForceRightToLeft : NSSemanticContentAttribute.ForceLeftToRight);
        //}
    }
}