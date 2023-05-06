namespace ApiPlayground.P01.DependencyInjection.Services;

public class ConsoleMessage
    : IMessage
{
    private readonly ITime _time;

    public ConsoleMessage(ITime time)
    {
        _time = time;
    }

    public void Send(string message)
    {
        Console.WriteLine($"[{_time.Now:HH:mm:ss}]: {message}");
    }
}
