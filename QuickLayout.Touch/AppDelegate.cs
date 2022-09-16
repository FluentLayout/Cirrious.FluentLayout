using Foundation;
using MvvmCross.Platforms.Ios.Core;

namespace QuickLayout.Touch
{
    [Register("AppDelegate")]
    public class AppDelegate : MvxApplicationDelegate<MvxIosSetup<Core.App>, Core.App>
    {
    }
}