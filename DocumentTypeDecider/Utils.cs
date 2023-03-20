using DocumentTypeDecider.SearchHandler;
using Microsoft.Extensions.DependencyInjection;

namespace DocumentTypeDecider;
public class Utils
{
    private static ServiceProvider? _serviceProvider;
    public static void InitializeComponents()
    {
        ServiceCollection services = new ServiceCollection();
        services.AddSingleton<IFuzzySearchHandler, FuzzySearchHandler>();
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

