using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Navigation;
using System;

namespace QuickLayout.Core.ViewModels
{
    public class FirstViewModel: MvxViewModel
    {
        public IMvxCommand GoDetailsCommand => new MvxCommand(() => ShowViewModel<DetailsViewModel>());

        public IMvxCommand GoFormCommand => new MvxCommand(() => ShowViewModel<FormViewModel>());

        public IMvxCommand GoFormGridCommand => new MvxCommand(() => ShowViewModel<FormGridViewModel>());

        public IMvxCommand GoSearchCommand => new MvxCommand(() => ShowViewModel<SearchViewModel>());

        public IMvxCommand GoTipCommand => new MvxCommand(() => ShowViewModel<TipViewModel>());

        public IMvxCommand GoUpdateConstraintsCommand => new MvxCommand(() => ShowViewModel<UpdateConstraintsViewModel>());

        public IMvxCommand GoAdvancedVerticalStackCommand => new MvxCommand(() => ShowViewModel<AdvancedVerticalStackViewModel>());

        public IMvxCommand GoFullSizeCommand => new MvxCommand(() => ShowViewModel<FullSizeViewModel>());
	    
        public IMvxCommand GoDirectionFormCommand => new MvxCommand(() => ShowViewModel<DirectionFormViewModel>());
    }
}