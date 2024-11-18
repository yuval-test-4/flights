using Microsoft.AspNetCore.Mvc;

namespace Flights.APIs;

[ApiController()]
public class FlightsController : FlightsControllerBase
{
    public FlightsController(IFlightsService service)
        : base(service) { }
}
