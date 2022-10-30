using Microsoft.Extensions.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace QuickLayout.Core.ViewModels
{
    public class FirstViewModel
        : MvxNavigationViewModel
    {
        public FirstViewModel(ILoggerFactory loggerFactory, IMvxNavigationService navigationService)
            : base(loggerFactory, navigationService)
        {
        }

        public void GoDetails() => NavigationService.Navigate<DetailsViewModel>();

        public void GoForm() => NavigationService.Navigate<FormViewModel>();

        public void GoFormGrid() => NavigationService.Navigate<FormGridViewModel>();

        public void GoSearch() => NavigationService.Navigate<SearchViewModel>();

        public void GoTip() => NavigationService.Navigate<TipViewModel>();

		public void GoUpdateConstraints() => NavigationService.Navigate<UpdateConstraintsViewModel>();

		public void GoAdvancedVerticalStack() => NavigationService.Navigate<AdvancedVerticalStackViewModel>();

	    public void GoFullSize() => NavigationService.Navigate<FullSizeViewModel>();
	    
	    public void GoDirectionForm() => NavigationService.Navigate<DirectionFormViewModel>();

        public void GoRightToLeft() => NavigationService.Navigate<RightToLeftViewModel>();

        public void GoViewWithSafeArea() => NavigationService.Navigate<ViewWithSafeAreaViewModel>();

        public void GoCenterConstraints() => NavigationService.Navigate<ToCenterConstraintsViewModel>();
        
        public void GoViewAspectRatio() => NavigationService.Navigate<AspectRatioViewModel>();
    }
}