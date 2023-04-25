using MQTTnet;
using MQTTnet.Client;

namespace MQTT.Application.Services;

public sealed class MQTTConnectionService : IMQTTConnectionService
{
    public async Task<IMqttClient?> IsConnected()
    {
        var mqttClient = new MqttFactory()
            .CreateMqttClient();

        var mqttClientOptions = new MqttClientOptionsBuilder()
                .WithTcpServer("localhost", 1883)
                .WithCleanSession(false)
                .Build();

        try
        {
            var response = await mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None);
            return mqttClient;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }
}