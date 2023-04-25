using MQTTnet.Client;

namespace MQTT.Application.Data;

public sealed class SubscriberList : ISubscriberList
{
    private readonly IDictionary<string, IList<IMqttClient>> _subscriberItems;

	public SubscriberList()
	{
		if(_subscriberItems is null)
			_subscriberItems = new Dictionary<string, IList<IMqttClient>>();
	}

	public async Task AddSubscriber(string topic, IMqttClient client)
	{
        if(!_subscriberItems.ContainsKey(topic))
		{
			_subscriberItems.Add(topic, new List<IMqttClient>());
		}

		_subscriberItems[topic].Add(client);
    }

	public async Task RemoveSubscriber(string topic, IMqttClient client)
	{
        if (!_subscriberItems.ContainsKey(topic))
        {
			throw new KeyNotFoundException("Subscriber Not found");	
        }

        _subscriberItems[topic].Remove(client);
    }
}