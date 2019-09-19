using AppKit;
using Cirrious.FluentLayouts.Touch;
using Cirrious.FluentLayouts.Touch.Extensions;
using Foundation;
using MvvmCross.Binding;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Mac.Views;
using QuickLayout.Core.ViewModels;
using QuickLayout.Mac.Converters;

namespace QuickLayout.Mac.Views
{
    [Register("UpdateConstraintsView")]
	public class UpdateConstraintsView : MvxViewController<UpdateConstraintsViewModel>
	{
        FluentLayout heightLayout;

        public override void LoadView()
        {
            View = new NSView();

            var label = new NSTextField
            {
                Editable = false,
                StringValue = "Update this label's height constraint height constant and active settings",
                BackgroundColor = NSColor.White,
                TextColor = NSColor.Black,
                LineBreakMode = NSLineBreakMode.ByWordWrapping,
                MaximumNumberOfLines = 0
            };
            var toggleHeight = new NSButton();
            toggleHeight.SetButtonType(NSButtonType.Switch);

            var heightConstant = new NSSlider { MinValue = 0, MaxValue = 600 };

            View.AddSubviews(label, toggleHeight, heightConstant);

            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            heightLayout = label.Height().EqualTo(200).WithIdentifier("foo");

            var margin = 10;
            View.AddConstraints(
                heightConstant.AtTopOf(View, margin),
                heightConstant.AtLeftOf(View, margin),
                heightConstant.AtRightOf(View, margin),

                toggleHeight.Below(heightConstant, margin),
                toggleHeight.WithSameLeft(heightConstant),

                label.AtLeftOf(View, margin),
                label.Below(toggleHeight, margin),
                label.AtRightOf(View, margin),
                heightLayout
            );

            var set = this.CreateBindingSet<UpdateConstraintsView, UpdateConstraintsViewModel>();
            set.Bind(heightLayout).For(layout => layout.Active).To(vm => vm.Active);
            set.Bind(heightLayout).For(layout => layout.Constant).To(vm => vm.Constant).Mode(MvxBindingMode.OneWay).WithConversion<FloatToNFloatConverter>();
            set.Bind(toggleHeight).For(t => t.State).To(vm => vm.Active);
            set.Bind(heightConstant).To(vm => vm.Constant).WithConversion<FloatToIntConverter>();
            set.Apply();
        }
    }
}
