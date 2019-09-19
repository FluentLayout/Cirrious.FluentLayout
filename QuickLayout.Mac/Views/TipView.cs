using Cirrious.FluentLayouts.Touch;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Mac.Views;
using Foundation;
using AppKit;
using QuickLayout.Core.ViewModels;

namespace QuickLayout.Touch.Views
{
    [Register("TipView")]
    public class TipView : MvxViewController
    {
        public override void LoadView()
        {
            View = new NSView();

            var subTotal = new NSTextField();
            var numberFormatter = new NSNumberFormatter();
            numberFormatter.NumberStyle = NSNumberFormatterStyle.Decimal;
            subTotal.Formatter = numberFormatter;
            View.AddSubview(subTotal);

            var seek = new NSSlider()
            {
                MinValue = 0,
                MaxValue = 100,
            };
            View.AddSubview(seek);

            var seekLabel = new NSTextField { Editable = false };
            View.AddSubview(seekLabel);

            var tipLabel = new NSTextField { Editable = false };
            View.AddSubview(tipLabel);

            var totalLabel = new NSTextField { Editable = false };
            View.AddSubview(totalLabel);

            var set = this.CreateBindingSet<TipView, TipViewModel>();
            set.Bind(subTotal).To(vm => vm.SubTotal);
            set.Bind(seek).To(vm => vm.Generosity);
            set.Bind(seekLabel).To(vm => vm.Generosity);
            set.Bind(tipLabel).To(vm => vm.Tip);
            set.Bind(totalLabel).To("SubTotal + Tip");
            set.Apply();

            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            var margin = 10;
            View.AddConstraints(
                    subTotal.AtLeftOf(View, margin),
                    subTotal.AtTopOf(View, margin),
                    subTotal.AtRightOf(View, margin),

                    seek.WithSameLeft(subTotal),
                    seek.Below(subTotal, margin),
                    seek.ToLeftOf(seekLabel, margin),
                    seek.WithRelativeWidth(seekLabel, 3),

                    seekLabel.WithSameRight(subTotal),
                    seekLabel.WithSameTop(seek),

                    tipLabel.Below(seek, margin),
                    tipLabel.WithSameLeft(seek),
                    tipLabel.WithSameWidth(totalLabel),

                    totalLabel.WithSameTop(tipLabel),
                    totalLabel.ToRightOf(tipLabel, margin),
                    totalLabel.WithSameRight(subTotal)
                );
        }
    }
}