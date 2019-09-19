using System;
using AppKit;
using CoreGraphics;
using Foundation;

namespace QuickLayout.Mac.Views
{
    public class FlippedView : NSView
    {
        public FlippedView()
        {
        }

        public FlippedView(NSCoder coder) : base(coder)
        {
        }

        public FlippedView(CGRect frameRect) : base(frameRect)
        {
        }

        protected FlippedView(NSObjectFlag t) : base(t)
        {
        }

        protected internal FlippedView(IntPtr handle) : base(handle)
        {
        }

        public override bool IsFlipped => true;
    }
}
