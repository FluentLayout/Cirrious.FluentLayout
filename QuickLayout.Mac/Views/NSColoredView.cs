using AppKit;

namespace QuickLayout.Mac.Views
{
    public class NSColoredView : NSView
    {
        public NSColoredView(NSColor color)
        {
            this.WantsLayer = true;
            this.Layer.BackgroundColor = color.CGColor;
        }
    }
}
