namespace Wbx.Simple.RabbitMq.Producer;

public interface IRabbitMqService
{
	void SendMessage(object obj);
	void SendMessage(string message);
}
