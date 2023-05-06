namespace ApiPlayground.P01.DependencyInjection.Services;

public class SystemTime
    : ITime
{
    public DateTime Now => DateTime.Now;
}
