namespace Application;
public class BookDTO
{
    public Guid FlightId { get; set; }
    public string PassengerEmail { get; set; }

    public int NumberOfSeats { get; set; }

    public BookDTO(Guid flightId, string passengerEmail, int numberOfSeats)
    {
        FlightId = flightId;
        PassengerEmail = passengerEmail;
        NumberOfSeats = numberOfSeats;
    }
}
