using Cirrious.FluentLayouts;
using Cirrious.FluentLayouts.Touch;
using MvvmCross.Binding.BindingContext;
#if __IOS__
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;
#elif __TVOS__
using MvvmCross.tvOS.Views;
using MvvmCross.tvOS.Views.Presenters.Attributes;
#endif
using UIKit;
using ObjCRuntime;
using QuickLayout.Core.ViewModels;

namespace QuickLayout.Touch.Views
{
    [MvxChildPresentation]
    public class SearchView : MvxViewController
    {
        public override void ViewDidLoad()
        {
            View.BackgroundColor = UIColor.White;
            base.ViewDidLoad();

            // ios7 layout
            if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
                EdgesForExtendedLayout = UIRectEdge.None;

            var button = new UIButton(UIButtonType.RoundedRect);
            button.SetTitle("Search", UIControlState.Normal);
            Add(button);

            var text = new UITextField() { BorderStyle = UITextBorderStyle.RoundedRect };
            Add(text);

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