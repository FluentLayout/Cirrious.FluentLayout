using System;
using System.Collections.Generic;
using Cirrious.FluentLayouts.Touch;
using Foundation;
using MvvmCross.Platforms.Ios.Views;
using ObjCRuntime;
using UIKit;

namespace QuickLayout.Touch.Views
{
    [Register("FullSizeView")]
	public class FullSizeView : MvxViewController
	{
		private IEnumerable<FluentLayout> _cyanLayouts;

		public override void ViewDidLoad()
		{
			View.BackgroundColor = UIColor.White;
			base.ViewDidLoad();

			// ios7 layout
			if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
				EdgesForExtendedLayout = UIRectEdge.None;

			var cyan = new UIView { BackgroundColor = UIColor.Cyan };
			var red = new UIView { BackgroundColor = UIColor.Red };
			var yellow = new UIView { BackgroundColor = UIColor.Yellow };
			var brown = new UIView { BackgroundColor = UIColor.Brown };
			var green = new UIView { BackgroundColor = UIColor.Green };
			var clickMe = new UILabel { Text = "Tap me", TextAlignment = UITextAlignment.Center };

			View.AddSubviews(cyan, red, yellow, brown, green, clickMe);
			View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

			_cyanLayouts = cyan.FullSizeOf(View, 20);

			View.AddConstraints(_cyanLayouts);
			View.AddConstraints(red.FullSizeOf(cyan, new Margins(10, 30)));
			View.AddConstraints(yellow.FullSizeOf(red, 5));
			View.AddConstraints(brown.FullSizeOf(yellow, new Margins(20, 40, 50, 10)));
			View.AddConstraints(green.FullSizeOf(brown, 10));
			View.AddConstraints(
				clickMe.WithSameCenterX(green),
				clickMe.WithSameCenterY(green)
			);

			View.AddGestureRecognizer(new UITapGestureRecognizer(AnimateRandom));
		}

		private void AnimateRandom()
		{
			var random = new Random();
			_cyanLayouts.GetLayoutById("Top").Constant = random.Next(5, 150);
			_cyanLayouts.GetLayoutById("Bottom").Constant = random.Next(-150, -5);
			_cyanLayouts.GetLayoutById("Left").Constant = random.Next(5, 50);
			_cyanLayouts.GetLayoutById("Right").Constant = random.Next(-50, -5);

			UIView.Animate(0.3, View.LayoutIfNeeded);
		}
	}
}
