using System;
using Cirrious.FluentLayouts.Touch;
using MvvmCross.Platforms.Ios.Views;
using QuickLayout.Core.ViewModels;
using UIKit;

namespace QuickLayout.Touch.Views
{
    public class AspectRatioView : MvxViewController<AspectRatioViewModel>
    {
        public override void ViewDidLoad()
        {
            View.BackgroundColor = UIColor.Black;

            var firstView = new UIView()
            {
                BackgroundColor = UIColor.Red,
                Alpha = 0.5f
            };
            var secondView = new UIView()
            {
                BackgroundColor = UIColor.Blue,
                Alpha = 0.5f
            };
            var thirdView = new UIView()
            {
                BackgroundColor = UIColor.Yellow
            };

            View.AddSubviews(firstView, secondView, thirdView);
            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            const float length = 200f;
            const float padding = 32f;
            
            View.AddConstraints(new FluentLayout[]
            {
                firstView.WithSameCenterX(View),
                firstView.WithSameCenterY(View),
                secondView.WithSameCenterX(View),
                secondView.WithSameCenterY(View),
                thirdView.WithSameCenterX(View),
                thirdView.WithSameCenterY(View),
                
                firstView.Height().EqualTo(length),
                firstView.WithAspectRatio(1f/2f), // height is 2x larger than width
                
                secondView.Width().EqualTo().HeightOf(firstView),
                secondView.WithAspectRatio(2f/1f), // width is 2x larger than height
                
                thirdView.Width().EqualTo().WidthOf(firstView).Minus(padding),
                thirdView.WithAspectRatio(1f), // width and height are equal (force to be square)
            });
        }
    }
}