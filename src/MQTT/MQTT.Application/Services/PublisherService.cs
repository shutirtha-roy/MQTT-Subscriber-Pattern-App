using MQTTnet.Client;
using MQTTnet.Protocol;
using MQTTnet;

namespace MQTT.Application.Services;

public class PublisherService : IPublisherService
{
    private readonly IMQTTConnectionService _mqttConnectionService;
    private readonly IMqttClient? _mqttClient;

    public PublisherService(IMQTTConnectionService mqttConnectionService)
    {
        _mqttConnectionService = mqttConnectionService;
        _mqttClient = _mqttConnectionService.IsConnected().Result;
    }

    public async Task<string> PublishMessage(string topic, string message)
    {
        var applicationMessage = new MqttApplicationMessageBuilder()
            .WithTopic(topic)
            .WithPayload(message)
            .WithQualityOfServiceLevel(MqttQualityOfServiceLevel.AtLeastOnce)
            .Build();

        if (_mqttClient.IsConnected)
        {
            await _mqttClient.PublishAsync(applicationMessage);
            return $"Published Message {message}";
        }

        return "Unable to publish message";
    }

    public async Task<string> StartPublisher(string topic, string payLoad)
    {
        if (_mqttClient is null)
        {
            throw new Exception("Publisher Not Found");
        }

        var message = await PublishMessage(topic, payLoad);

        return message;
    }
}