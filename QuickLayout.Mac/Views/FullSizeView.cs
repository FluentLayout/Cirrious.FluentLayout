using System;
using System.Collections.Generic;
using AppKit;
using Cirrious.FluentLayouts.Touch;
using Cirrious.FluentLayouts.Touch.Extensions;
using Foundation;
using MvvmCross.Platforms.Mac.Views;

namespace QuickLayout.Mac.Views
{
    [Register("FullSizeView")]
	public class FullSizeView : MvxViewController
	{
		private IEnumerable<FluentLayout> _cyanLayouts;

        public override void LoadView()
        {
            View = new NSView();

            var cyan = new NSColoredView(NSColor.Cyan);
            var red = new NSColoredView(NSColor.Red);
            var yellow = new NSColoredView(NSColor.Yellow);
            var brown = new NSColoredView(NSColor.Brown);
            var green = new NSColoredView(NSColor.Green);
            var clickMe = new NSTextField { StringValue = "Tap me", Alignment = NSTextAlignment.Center, Editable = false };

            View.AddSubviews(cyan, red, yellow, brown, green, clickMe);
            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            _cyanLayouts = cyan.FullSizeOf(View, 20);

            View.AddConstraints(_cyanLayouts);
            View.AddConstraints(red.FullSizeOf(cyan, new Margins(10, 30)));
            View.AddConstraints(yellow.FullSizeOf(red, 5));
            View.AddConstraints(brown.FullSizeOf(yellow, new Margins(20, 40, 50, 10)));
            View.AddConstraints(green.FullSizeOf(brown, 10));
            View.AddConstraints(
                clickMe.WithSameCenterX(green),
                clickMe.WithSameCenterY(green)
            );

            View.AddGestureRecognizer(new NSClickGestureRecognizer(AnimateRandom));
        }

        private void AnimateRandom()
        {
            var random = new Random();

            NSAnimationContext.RunAnimation(context =>
            {
                context.Duration = 0.3;
                context.AllowsImplicitAnimation = true;

                _cyanLayouts.GetLayoutById("Top").Constant = random.Next(5, 150);
                _cyanLayouts.GetLayoutById("Bottom").Constant = random.Next(-150, -5);
                _cyanLayouts.GetLayoutById("Left").Constant = random.Next(5, 50);
                _cyanLayouts.GetLayoutById("Right").Constant = random.Next(-50, -5);

                View.LayoutSubtreeIfNeeded();
            });
        }
	}
}
