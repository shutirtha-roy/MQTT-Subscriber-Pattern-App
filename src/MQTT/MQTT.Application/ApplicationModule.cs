using Autofac;

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
        base.Load(builder);
    }
}