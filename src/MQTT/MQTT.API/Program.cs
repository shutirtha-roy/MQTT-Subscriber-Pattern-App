using MQTT.API.Settings;
using MQTT.Application;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder
    .AddAutofac()
    .AddSerilog()
    .AddApi()
    .AddSwagger();

builder.Services
    .AddApplication();

try
{
    var app = builder.Build();

    Log.Logger.Information("Application Starting-up");

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception e)
{
    Log.Fatal(e, "Application Staring-up Failed.");
}
finally
{
    Log.CloseAndFlush();
}