
public struct Event
{
    public DateTime StartDate;
    public DateTime EndDate;

    public Event(DateTime startDate, DateTime endDate)
    {
        StartDate = startDate;
        EndDate = endDate;
    }

    public double GetDuration()
    {
        return EndDate.Subtract(StartDate).Days;
    }

   public bool IsOverlapping(Event otherEvent)
    {
        return this.StartDate <= otherEvent.EndDate && otherEvent.StartDate <= this.EndDate;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        DateTime startDate1 = new DateTime(2024, 07 , 01);
        DateTime endDate1 = new DateTime(2024 , 07 , 10);
        Event myEvent1= new Event(startDate1, endDate1);
        DateTime startDate2 = new DateTime(2024, 07, 05);
        DateTime endDate2 = new DateTime(2024, 07, 15);
        Event myEvent2= new Event(startDate2, endDate2);

        Console.WriteLine("Event 1 Duration: {0} days",myEvent1.GetDuration());
        Console.WriteLine("Event 2 Duration: {0} days",myEvent2.GetDuration());

        Console.WriteLine("Events Overlap: {0}",myEvent1.IsOverlapping(myEvent2));
       
    }
}