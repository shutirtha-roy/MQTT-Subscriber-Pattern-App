using Autofac;
using Autofac.Extensions.DependencyInjection;
using MQTT.Application;
using System.Reflection;

namespace MQTT.API.Settings;

public static class AutofacConfiguration
{
    public static WebApplicationBuilder AddAutofac(this WebApplicationBuilder builder)
    {
        var assemblyName = Assembly.GetExecutingAssembly().FullName;

        builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

        builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
        {
            containerBuilder.RegisterModule(new ApiModule());
            containerBuilder.RegisterModule(new ApplicationModule(assemblyName));
        });

        return builder;
    }
}