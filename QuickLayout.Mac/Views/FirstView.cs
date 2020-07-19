using AppKit;
using Cirrious.FluentLayouts.Touch;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Mac.Presenters.Attributes;
using MvvmCross.Platforms.Mac.Views;
using QuickLayout.Core.ViewModels;

namespace QuickLayout.Mac.Views
{
    [Register("FirstView")]
    [MvxWindowPresentation]
    public class FirstView : MvxViewController
    {
		private NSButton _viewForm, _viewFormGrid, _viewDetails, _viewSearch, _viewTip, _viewUpdateConstaints, _viewAdvancedVerticalStack, _fullSize, _directionFormView, _rightToLeft, _viewCenterConstraints;

        public override void LoadView()
        {
            View = new NSView();

            _viewForm = new NSButton();
            _viewForm.Title = "Form";
            View.AddSubview(_viewForm);

            _viewFormGrid = new NSButton();
            _viewFormGrid.Title = "FormGrid";
            View.AddSubview(_viewFormGrid);

            _viewDetails = new NSButton();
            _viewDetails.Title = "Details";
            View.AddSubview(_viewDetails);

            _viewSearch = new NSButton();
            _viewSearch.Title = "Search";
            View.AddSubview(_viewSearch);

            _viewTip = new NSButton();
            _viewTip.Title = "Tip";
            View.AddSubview(_viewTip);

            _viewUpdateConstaints = new NSButton();
            _viewUpdateConstaints.Title = "Update Live Constraints";
            View.AddSubview(_viewUpdateConstaints);

            _viewAdvancedVerticalStack = new NSButton();
            _viewAdvancedVerticalStack.Title = "Advanced Vertical Stack Panel";
            View.AddSubview(_viewAdvancedVerticalStack);

            _fullSize = new NSButton();
            _fullSize.Title = "Full Size (animated)";
            View.AddSubview(_fullSize);

            _directionFormView = new NSButton();
            _directionFormView.Title = "Directions";
            View.AddSubview(_directionFormView);

            _rightToLeft = new NSButton();
            _rightToLeft.Title = "Right-To-Left Support";
            View.AddSubview(_rightToLeft);

            _viewCenterConstraints = new NSButton();
            _viewCenterConstraints.Title = "View Contraining to centers";
            View.AddSubview(_viewCenterConstraints);

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
            set.Bind(_viewCenterConstraints).To("GoCenterConstraints");
            set.Apply();

            var constraints = View.VerticalStackPanelConstraints(
                                            new Margins(20, 10, 20, 10, 5, 5),
                                            View.Subviews);
            View.AddConstraints(constraints);
        }
    }
}