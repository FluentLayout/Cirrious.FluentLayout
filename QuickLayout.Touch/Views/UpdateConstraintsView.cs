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
		    {
		        EdgesForExtendedLayout = UIRectEdge.None;
		    }

		    var label = new UILabel 
			{ 
				Text = "This label has a Height constraint applied to it. \r\nThe toggle switch is bound to the Contraint's Active boolean and the slider to the Constraint's Constant value.",
				BackgroundColor = UIColor.LightGray,
				TextColor = UIColor.Black,
				LineBreakMode = UILineBreakMode.WordWrap,
				Lines = 0
			};

			var heightToggle = new UISwitch();
			var labelHeightSlider = new UISlider { MinValue = 0, MaxValue = 400 };
            
			View.AddSubviews(label, heightToggle, labelHeightSlider);

			View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

			var heightLayoutConstraint = label.Height().EqualTo(ViewModel.Constant).WithIdentifier("labelHeight_Constraint_Id");

			var margin = 10;

			View.AddConstraints(
                labelHeightSlider.AtTopOf(View, margin),
                labelHeightSlider.AtLeftOf(View, margin),
                labelHeightSlider.AtRightOf(View, margin),

				heightToggle.Below(labelHeightSlider, margin),
				heightToggle.WithSameLeft(labelHeightSlider),

				label.AtLeftOf(View, margin),
				label.Below(heightToggle, margin),
				label.AtRightOf(View, margin),
                heightLayoutConstraint
            );

			var set = this.CreateBindingSet<UpdateConstraintsView, UpdateConstraintsViewModel>();
			set.Bind(heightLayoutConstraint).For(constraint => constraint.Active).To(vm => vm.Active);
			set.Bind(heightLayoutConstraint).For(constraint => constraint.Constant).To(vm => vm.Constant);
			set.Bind(heightToggle).To(vm => vm.Active);
			set.Bind(labelHeightSlider).To(vm => vm.Constant);
			set.Apply();
		}
	}
}

