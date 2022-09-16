using Cirrious.FluentLayouts.Touch;
using QuickLayout.Core.ViewModels;

namespace QuickLayout.Touch.Views
{
    [Register("ToCenterConstraintsView")]
    public class ToCenterConstraintsView : MvxViewController<ToCenterConstraintsViewModel>
    {
        public override void ViewDidLoad()
        {
            View.BackgroundColor = UIColor.Black;

            UIView firstContainer = new UIView
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
                BackgroundColor = UIColor.Blue
            },

            secondContainer = new UIView
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
                BackgroundColor = UIColor.Red
            },

            thirdContainer = new UIView
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
                BackgroundColor = UIColor.Yellow,
                Alpha = .5f
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