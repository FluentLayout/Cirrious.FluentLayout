using UIKit;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.Platform.Platform;

namespace QuickLayout.Touch
{
	public class Setup : MvxIosSetup
	{
		public Setup(MvxApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
		{
		}

		protected override IMvxApplication CreateApp() => new Core.App();
		
        protected override IMvxTrace CreateDebugTrace() => new DebugTrace();
	}
}