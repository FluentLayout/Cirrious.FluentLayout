using MvvmCross.Core.ViewModels;

namespace QuickLayout.Core.ViewModels
{
    public class FirstViewModel
        : MvxViewModel
    {
        public void GoDetails() => ShowViewModel<DetailsViewModel>();

        public void GoForm() => ShowViewModel<FormViewModel>();

        public void GoFormGrid() => ShowViewModel<FormGridViewModel>();

        public void GoSearch() => ShowViewModel<SearchViewModel>();

        public void GoTip() => ShowViewModel<TipViewModel>();

		public void GoUpdateConstraints() => ShowViewModel<UpdateConstraintsViewModel>();

		public void GoAdvancedVerticalStack() => ShowViewModel<AdvancedVerticalStackViewModel>();
    }
}