using Cirrious.FluentLayouts;
using Cirrious.FluentLayouts.Touch;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Touch.Views;
using Foundation;
using UIKit;
using ObjCRuntime;
using QuickLayout.Core.ViewModels;

namespace QuickLayout.Touch.Views
{
    [Register("FirstView")]
    public class FirstView : MvxViewController
    {
        public override void ViewDidLoad()
        {
            View.BackgroundColor = UIColor.White;
            base.ViewDidLoad();

            // ios7 layout
            if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
                EdgesForExtendedLayout = UIRectEdge.None;

            var buttonF = new UIButton(UIButtonType.RoundedRect);
            buttonF.SetTitle("Form", UIControlState.Normal);
            Add(buttonF);

            var buttonFG = new UIButton(UIButtonType.RoundedRect);
            buttonFG.SetTitle("FormGrid", UIControlState.Normal);
            Add(buttonFG);

            var buttonD = new UIButton(UIButtonType.RoundedRect);
            buttonD.SetTitle("Details", UIControlState.Normal);
            Add(buttonD);

			var buttonD2 = new UIButton(UIButtonType.RoundedRect);
			buttonD2.SetTitle("Details with margins", UIControlState.Normal);
			Add(buttonD2);

			var buttonS = new UIButton(UIButtonType.RoundedRect);
            buttonS.SetTitle("Search", UIControlState.Normal);
            Add(buttonS);

            var buttonT = new UIButton(UIButtonType.RoundedRect);
            buttonT.SetTitle("Tip", UIControlState.Normal);
            Add(buttonT);

            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            var set = this.CreateBindingSet<FirstView, FirstViewModel>();
            set.Bind(buttonF).To("GoForm");
            set.Bind(buttonFG).To("GoFormGrid");
            set.Bind(buttonD).To("GoDetails");
	        set.Bind(buttonD2).To("GoDetailsWithMargins");
            set.Bind(buttonS).To("GoSearch");
            set.Bind(buttonT).To("GoTip");
            set.Apply();

            var constraints = View.VerticalStackPanelConstraints(
                                            new Margins(20, 10, 20, 10, 5, 5),                                              
                                            View.Subviews);
            View.AddConstraints(constraints);
        }
    }
}