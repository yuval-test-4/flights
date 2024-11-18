using Flights.APIs;
using Flights.APIs.Common;
using Flights.APIs.Dtos;
using Flights.APIs.Errors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Flights.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class FlightsControllerBase : ControllerBase
{
    protected readonly IFlightsService _service;

    public FlightsControllerBase(IFlightsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one flight
    /// </summary>
    [HttpPost()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<Flight>> CreateFlight(FlightCreateInput input)
    {
        var flight = await _service.CreateFlight(input);

        return CreatedAtAction(nameof(Flight), new { id = flight.Id }, flight);
    }

    /// <summary>
    /// Delete one flight
    /// </summary>
    [HttpDelete("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> DeleteFlight([FromRoute()] FlightWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteFlight(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many flights
    /// </summary>
    [HttpGet()]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<List<Flight>>> Flights([FromQuery()] FlightFindManyArgs filter)
    {
        return Ok(await _service.Flights(filter));
    }

    /// <summary>
    /// Meta data about flight records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> FlightsMeta(
        [FromQuery()] FlightFindManyArgs filter
    )
    {
        return Ok(await _service.FlightsMeta(filter));
    }

    /// <summary>
    /// Get one flight
    /// </summary>
    [HttpGet("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult<Flight>> Flight([FromRoute()] FlightWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Flight(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one flight
    /// </summary>
    [HttpPatch("{Id}")]
    [Authorize(Roles = "user")]
    public async Task<ActionResult> UpdateFlight(
        [FromRoute()] FlightWhereUniqueInput uniqueId,
        [FromQuery()] FlightUpdateInput flightUpdateDto
    )
    {
        try
        {
            await _service.UpdateFlight(uniqueId, flightUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
