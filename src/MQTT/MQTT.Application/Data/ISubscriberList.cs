using MQTTnet.Client;

namespace MQTT.Application.Data;

public interface ISubscriberList
{
    Task AddSubscriber(string topic, IMqttClient client);
    Task RemoveSubscriber(string topic, IMqttClient client);
}