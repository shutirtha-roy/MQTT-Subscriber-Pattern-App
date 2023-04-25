using MQTTnet.Client;
using MQTTnet.Protocol;
using MQTTnet;
using MQTT.Application.Data;

namespace MQTT.Application.Services;

public class PublisherService : IPublisherService
{
    private readonly IMQTTConnectionService _mqttConnectionService;
    private readonly IMqttClient? _mqttClient;
    private readonly IPublisherList _publisherList;

    public PublisherService(IMQTTConnectionService mqttConnectionService, IPublisherList publisherList)
    {
        _mqttConnectionService = mqttConnectionService;
        _mqttClient = _mqttConnectionService.IsConnected().Result;
        _publisherList = publisherList;
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

        await _publisherList.AddPublisher(topic: topic, client: _mqttClient);

        return message;
    }

    public async Task DisconnectPublisher(string topic)
    {
        await _publisherList.RemovePublisher(topic: topic, client: _mqttClient);
    }
}