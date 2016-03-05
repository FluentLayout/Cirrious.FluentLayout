using Cirrious.FluentLayouts;
using Cirrious.FluentLayouts.Touch;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using Foundation;
using UIKit;
using ObjCRuntime;
using QuickLayout.Core.ViewModels;

namespace QuickLayout.Touch.Views
{
    [Register("FirstView")]
    public class FirstView : MvxViewController
    {
		private UIButton _viewForm, _viewFormGrid, _viewDetails, _viewSearch, _viewTip, _viewUpdateConstaints, _viewAdvancedVerticalStack;

        public override void ViewDidLoad()
        {
            View.BackgroundColor = UIColor.White;
            base.ViewDidLoad();

            // ios7 layout
            if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
                EdgesForExtendedLayout = UIRectEdge.None;

			_viewForm = new UIButton(UIButtonType.RoundedRect);
			_viewForm.SetTitle("Form", UIControlState.Normal);
			Add(_viewForm);

			_viewFormGrid = new UIButton(UIButtonType.RoundedRect);
			_viewFormGrid.SetTitle("FormGrid", UIControlState.Normal);
			Add(_viewFormGrid);

			_viewDetails = new UIButton(UIButtonType.RoundedRect);
			_viewDetails.SetTitle("Details", UIControlState.Normal);
			Add(_viewDetails);

		    _viewSearch = new UIButton(UIButtonType.RoundedRect);
		    _viewSearch.SetTitle("Search", UIControlState.Normal);
		    Add(_viewSearch);

			_viewTip = new UIButton(UIButtonType.RoundedRect);
			_viewTip.SetTitle("Tip", UIControlState.Normal);
			Add(_viewTip);

			_viewUpdateConstaints = new UIButton(UIButtonType.RoundedRect);
			_viewUpdateConstaints.SetTitle("Update Live Constraints", UIControlState.Normal);
			Add(_viewUpdateConstaints);

			_viewAdvancedVerticalStack = new UIButton(UIButtonType.RoundedRect);
			_viewAdvancedVerticalStack.SetTitle("Advanced Vertical Stack Panel", UIControlState.Normal);
			Add(_viewAdvancedVerticalStack);

            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            var set = this.CreateBindingSet<FirstView, FirstViewModel>();
			set.Bind(_viewForm).To("GoForm");
			set.Bind(_viewFormGrid).To("GoFormGrid");
		    set.Bind(_viewDetails).To("GoDetails");
			set.Bind(_viewSearch).To("GoSearch");
			set.Bind(_viewTip).To("GoTip");
			set.Bind(_viewUpdateConstaints).To("GoUpdateConstraints");
			set.Bind(_viewAdvancedVerticalStack).To("GoAdvancedVerticalStack");
            set.Apply();

            var constraints = View.VerticalStackPanelConstraints(
                                            new Margins(20, 10, 20, 10, 5, 5),                                              
                                            View.Subviews);
            View.AddConstraints(constraints);
        }
    }
}