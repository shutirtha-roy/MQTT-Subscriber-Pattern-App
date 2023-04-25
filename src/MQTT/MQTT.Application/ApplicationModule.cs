using Autofac;
using MQTT.Application.Data;
using MQTT.Application.DTOs;
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

        builder.RegisterType<PublisherList>()
            .As<IPublisherList>()
            .SingleInstance();

        builder.RegisterType<SubscriberList>()
            .As<ISubscriberList>()
            .SingleInstance();

        builder.RegisterType<PublisherDto>()
            .AsSelf();

        builder.RegisterType<SubscriberDto>()
            .AsSelf();

        builder.RegisterType<APIResponse>()
            .AsSelf();

        base.Load(builder);
    }
}