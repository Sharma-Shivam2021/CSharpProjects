using Domain;

namespace FlightTest;

public class FlightSpecifications
{
    [Theory]
    [InlineData(3, 1, 2)]
    [InlineData(6, 1, 5)]
    [InlineData(10, 4, 6)]
    public void Booking_reduces_the_number_of_the_seats(int seatCapacity, int numberOfSeatsBook, int remainingNumberOfSeats)
    {
        var flight = new Flight(seatCapacity: seatCapacity);

        flight.Book("test@test.com", numberOfSeatsBook);

        Assert.Equal(remainingNumberOfSeats, flight.RemainingNumberOfSeats);
    }

    [Fact]
    public void Avoids_overbooking()
    {
        var flight = new Flight(seatCapacity: 3);

        var error = flight.Book("test", 4);

        Assert.IsType<OverbookingError>(error);
    }

    [Fact]
    public void Book_flight_successfully()
    {
        var flight = new Flight(seatCapacity: 3);
        var error = flight.Book("test", 1);

        Assert.Null(error);
    }

    [Fact]
    public void Remembers_bookings()
    {
        var flight = new Flight(seatCapacity: 150);
        flight.Book("a@b.com", numberOfSeats: 4);

        Assert.Contains(new Booking(email: "a@b.com", numberOfSeats: 4), flight.BookingList);
    }



    [Theory]
    [InlineData(3, 1, 1, 3)]
    [InlineData(4, 1, 1, 4)]
    [InlineData(7, 5, 4, 6)]
    public void Canceling_bookings_frees_up_the_seats(
        int initialCapacity,
        int numberOfSeatsToBook,
        int numberOfSeatsToCancel,
        int remainingNumberOfSeats
        )
    {
        var flight = new Flight(initialCapacity);
        flight.Book(passengerEmail: "a@b.com", numberOfSeats: numberOfSeatsToBook);

        flight.CancelBooking(passengerEmail: "a@b.com", numberOfSeats: numberOfSeatsToCancel);

        Assert.Equal(remainingNumberOfSeats, flight.RemainingNumberOfSeats);
    }

    [Fact]
    public void Doesnt_cancel_bookings_for_passengers_who_have_not_booked()
    {
        var flight = new Flight(3);
        var error = flight.CancelBooking(passengerEmail: "a@b.com", numberOfSeats: 2);

        Assert.IsType<BookingNotFoundError>(error);
    }

    [Fact]
    public void Returns_null_when_successfully_cancels_a_booking()
    {
        var flight = new Flight(3);
        flight.Book(passengerEmail: "a@b.com", numberOfSeats: 1);
        var error = flight.CancelBooking(passengerEmail: "a@b.com", numberOfSeats: 2);

        Assert.Null(error);
    }

    [Theory]
    [InlineData(3, 1, 1,false)]
    [InlineData(4, 1, 1,false)]
    [InlineData(7, 5, 4,true)]
    public void Removes_booking_from_the_booking_list(
         int initialCapacity,
       int numberOfSeatsToBook,
       int numberOfSeatsToCancel,
       bool shouldRemain
        )
    {
        var flight = new Flight(initialCapacity);
        flight.Book(passengerEmail: "a@b.com", numberOfSeats: numberOfSeatsToBook);
        flight.CancelBooking(passengerEmail: "a@b.com", numberOfSeats: numberOfSeatsToCancel);
        var remainingBooking = flight.BookingList.FirstOrDefault(b => b.Email == "a@b.com");

        if (shouldRemain)
        {
            Assert.NotNull(remainingBooking);
            Assert.Equal(numberOfSeatsToBook - numberOfSeatsToCancel, remainingBooking.NumberOfSeats);
        }
        else
        {
            Assert.DoesNotContain(new Booking(email: "a@b.com", 1), flight.BookingList);
        }
       
    }

}