using MQTTnet.Client;

namespace MQTT.Application.Data;

public interface IPublisherList
{
    IDictionary<string, IList<IMqttClient>> PublisherItems { get; }
    Task AddPublisher(string topic, IMqttClient client);
    Task RemovePublisher(string topic, IMqttClient client);
}