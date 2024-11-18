using Flights.APIs.Dtos;
using Flights.Infrastructure.Models;

namespace Flights.APIs.Extensions;

public static class FlightsExtensions
{
    public static Flight ToDto(this FlightDbModel model)
    {
        return new Flight
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static FlightDbModel ToModel(
        this FlightUpdateInput updateDto,
        FlightWhereUniqueInput uniqueId
    )
    {
        var flight = new FlightDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            flight.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            flight.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return flight;
    }
}
