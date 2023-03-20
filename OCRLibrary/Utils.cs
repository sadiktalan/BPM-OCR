using Microsoft.Extensions.DependencyInjection;
using OCRLibrary.TesseractHandler;

namespace OCRLibrary;
public static class Utils
{
    private static ServiceProvider? _serviceProvider;
    public static void InitializeComponents()
    {
        ServiceCollection services = new ServiceCollection();
        services.AddSingleton<ITesseractBuilder, TesseractBuilder>();
        services.AddLogging();

        _serviceProvider = services.BuildServiceProvider();
    }


    public static ServiceProvider? GetServiceProvider()
    {
        if (_serviceProvider == null)
        {
            InitializeComponents();
        }
        return _serviceProvider;
    }
}

