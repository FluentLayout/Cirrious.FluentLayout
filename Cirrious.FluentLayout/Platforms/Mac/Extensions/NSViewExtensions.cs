using AppKit;

namespace Cirrious.FluentLayouts.Touch.Extensions
{
    public static class NSViewExtensions
    {
        public static void AddSubviews(this NSView view, params NSView[] subviews)
        {
            foreach (var subview in subviews)
                view.AddSubview(subview);
        }
    }
}
