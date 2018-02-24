using Cirrious.FluentLayouts.Touch;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using UIKit;
using ObjCRuntime;
using QuickLayout.Core.ViewModels;
using Foundation;

namespace QuickLayout.Touch
{
	[Register("UpdateConstraintsView")]
	public class UpdateConstraintsView : MvxViewController<UpdateConstraintsViewModel>
	{
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			View.BackgroundColor = UIColor.White;

			if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
				EdgesForExtendedLayout = UIRectEdge.None;

			var label = new UILabel 
			{ 
				Text = "Update this label's height constraint height constant and active settings",
				BackgroundColor = UIColor.LightGray,
				TextColor = UIColor.Black,
				LineBreakMode = UILineBreakMode.WordWrap,
				Lines = 0
			};
			var toggleHeight = new UISwitch();
			var heightConstant = new UISlider { MinValue = 0, MaxValue = 400 };

			View.AddSubviews(label, toggleHeight, heightConstant);

			View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

			var heightLayout = label.Height().EqualTo(ViewModel.Constant).WithIdentifier("foo");

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
			set.Bind(heightLayout).For(layout => layout.Constant).To(vm => vm.Constant);
			set.Bind(toggleHeight).To(vm => vm.Active);
			set.Bind(heightConstant).To(vm => vm.Constant);
			set.Apply();
		}
	}
}

