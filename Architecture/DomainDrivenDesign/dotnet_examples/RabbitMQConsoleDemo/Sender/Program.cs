using System.Text;
using RabbitMQ.Client;

var connFactory = new ConnectionFactory();
var exchangeName = "exchange1";
connFactory.HostName = "localhost";
connFactory.DispatchConsumersAsync = true;
var connection = connFactory.CreateConnection();
while (true)
{
  using var channel = connection.CreateModel();
  var props = channel.CreateBasicProperties();
  props.DeliveryMode = 2; //Non-persistent (1) or persistent (2).
  channel.ExchangeDeclare(exchangeName, "direct");

  byte[] bytes = Encoding.UTF8.GetBytes(DateTime.Now.ToString());
  channel.BasicPublish(exchangeName, routingKey: "key1", mandatory: true, basicProperties: props, body: bytes);
  Thread.Sleep(1000);
}