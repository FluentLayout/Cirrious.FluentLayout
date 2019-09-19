using AppKit;
using Cirrious.FluentLayouts.Touch;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Mac.Views;
using QuickLayout.Core.ViewModels;

namespace QuickLayout.Mac.Views
{
    [Register("FormView")]
    public class FormView : MvxViewController
    {
        public override void LoadView()
        {
            View = new NSView();

            var fNameLabel = new NSTextField { StringValue = "First", Editable = false };
            View.AddSubview(fNameLabel);

            var sNameLabel = new NSTextField { StringValue = "Last", Editable = false };
            View.AddSubview(sNameLabel);

            var numberLabel = new NSTextField { StringValue = "#", Editable = false };
            View.AddSubview(numberLabel);

            var streetLabel = new NSTextField { StringValue = "Street", Editable = false };
            View.AddSubview(streetLabel);

            var townLabel = new NSTextField { StringValue = "Town", Editable = false };
            View.AddSubview(townLabel);

            var zipLabel = new NSTextField { StringValue = "Zip", Editable = false };
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

            var debug = new NSTextField() { BackgroundColor = NSColor.White, MaximumNumberOfLines = 0 };
            View.AddSubview(debug);

            var set = this.CreateBindingSet<FormView, FormViewModel>();
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
                fNameLabel.AtLeftOf(View, hMargin),
                fNameLabel.ToLeftOf(sNameLabel, hMargin),

                sNameLabel.WithSameTop(fNameLabel),
                sNameLabel.AtRightOf(View, hMargin),
                sNameLabel.WithSameWidth(fNameLabel),

                fNameField.WithSameWidth(fNameLabel),
                fNameField.WithSameLeft(fNameLabel),
                fNameField.Below(fNameLabel, vMargin),

                sNameField.WithSameLeft(sNameLabel),
                sNameField.WithSameWidth(sNameLabel),
                sNameField.WithSameTop(fNameField),

                numberLabel.WithSameLeft(fNameLabel),
                numberLabel.ToLeftOf(streetLabel, hMargin),
                numberLabel.Below(fNameField, vMargin),
                numberLabel.WithRelativeWidth(streetLabel, 0.3f),

                streetLabel.WithSameTop(numberLabel),
                streetLabel.AtRightOf(View, hMargin),

                numberField.WithSameLeft(numberLabel),
                numberField.WithSameWidth(numberLabel),
                numberField.Below(numberLabel, vMargin),

                streetField.WithSameLeft(streetLabel),
                streetField.WithSameWidth(streetLabel),
                streetField.WithSameTop(numberField),

                townLabel.WithSameLeft(fNameLabel),
                townLabel.WithSameRight(streetLabel),
                townLabel.Below(numberField, vMargin),

                townField.WithSameLeft(townLabel),
                townField.WithSameWidth(townLabel),
                townField.Below(townLabel, vMargin),

                zipLabel.WithSameLeft(fNameLabel),
                zipLabel.WithSameWidth(townLabel),
                zipLabel.Below(townField, vMargin),

                zipField.WithSameLeft(townLabel),
                zipField.WithSameWidth(zipLabel),
                zipField.Below(zipLabel, vMargin),

                debug.WithSameLeft(townLabel),
                debug.WithSameWidth(zipLabel),
                debug.AtBottomOf(View, vMargin)

                );
        }
    }
}