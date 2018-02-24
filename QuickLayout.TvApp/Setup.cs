using System;
using MvvmCross.Binding.Bindings.Target.Construction;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using MvvmCross.tvOS.Platform;
using QuickLayout.TvApp.Bindings;
using UIKit;

namespace QuickLayout.TvApp
{
    public class Setup : MvxTvosSetup
    {
        public Setup(MvxApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
        {
        }

        protected override IMvxApplication CreateApp() => new Core.App();

        protected override IMvxTrace CreateDebugTrace() => new DebugTrace();

        protected override void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
        {
            base.FillTargetFactories(registry);

            registry.RegisterFactory(new MvxCustomBindingFactory<UIButton>("PrimaryActionTriggered", button => new TvOSButtonBinding(button)));

        }
    }
}
