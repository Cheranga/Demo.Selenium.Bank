using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Demo.Selenium.Bank;

public class TestInitializer : IClassFixture<TestInitializer>
{
    public TestInitializer()
    {
        var host = Host.CreateDefaultBuilder()
            .ConfigureServices(
                (context, services) =>
                {
                    var apiSettings = context.Configuration
                        .GetSection(nameof(ApiSettings))
                        .Get<ApiSettings>();
                    services.AddSingleton(apiSettings!);
                }
            )
            .ConfigureAppConfiguration(builder =>
            {
                builder
                    .AddUserSecrets(typeof(TestInitializer).Assembly)
                    .AddJsonFile("appsettings.json", false)
                    .AddEnvironmentVariables();
            })
            .Build();

        ServiceProvider = host.Services;
    }

    public IServiceProvider ServiceProvider { get; }
}

[CollectionDefinition(Name)]
public class TestCollection : ICollectionFixture<TestInitializer>
{
    public const string Name = nameof(TestCollection);
}
