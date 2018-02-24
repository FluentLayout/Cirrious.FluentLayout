using System.Collections.Generic;
using System.Reflection;
using Cirrious.FluentLayouts.Touch;
using UIKit;
using Foundation;
using QuickLayout.Core.ViewModels;
using ObjCRuntime;
using MvvmCross.iOS.Views;
using MvvmCross.Binding.BindingContext;

namespace QuickLayout.Touch
{
	[Register("AdvancedVerticalStackView")]
	public class AdvancedVerticalStackView : MvxViewController
	{
		public override void ViewDidLoad()
		{
			var scrollView = new UIScrollView()
			{
				BackgroundColor = UIColor.White,
				ShowsHorizontalScrollIndicator = false, 
				AutoresizingMask = UIViewAutoresizing.FlexibleHeight,
			};
			View = scrollView;
			scrollView.TranslatesAutoresizingMaskIntoConstraints = true;
			base.ViewDidLoad();

			// ios7 layout
			if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
				EdgesForExtendedLayout = UIRectEdge.None;

			var set = this.CreateBindingSet<AdvancedVerticalStackView, DetailsViewModel>();

			var topMargins = new List<float>();
			var leftMargins = new List<float>();
			var rightMargins = new List<float>();

			foreach (var propertyInfo in typeof(DetailsViewModel).GetProperties(BindingFlags.Instance | BindingFlags.Public))
			{
				if (propertyInfo.PropertyType != typeof (string))
					continue;

				topMargins.Add(20);
				leftMargins.Add(0);
				rightMargins.Add(0);
				var introLabel = new UILabel
				{
					Text = propertyInfo.Name + ":",
					TranslatesAutoresizingMaskIntoConstraints = false,
				};
				Add(introLabel);

				topMargins.Add(0);
				leftMargins.Add(25);
				rightMargins.Add(25);
				var textField = new UITextField
				{
					BorderStyle = UITextBorderStyle.RoundedRect,
					TranslatesAutoresizingMaskIntoConstraints = false,
					BackgroundColor = UIColor.LightGray
				};
				Add(textField);

				topMargins.Add(0);
				leftMargins.Add(40);
				rightMargins.Add(40);
				var label = new UILabel
				{
					TranslatesAutoresizingMaskIntoConstraints = false,
					BackgroundColor = UIColor.Yellow,
					TextAlignment = UITextAlignment.Center
				};
				Add(label);

				set.Bind(label).To(propertyInfo.Name);
				set.Bind(textField).To(propertyInfo.Name);
			}
			set.Apply();

			var marginMultiplier = UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad ? 2 : 1;

			var constraints = View.AdvancedVerticalStackPanelConstraints(
				new Margins(20, 10, 20, 10, 5, 5),
				leftMargins.ToArray(),
				topMargins.ToArray(),
				rightMargins.ToArray(),
				marginMultiplier,
				View.Subviews);
			View.AddConstraints(constraints);
		}
	}
}

