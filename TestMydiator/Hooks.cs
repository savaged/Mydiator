using Microsoft.Extensions.DependencyInjection;
using Mydiator;
using TestMydiator.DataAccess;

namespace TestMydiator;

[TestClass]
public class Hooks
{
    internal static ServiceProvider? ServiceProvider { get; private set; }

    [AssemblyInitialize]
    public static void AssemblyInitialize(TestContext _)
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddSingleton<IDataService, DataService>();
        serviceCollection.AddMydiator(typeof(MydiatorEntryPoint).Assembly);
        ServiceProvider = serviceCollection.BuildServiceProvider();
    }

    [AssemblyCleanup]
    public static void AssemblyCleanup() => ServiceProvider?.Dispose();
}
