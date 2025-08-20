using Data;

namespace Application;

public class BookingService
{
    public Entities Entities { get; set; }

    public BookingService(Entities entities)
    {
        Entities = entities;
    }

    public void Book(BookDTO bookDTO)
    {
        var flight = Entities.Flights.Find(bookDTO.FlightId);
        flight!.Book(bookDTO.PassengerEmail, bookDTO.NumberOfSeats);
        Entities.SaveChanges();
    }

    public IEnumerable<BookingRm> FindBookings(Guid flightId)
    {
        return Entities.Flights.Find(flightId)!.BookingList.Select(static b => new BookingRm(b.Email!, b.NumberOfSeats));
    }

    public void CancelBooking(CancelBookingDTO cancelBookingDTO)
    {
        var flight = Entities.Flights.Find(cancelBookingDTO.FlightId);
        flight!.CancelBooking(cancelBookingDTO.PasengerEmail, cancelBookingDTO.NumberOfSeats);
        Entities.SaveChanges();
    }

    public object GetRemainingNumberOfSeatsFor(Guid flightId)
    {
        return Entities.Flights.Find(flightId)!.RemainingNumberOfSeats;
    }
}
