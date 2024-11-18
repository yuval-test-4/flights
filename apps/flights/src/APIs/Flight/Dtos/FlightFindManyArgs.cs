using Flights.APIs.Common;
using Flights.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace Flights.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class FlightFindManyArgs : FindManyInput<Flight, FlightWhereInput> { }
