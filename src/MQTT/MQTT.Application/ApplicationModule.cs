using Autofac;
using MQTT.Application.Services;

namespace MQTT.Application;

public class ApplicationModule : Module
{
    private readonly string _migrationAssemblyName;

	public ApplicationModule(string migrationAssemblyName)
	{
        _migrationAssemblyName = migrationAssemblyName;
    }

    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<MQTTConnectionService>()
            .As<IMQTTConnectionService>()
            .InstancePerLifetimeScope();

        base.Load(builder);
    }
}