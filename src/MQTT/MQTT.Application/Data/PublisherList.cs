using MQTTnet.Client;

namespace MQTT.Application.Data;

public sealed class PublisherList : IPublisherList
{
    public IDictionary<string, IList<IMqttClient>> PublisherItems { get; private set; }

    public PublisherList()
    {
        if (PublisherItems is null)
            PublisherItems = new Dictionary<string, IList<IMqttClient>>();
    }

    public async Task AddPublisher(string topic, IMqttClient client)
    {
        if (!PublisherItems.ContainsKey(topic))
        {
            PublisherItems.Add(topic, new List<IMqttClient>());
        }

        PublisherItems[topic].Add(client);
    }

    public async Task RemovePublisher(string topic, IMqttClient client)
    {
        if (!PublisherItems.ContainsKey(topic))
        {
            throw new KeyNotFoundException("Publisher Not found");
        }

        PublisherItems[topic].Remove(client);
    }
}