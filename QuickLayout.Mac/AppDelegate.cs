using Foundation;
using MvvmCross.Platforms.Mac.Core;
using QuickLayout.Core;

namespace QuickLayout.Mac
{
    [Register("AppDelegate")]
    public class AppDelegate : MvxApplicationDelegate<MvxMacSetup<App>, App>
    {
    }
}
