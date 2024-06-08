using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

var connFactory = new ConnectionFactory();
var exchangeName = "exchange1";
string queueName = "queue1";
string routingKey = "key1";
connFactory.HostName = "localhost";
connFactory.DispatchConsumersAsync = true;
var connection = connFactory.CreateConnection();

using var channel = connection.CreateModel();

channel.ExchangeDeclare(exchangeName, "direct");
channel.QueueDeclare(queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
channel.QueueBind(queue: queueName, exchange: exchangeName, routingKey: routingKey);

var consumer = new AsyncEventingBasicConsumer(channel);

consumer.Received += ConsumerReceived;
channel.BasicConsume(queueName, false, consumer);
Console.ReadLine();
async Task ConsumerReceived(object sender, BasicDeliverEventArgs args)
{
  try
  {
    var bytes = args.Body.ToArray();
    string msg = Encoding.UTF8.GetString(bytes);
    Console.WriteLine($"[{DateTime.Now}] Received Message: {msg}");
    channel.BasicAck(args.DeliveryTag, multiple: false);
    await Task.Delay(800);
  }
  catch (Exception ex)
  {
    channel.BasicReject(args.DeliveryTag, true);
    Console.WriteLine(ex);
  }

}