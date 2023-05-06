using ApiPlayground.P01.DependencyInjection.Services;
using Microsoft.Extensions.DependencyInjection;

// DI service setup
var serviceCollection = new ServiceCollection()
    .AddSingleton<MyApp>()
    .AddSingleton<IMessage, ConsoleMessage>()
    .AddSingleton<ITime, SystemTime>();

// DI create container
IServiceProvider serviceProvider = serviceCollection
    .BuildServiceProvider();

// Request MyApp from DI container, and run it
var app = serviceProvider.GetRequiredService<MyApp>();
app.Run();
