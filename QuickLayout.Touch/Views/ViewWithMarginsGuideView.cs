using Cirrious.FluentLayouts.Touch;
using Foundation;
using MvvmCross.Platforms.Ios.Views;
using UIKit;

namespace QuickLayout.Touch.Views
{
    [Register("ViewWithMarginsGuideView")]
    public class ViewWithMarginsGuideView : MvxViewController
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View.BackgroundColor = UIColor.FromRGB(248, 191, 120);

            var viewContainer = new UIView {BackgroundColor = UIColor.Clear};

            var sampleText = new UITextView
            {
                Editable = false,
                Selectable = false,
                Text =
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam aliquet massa eu tempus semper. Nulla elementum mi quis erat blandit eleifend. Quisque dictum, sem eget volutpat scelerisque, quam orci lobortis enim, ut luctus enim massa in nisi. Mauris sed mi id leo lacinia lobortis. Integer elementum, erat gravida vestibulum rhoncus, enim velit consectetur est, dignissim condimentum urna turpis ac ex. Nulla arcu mauris, hendrerit nec tortor in, feugiat ullamcorper mauris. Aliquam eget tempus eros. Curabitur suscipit, arcu eu luctus mollis, nunc erat ornare erat, id viverra nisl ligula sit amet ex. Etiam in quam vitae est convallis eleifend. Fusce gravida arcu in orci lobortis pulvinar. Morbi tortor mi, elementum nec purus quis, eleifend imperdiet mi. Nunc commodo et sem vitae finibus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc nec erat eget orci malesuada vulputate. \n \nPhasellus vulputate dolor eu massa varius efficitur. Sed sed tortor eu elit ornare mollis id non sapien. Nam at turpis volutpat ligula aliquam aliquet placerat sed purus. Phasellus magna urna, maximus vitae erat et, malesuada tincidunt velit. Mauris efficitur velit fermentum imperdiet convallis. In eget erat nisi. Curabitur ut leo sodales, consectetur lorem ut, iaculis est. Nullam ornare, justo id condimentum pharetra, enim nisl posuere ex, a fermentum justo enim sit amet dolor. Sed suscipit sapien augue, nec dignissim nisl laoreet eu. Maecenas eros enim, aliquet vitae arcu id, fermentum dignissim lorem. Etiam sit amet commodo nunc. In vitae ullamcorper velit. Integer in mauris eget erat mattis feugiat at id neque.",
                TextColor = UIColor.Black,
                BackgroundColor = UIColor.Clear
            };
            sampleText.TextContainer.LineBreakMode = UILineBreakMode.WordWrap;
            sampleText.Font = UIFont.BoldSystemFontOfSize(18f);

            View.AddSubview(viewContainer);
            viewContainer.AddSubview(sampleText);

            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
            viewContainer.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            View.AddConstraints(
                viewContainer.AtLeftOf(View),
                viewContainer.AtTopOf(View),
                viewContainer.AtRightOf(View),
                viewContainer.AtBottomOf(View)
            );

            viewContainer.AddConstraints(
                sampleText.AtTopOfMargins(viewContainer),
                // sampleText.AtTopOfSafeArea(viewContainer), -> use this when UINavigationBar not present to avoid content overlap under iPhone X notch
                sampleText.AtLeftOfMargins(viewContainer),
                //sampleText.AtLeftOf(viewContainer), -> if this is used, content overlaps under notch on landscape
                sampleText.AtRightOfMargins(viewContainer),
                //sampleText.AtRightOf(viewContainer), -> if this is used, content overlaps under notch on landscape
                sampleText.AtBottomOfMargins(viewContainer)
                //sampleText.AtBottomOf(viewContainer) -> if this is used, content overlaps under notch on landscape
            );
        }
    }
}