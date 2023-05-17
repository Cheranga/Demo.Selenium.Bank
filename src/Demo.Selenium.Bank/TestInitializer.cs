using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Xunit.Abstractions;

namespace Demo.Selenium.Bank;

public class TestInitializer : IClassFixture<TestInitializer>
{
    public IServiceProvider ServiceProvider { get; }
    public TestInitializer()
    {
        var host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                var apiSettings = context.Configuration.GetSection(nameof(ApiSettings)).Get<ApiSettings>();
                services.AddSingleton(apiSettings!);
            })
            .ConfigureAppConfiguration(builder =>
            {
                builder.AddJsonFile("appsettings.json", false);
                builder.AddEnvironmentVariables();
            })
            .Build();
        
        ServiceProvider = host.Services;
        
    }
}

[CollectionDefinition(Name)]
public class TestCollection : ICollectionFixture<TestInitializer>
{
    public const string Name = nameof(TestCollection);
}