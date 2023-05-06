using ApiPlayground.P01.DependencyInjection.Services;

internal class MyApp
{
    private readonly IMessage _message;

    public MyApp(IMessage message)
    {
        _message = message;
    }

    public void Run()
    {
        _message.Send("This is my app!");
    }
}
