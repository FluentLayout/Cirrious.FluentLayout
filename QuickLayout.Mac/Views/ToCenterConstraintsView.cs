using AppKit;
using Cirrious.FluentLayouts.Touch;
using Cirrious.FluentLayouts.Touch.Extensions;
using Foundation;
using MvvmCross.Platforms.Mac.Views;
using QuickLayout.Core.ViewModels;

namespace QuickLayout.Mac.Views
{
    [Register("ToCenterConstraintsView")]
    public class ToCenterConstraintsView : MvxViewController<ToCenterConstraintsViewModel>
    {
        public override void LoadView()
        {
            View = new NSView();

            NSView firstContainer = new NSColoredView(NSColor.Blue)
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
            },

            secondContainer = new NSColoredView(NSColor.Red)
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
            },

            thirdContainer = new NSColoredView(NSColor.Yellow)
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
                AlphaValue = .5f
            };

            View.AddSubviews(firstContainer, secondContainer, thirdContainer);

            View.AddConstraints(new FluentLayout[]
            {
                firstContainer.AtTopOf(View),
                firstContainer.AtLeftOf(View),
                firstContainer.AboveCenterOf(View, 10f),
                firstContainer.ToLeftOfCenterOf(View, 10f),

                secondContainer.AtBottomOf(View),
                secondContainer.AtRightOf(View),
                secondContainer.ToRightOfCenterOf(View, 10f),
                secondContainer.BelowCenterOf(View, 10f),

                thirdContainer.ToRightOfCenterOf(firstContainer),
                thirdContainer.ToLeftOfCenterOf(secondContainer),
                thirdContainer.AboveCenterOf(secondContainer),
                thirdContainer.BelowCenterOf(firstContainer)
            });
        }
    }
}
