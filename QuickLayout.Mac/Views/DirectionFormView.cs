using AppKit;
using Cirrious.FluentLayouts.Touch;
using Foundation;
using MvvmCross.Platforms.Mac.Views;

namespace QuickLayout.Mac.Views
{
    [Register("DirectionFormView")]
	public class DirectionFormView : MvxViewController
    {
        public override void LoadView()
        {
            View = new NSView();

            var east = new NSTextField { Editable = false, StringValue = "East" };
            View.AddSubview(east);

            var west = new NSTextField { Editable = false, StringValue = "West" };
            View.AddSubview(west);

            var north = new NSTextField { Editable = false, StringValue = "North" };
            View.AddSubview(north);

            var south = new NSTextField { Editable = false, StringValue = "South" };
            View.AddSubview(south);

            var northEast = new NSTextField { Editable = false, StringValue = "NorthEast" };
            View.AddSubview(northEast);

            var northWest = new NSTextField { Editable = false, StringValue = "NorthWest" };
            View.AddSubview(northWest);

            var southEast = new NSTextField { Editable = false, StringValue = "SouthEast" };
            View.AddSubview(southEast);

            var southWest = new NSTextField { Editable = false, StringValue = "SouthWest" };
            View.AddSubview(southWest);

            var center = new NSTextField { Editable = false, StringValue = "Center" };
            View.AddSubview(center);

            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            View.AddConstraints(
                west.AtLeftOf(View), //.ToLeftMargin(View),
                west.WithSameCenterY(View),

                east.AtRightOf(View),//.ToRightMargin(View),
                east.WithSameCenterY(View),

                north.AtTopOf(View),//.ToTopMargin(View),
                north.WithSameCenterX(View),

                south.AtBottomOf(View),//.ToBottomMargin(View),
                south.WithSameCenterX(View),

                northWest.AtLeftOf(View), //.ToLeftMargin(View),
                northWest.AtTopOf(View), //ToTopMargin(View),

                northEast.AtRightOf(View),//.ToRightMargin(View),
                northEast.AtTopOf(View), //.ToTopMargin(View),

                southWest.AtLeftOf(View), //.ToLeftMargin(View),
                southWest.AtBottomOf(View), //.ToBottomMargin(View),

                southEast.AtRightOf(View), //.ToRightMargin(View),
                southEast.AtBottomOf(View), //.ToBottomMargin(View),

                center.WithSameCenterX(View),
                center.WithSameCenterY(View)
            );
        }
    }
}