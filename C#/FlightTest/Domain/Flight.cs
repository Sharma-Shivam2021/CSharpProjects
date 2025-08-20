
namespace Domain;

public class Flight
{
    List<Booking> bookingList = new();
    public IEnumerable<Booking> BookingList => bookingList;

    public Guid Id { get; }
    public int RemainingNumberOfSeats { get; set; }

    [Obsolete("Needed by EF")]
    public Flight()
    {

    }

    public Flight(int seatCapacity)
    {
        RemainingNumberOfSeats = seatCapacity;
    }

    public object? Book(string passengerEmail, int numberOfSeats)
    {
        if (numberOfSeats > RemainingNumberOfSeats)
        {
            return new OverbookingError();
        }
        else
        {
            RemainingNumberOfSeats -= numberOfSeats;
            bookingList.Add(new Booking(passengerEmail, numberOfSeats));
            return null;
        }
    }

    public object? CancelBooking(string passengerEmail, int numberOfSeats)
    {
        var booking = bookingList.FirstOrDefault(b => b.Email == passengerEmail);

        if (booking is null)
        {
            return new BookingNotFoundError();
        }

        if (numberOfSeats >= booking.NumberOfSeats)
        {
            bookingList.Remove(booking);
        }
        else
        {
            booking.NumberOfSeats -= numberOfSeats;
        }

        RemainingNumberOfSeats += numberOfSeats;
        return null;
    }
}
