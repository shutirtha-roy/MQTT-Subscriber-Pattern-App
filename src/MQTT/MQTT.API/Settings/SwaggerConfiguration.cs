namespace MQTT.API.Settings;

public static class SwaggerConfiguration
{
    public static WebApplicationBuilder AddSwagger(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen();

        return builder;
    }
}