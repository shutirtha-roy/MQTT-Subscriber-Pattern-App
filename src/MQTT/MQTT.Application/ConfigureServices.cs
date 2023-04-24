using Microsoft.Extensions.DependencyInjection;

namespace MQTT.Application;
public static class ConfigureServices
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services;
    }
}