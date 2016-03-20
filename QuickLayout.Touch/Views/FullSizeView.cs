using Cirrious.FluentLayouts.Touch;
using Foundation;
using MvvmCross.iOS.Views;
using ObjCRuntime;
using UIKit;

namespace QuickLayout.Touch.Views
{
	[Register("FullSizeView")]
	public class FullSizeView : MvxViewController
	{
		public override void ViewDidLoad()
		{
			View.BackgroundColor = UIColor.White;
			base.ViewDidLoad();

			// ios7 layout
			if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
				EdgesForExtendedLayout = UIRectEdge.None;

			var box1 = new UIView { BackgroundColor = UIColor.Cyan };
			var box2 = new UIView { BackgroundColor = UIColor.Red };
			var box3 = new UIView { BackgroundColor = UIColor.Yellow };
			var box4 = new UIView { BackgroundColor = UIColor.Brown };
			var box5 = new UIView { BackgroundColor = UIColor.Green };

			View.AddSubviews(box1, box2, box3, box4, box5);
			View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

			View.AddConstraints(box1.FullSizeOf(View, 20));
			View.AddConstraints(box2.FullSizeOf(box1, new Margins(10, 30)));
			View.AddConstraints(box3.FullSizeOf(box2, 5));
			View.AddConstraints(box4.FullSizeOf(box3, new Margins(20, 40, 50, 10, 0, 0)));
			View.AddConstraints(box5.FullSizeOf(box4, 10));
		}
	}
}
