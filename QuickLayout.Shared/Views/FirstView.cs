using MvvmCross.Binding.BindingContext;
using Cirrious.FluentLayouts.Touch;
#if __IOS__
using MvvmCross.iOS.Views;
#elif __TVOS__
using MvvmCross.tvOS.Views;
#endif
using UIKit;
using QuickLayout.Core.ViewModels;
using MvvmCross.tvOS.Views.Presenters.Attributes;

namespace QuickLayout.Touch.Views
{
    [MvxRootPresentation]
    public class FirstView : MvxViewController<FirstViewModel>
    {
		private UIButton _viewForm, _viewFormGrid, _viewDetails, _viewSearch, _viewTip, _viewUpdateConstaints, _viewAdvancedVerticalStack, _fullSize, _directionFormView;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.White;

            // ios7 layout
            //if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
                //EdgesForExtendedLayout = UIRectEdge.None;

            _viewForm = new UIButton(UIButtonType.System);
			_viewForm.SetTitle("Form", UIControlState.Normal);
			Add(_viewForm);

            _viewFormGrid = new UIButton(UIButtonType.System);
			_viewFormGrid.SetTitle("FormGrid", UIControlState.Normal);
			Add(_viewFormGrid);

            _viewDetails = new UIButton(UIButtonType.System);
            _viewDetails.Enabled = true;
			_viewDetails.SetTitle("Details", UIControlState.Normal);
			Add(_viewDetails);

            _viewSearch = new UIButton(UIButtonType.System);
		    _viewSearch.SetTitle("Search", UIControlState.Normal);
		    Add(_viewSearch);

            _viewTip = new UIButton(UIButtonType.System);
			_viewTip.SetTitle("Tip", UIControlState.Normal);
			Add(_viewTip);

            _viewUpdateConstaints = new UIButton(UIButtonType.System);
			_viewUpdateConstaints.SetTitle("Update Live Constraints", UIControlState.Normal);
			Add(_viewUpdateConstaints);

            _viewAdvancedVerticalStack = new UIButton(UIButtonType.System);
			_viewAdvancedVerticalStack.SetTitle("Advanced Vertical Stack Panel", UIControlState.Normal);
			Add(_viewAdvancedVerticalStack);

            _fullSize = new UIButton(UIButtonType.System);
			_fullSize.SetTitle("Full Size (animated)", UIControlState.Normal);
			Add(_fullSize);

            _directionFormView = new UIButton(UIButtonType.System);
			_directionFormView.SetTitle("Directions", UIControlState.Normal);
			Add(_directionFormView);			

			View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            var set = this.CreateBindingSet<FirstView, FirstViewModel>();
            set.Bind(_viewForm).To(vm => vm.GoFormCommand);
            set.Bind(_viewFormGrid).To(vm => vm.GoFormGridCommand);
            set.Bind(_viewDetails).To(vm => vm.GoDetailsCommand);
            set.Bind(_viewSearch).To(vm => vm.GoSearchCommand);
#if __IOS__
            set.Bind(_viewTip).To(vm => vm.GoTipCommand);
            set.Bind(_viewUpdateConstaints).To(vm => vm.GoUpdateConstraintsCommand);
            set.Bind(_fullSize).To(vm => vm.GoFullSizeCommand);
#endif
            set.Bind(_viewAdvancedVerticalStack).To(vm => vm.GoAdvancedVerticalStackCommand);
            set.Bind(_directionFormView).To(vm => vm.GoDirectionFormCommand);
            set.Apply();

            var constraints = View.VerticalStackPanelConstraints(
                                            new Margins(20, 100, 20, 10, 5, 5),                                              
                                            View.Subviews);
            View.AddConstraints(constraints);
        }
    }
}