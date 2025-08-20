using Application.Test;
using Data;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Test;
public class FlightApplicationSpecification
{
    readonly Entities entities = new(
            new DbContextOptionsBuilder<Entities>().UseInMemoryDatabase("Flights").Options
            );

    readonly BookingService bookingService;

    public FlightApplicationSpecification()
    {
        bookingService = new(entities: entities);
        
    }

    [Theory]
    [InlineData("m@m.com", 2)]
    [InlineData("a@a.com", 2)]
    public void Remembers_booking(string email, int numberOfSeats)
    {
        Flight flight = new(3);
        entities.Flights.Add(flight);
        BookingServiceBookMethod(flight.Id, email, numberOfSeats);

        Assert.Contains(new BookingRm(email, numberOfSeats), bookingService.FindBookings(flight.Id));
    }


    [Theory]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(10)]
    public void Frees_up_seats_after_booking(int initialCapacity)
    {
        Flight flight = new(initialCapacity);
        entities.Flights.Add(flight);

        BookingServiceBookMethod(flight.Id, "m@m.com", 2);
        bookingService.CancelBooking(
            new CancelBookingDTO(
                flightId: flight.Id,
                pasengerEmail: "m@m.com",
                numberOfSeats: 2
                )
            );
        Assert.Equal(initialCapacity, bookingService.GetRemainingNumberOfSeatsFor(flight.Id));
    }

    private void BookingServiceBookMethod(Guid flightId, string passengerEmail, int numberOfSeats)
    {
        bookingService.Book(
            new BookDTO(
                flightId: flightId,
                passengerEmail: passengerEmail,
                numberOfSeats: numberOfSeats
                )
            );
    }
}

