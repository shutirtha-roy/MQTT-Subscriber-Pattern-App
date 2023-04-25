using MQTTnet.Client;

namespace MQTT.Application.Data;

public sealed class SubscriberList : ISubscriberList
{
    public IDictionary<string, IList<IMqttClient>> SubscriberItems { get; private set; }

	public SubscriberList()
	{
		if(SubscriberItems is null)
            SubscriberItems = new Dictionary<string, IList<IMqttClient>>();
	}

	public async Task AddSubscriber(string topic, IMqttClient client)
	{
        if(!SubscriberItems.ContainsKey(topic))
		{
            SubscriberItems.Add(topic, new List<IMqttClient>());
		}

        SubscriberItems[topic].Add(client);
    }

	public async Task RemoveSubscriber(string topic, IMqttClient client)
	{
        if (!SubscriberItems.ContainsKey(topic))
        {
			throw new KeyNotFoundException("Subscriber Not found");	
        }

        SubscriberItems[topic].Remove(client);
    }
}