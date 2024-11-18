using Flights.APIs;

namespace Flights;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add services to the container.
    /// </summary>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IFlightsService, FlightsService>();
    }
}
