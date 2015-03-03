using System;
using UIKit;
using CoreGraphics;
using Cirrious.FluentLayouts.Touch;

namespace QuickLayout.Touch
{
    public class MyViewController : UIViewController
    {
        UIButton expandButton, contractButton;
        float controlHeight = 44f;
		UIView box;
		FluentLayout boxHeightConstraint;

        public MyViewController()
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View.Frame = UIScreen.MainScreen.Bounds;
            View.BackgroundColor = UIColor.White;
            View.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;

			expandButton = UIButton.FromType(UIButtonType.RoundedRect);

			expandButton.SetTitle("Expand", UIControlState.Normal);

			expandButton.TouchUpInside += (object sender, EventArgs e) => {

				boxHeightConstraint.Constant += 10f;

				UIView.Animate(.4d, () => box.LayoutIfNeeded());
			};

            View.AddSubview(expandButton);

			contractButton = UIButton.FromType(UIButtonType.RoundedRect);

			contractButton.SetTitle("Contract", UIControlState.Normal);

			contractButton.TouchUpInside += (object sender, EventArgs e) => {

				if(boxHeightConstraint != null){
					boxHeightConstraint.Minus (10);

					UIView.Animate(.4d, () => box.LayoutIfNeeded());
				}
			};

			View.AddSubview(contractButton);

			box = new UIView (){ BackgroundColor = UIColor.Blue };
			View.Add (box);

			View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints ();

			View.AddConstraints (
				expandButton.AtTopOf(View, 20f),
				expandButton.AtLeftOf(View),
				expandButton.AtRightOf(View),
				expandButton.Height().EqualTo(controlHeight),

				contractButton.Below(expandButton, 8f),
				contractButton.AtLeftOf(View),
				contractButton.AtRightOf(View),
				contractButton.Height().EqualTo(controlHeight),

				box.Below(contractButton, 8f),
				box.AtLeftOf(View),
				box.AtRightOf(View),
				(boxHeightConstraint = box.Height().EqualTo(controlHeight))
			);
        }

    }
}

