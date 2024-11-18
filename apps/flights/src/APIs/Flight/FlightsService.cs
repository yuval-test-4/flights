using Flights.Infrastructure;

namespace Flights.APIs;

public class FlightsService : FlightsServiceBase
{
    public FlightsService(FlightsDbContext context)
        : base(context) { }
}
