using Cirrious.FluentLayouts.Touch;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Views;
using Foundation;
using UIKit;
using ObjCRuntime;
using QuickLayout.Core.ViewModels;
using MvvmCross.Platforms.Ios.Presenters.Attributes;

namespace QuickLayout.Touch.Views
{
	[Register("FirstView")]
    [MvxRootPresentation(WrapInNavigationController = true)]
    public class FirstView : MvxViewController
    {
		private UIButton _viewForm, _viewFormGrid, _viewDetails, _viewSearch, _viewTip, _viewUpdateConstaints, _viewAdvancedVerticalStack, _fullSize, _directionFormView, _rightToLeft, _viewSafeArea, _viewCenterConstraints, _viewReadableContentGuide, _viewMarginsGuide;

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

			_fullSize = new UIButton(UIButtonType.RoundedRect);
			_fullSize.SetTitle("Full Size (animated)", UIControlState.Normal);
			Add(_fullSize);

			_directionFormView = new UIButton(UIButtonType.RoundedRect);
			_directionFormView.SetTitle("Directions", UIControlState.Normal);
			Add(_directionFormView);	

            _rightToLeft = new UIButton(UIButtonType.RoundedRect);
            _rightToLeft.SetTitle("Right-To-Left Support", UIControlState.Normal);
            Add(_rightToLeft);

            _viewSafeArea = new UIButton(UIButtonType.RoundedRect);
            _viewSafeArea.SetTitle("View with Safe Area", UIControlState.Normal);
            Add(_viewSafeArea);

            _viewCenterConstraints = new UIButton(UIButtonType.RoundedRect);
            _viewCenterConstraints.SetTitle("View Contraining to centers", UIControlState.Normal);
            Add(_viewCenterConstraints);
            
            _viewReadableContentGuide = new UIButton(UIButtonType.RoundedRect);
            _viewReadableContentGuide.SetTitle("View with Readable Content Guide", UIControlState.Normal);
            Add(_viewReadableContentGuide);
            
            _viewMarginsGuide = new UIButton(UIButtonType.RoundedRect);
            _viewMarginsGuide.SetTitle("View with Margins Guide", UIControlState.Normal);
            Add(_viewMarginsGuide);

			View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            var set = this.CreateBindingSet<FirstView, FirstViewModel>();
			set.Bind(_viewForm).To("GoForm");
			set.Bind(_viewFormGrid).To("GoFormGrid");
		    set.Bind(_viewDetails).To("GoDetails");
			set.Bind(_viewSearch).To("GoSearch");
			set.Bind(_viewTip).To("GoTip");
			set.Bind(_viewUpdateConstaints).To("GoUpdateConstraints");
			set.Bind(_viewAdvancedVerticalStack).To("GoAdvancedVerticalStack");
	        set.Bind(_fullSize).To("GoFullSize");
			set.Bind(_directionFormView).To("GoDirectionForm");
            set.Bind(_rightToLeft).To("GoRightToLeft");
            set.Bind(_viewSafeArea).To("GoViewWithSafeArea");
            set.Bind(_viewCenterConstraints).To("GoCenterConstraints");
            set.Bind(_viewReadableContentGuide).To("GoViewWithReadableContentGuide");
            set.Bind(_viewMarginsGuide).To("GoViewWithMarginsGuide");
            set.Apply();

            var constraints = View.VerticalStackPanelConstraints(
                                            new Margins(20, 10, 20, 10, 5, 5),                                              
                                            View.Subviews);
            View.AddConstraints(constraints);
        }
    }
}