namespace MQTT.Application.Services;

public interface IPublisherService
{
    Task<string> PublishMessage(string topic, string message);
    Task<string> StartPublisher(string topic, string payLoad);
}