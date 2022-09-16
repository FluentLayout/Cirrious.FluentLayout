using Cirrious.FluentLayouts.Touch;
using ObjCRuntime;

namespace QuickLayout.Touch.Views
{
    [Register("DirectionFormView")]
    public class DirectionFormView : MvxViewController
    {
        public override void ViewDidLoad()
        {
            View.BackgroundColor = UIColor.White;
            base.ViewDidLoad();

            // ios7 layout
            if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
                EdgesForExtendedLayout = UIRectEdge.None;

            var x = View.Center.X;
            var y = View.Center.Y;


            var east = new UILabel { Text = "East" };
            Add(east);

            var west = new UILabel { Text = "West" };
            Add(west);

            var north = new UILabel { Text = "North" };
            Add(north);

            var south = new UILabel { Text = "South" };
            Add(south);

            var northEast = new UILabel { Text = "NorthEast" };
            Add(northEast);

            var northWest = new UILabel { Text = "NorthWest" };
            Add(northWest);

            var southEast = new UILabel { Text = "SouthEast" };
            Add(southEast);

            var southWest = new UILabel { Text = "SouthWest" };
            Add(southWest);

            var center = new UILabel { Text = "Center" };
            Add(center);

            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            View.AddConstraints(
                west.ToLeftMargin(View),
                west.WithSameCenterY(View),

                east.ToRightMargin(View),
                east.WithSameCenterY(View),

                north.ToTopMargin(View),
                north.WithSameCenterX(View),

                south.ToBottomMargin(View),
                south.WithSameCenterX(View),

                northWest.ToLeftMargin(View),
                northWest.ToTopMargin(View),

                northEast.ToRightMargin(View),
                northEast.ToTopMargin(View),

                southWest.ToLeftMargin(View),
                southWest.ToBottomMargin(View),

                southEast.ToRightMargin(View),
                southEast.ToBottomMargin(View),

                center.WithSameCenterX(View),
                center.WithSameCenterY(View)
            );
        }
    }
}