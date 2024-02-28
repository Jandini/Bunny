using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

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
    }

    public void Receive()
    {

    }

}
