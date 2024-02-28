using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System.Text;

internal class Main
{
    private readonly ILogger<Main> _logger;
    private readonly IConfiguration _config;

    public Main(ILogger<Main> logger, IConfiguration config)
    {
        _logger = logger;
        _config = config;
    }
    public void Send(string text)
    {
        var message = _config.Bind<Settings>("Bunny").Message;
        _logger.LogInformation(message, text);

        var factory = new ConnectionFactory { HostName = "localhost" };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        channel.QueueDeclare(queue: "hello", durable: false, exclusive: false, autoDelete: false, arguments: null);

        var body = Encoding.UTF8.GetBytes(text);

        channel.BasicPublish(exchange: string.Empty, routingKey: "hello", basicProperties: null, body: body);

        _logger.LogInformation("The message sent successfully.");
    }

    public void Receive()
    {

    }
}
