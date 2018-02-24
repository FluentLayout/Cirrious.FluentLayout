using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Navigation;

namespace QuickLayout.Core.ViewModels
{
    public class FirstViewModel: MvxViewModel
    {
        private readonly IMvxNavigationService _mvxNavigationService;

        public FirstViewModel(IMvxNavigationService mvxNavigationService)
        {
            _mvxNavigationService = mvxNavigationService;
        }

        public IMvxCommand GoDetailsCommand => new MvxCommand(() => _mvxNavigationService.Navigate<DetailsViewModel>());

        public IMvxCommand GoFormCommand => new MvxCommand(() => _mvxNavigationService.Navigate<FormViewModel>());

        public IMvxCommand GoFormGridCommand => new MvxCommand(() => _mvxNavigationService.Navigate<FormGridViewModel>());

        public IMvxCommand GoSearchCommand => new MvxCommand(() => _mvxNavigationService.Navigate<SearchViewModel>());

        public IMvxCommand GoTipCommand => new MvxCommand(() => _mvxNavigationService.Navigate<TipViewModel>());

        public IMvxCommand GoUpdateConstraintsCommand => new MvxCommand(() => _mvxNavigationService.Navigate<UpdateConstraintsViewModel>());

        public IMvxCommand GoAdvancedVerticalStackCommand => new MvxCommand(() => _mvxNavigationService.Navigate<AdvancedVerticalStackViewModel>());

        public IMvxCommand GoFullSizeCommand => new MvxCommand(() => _mvxNavigationService.Navigate<FullSizeViewModel>());
	    
        public IMvxCommand GoDirectionFormCommand => new MvxCommand(() => _mvxNavigationService.Navigate<DirectionFormViewModel>());
    }
}