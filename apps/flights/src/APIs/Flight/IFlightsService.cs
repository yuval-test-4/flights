using Flights.APIs.Common;
using Flights.APIs.Dtos;

namespace Flights.APIs;

public interface IFlightsService
{
    /// <summary>
    /// Create one flight
    /// </summary>
    public Task<Flight> CreateFlight(FlightCreateInput flight);

    /// <summary>
    /// Delete one flight
    /// </summary>
    public Task DeleteFlight(FlightWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many flights
    /// </summary>
    public Task<List<Flight>> Flights(FlightFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about flight records
    /// </summary>
    public Task<MetadataDto> FlightsMeta(FlightFindManyArgs findManyArgs);

    /// <summary>
    /// Get one flight
    /// </summary>
    public Task<Flight> Flight(FlightWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one flight
    /// </summary>
    public Task UpdateFlight(FlightWhereUniqueInput uniqueId, FlightUpdateInput updateDto);
}
