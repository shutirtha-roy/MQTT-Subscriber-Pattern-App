using MQTTnet.Client;

namespace MQTT.Application.Data;

public interface ISubscriberList
{
    IDictionary<string, IList<IMqttClient>> SubscriberItems { get; }
    Task AddSubscriber(string topic, IMqttClient client);
    Task RemoveSubscriber(string topic, IMqttClient client);
}