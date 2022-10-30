using Microsoft.Extensions.Logging;
using MvvmCross.Platforms.Ios.Core;
using QuickLayout.Core;
using Serilog;
using Serilog.Extensions.Logging;

namespace QuickLayout.Touch;

public class Setup : MvxIosSetup<App>
{
    protected override ILoggerProvider CreateLogProvider()
    {
        return new SerilogLoggerProvider();
    }

    protected override ILoggerFactory CreateLogFactory()
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Async(l => l.NSLog())
            .WriteTo.Async(a => a.Trace())
            .CreateLogger();

        return new SerilogLoggerFactory();
    }
}