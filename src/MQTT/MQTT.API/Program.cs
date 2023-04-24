using MQTT.API.Settings;
using MQTT.Application;

var builder = WebApplication.CreateBuilder(args);

builder
    .AddSerilog()
    .AddApi()
    .AddSwagger();

builder.Services
    .AddApplication();

var app = builder.Build();

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
