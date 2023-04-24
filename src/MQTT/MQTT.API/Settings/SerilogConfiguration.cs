using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using Serilog;

namespace MQTT.API.Settings;

public static class SerilogConfiguration
{
    public static WebApplicationBuilder AddSerilog(this WebApplicationBuilder builder)
    {
        builder.Host.UseSerilog((ctx, lc) => lc
            .MinimumLevel.Debug()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            .Enrich.FromLogContext()
            .ReadFrom.Configuration(builder.Configuration)
        );

        return builder;
    }
}