using AppKit;
using Cirrious.FluentLayouts.Touch;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Mac.Views;
using QuickLayout.Core.ViewModels;

namespace QuickLayout.Mac.Views
{
    [Register("SearchView")]
    public class SearchView : MvxViewController
    {
        public override void LoadView()
        {
            View = new NSView();

            var button = new NSButton();
            button.Title = "Search";
            View.AddSubview(button);

            var text = new NSTextField();
            View.AddSubview(text);

            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            var set = this.CreateBindingSet<SearchView, SearchViewModel>();
            set.Bind(button).To("Search");
            set.Bind(text).To(vm => vm.SearchText);
            set.Apply();

            var hPadding = 10;
            var vPadding = 10;
            var ButtonWidth = 100;

            View.AddConstraints(

                    button.AtTopOf(View).Plus(vPadding),
                    button.AtRightOf(View).Minus(hPadding),
                    button.Width().EqualTo(ButtonWidth),

                    text.AtLeftOf(View, hPadding),
                    text.ToLeftOf(button, hPadding),
                    text.WithSameTop(button)

                );
        }
    }
}
