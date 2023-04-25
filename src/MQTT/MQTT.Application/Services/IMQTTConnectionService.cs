using MQTTnet.Client;

namespace MQTT.Application.Services;

public interface IMQTTConnectionService
{
    Task<IMqttClient> IsConnected();
}