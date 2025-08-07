using DelegateApp;
public class Program
{
    private static void Main(string[] args)
    {
        TemperatureAlert temperatureAlert = new TemperatureAlert();
        TemperatureMonitor temperatureMonitor = new TemperatureMonitor();
        CoolingAlert cooldownAlert = new CoolingAlert();
        temperatureMonitor.TemperatureChanged += temperatureAlert.OnTemperatureChanged!;
        temperatureMonitor.TemperatureChanged += cooldownAlert.OnTemperatureChanged!;
        while (true)
        {
            temperatureMonitor.Temperature = int.Parse(Console.ReadLine()!);
        }
        //Stock stock = new Stock();
        //StockAlert stockAlert =new StockAlert();

        //stock.OnStockPriceChanged += stockAlert.OnStockPriceChanged;
        //stock.Threshold = 120;
        //Console.WriteLine("120");
        //stock.Price = 120;
        //Console.WriteLine("140");
        //stock.Price = 140;
        //Console.WriteLine("99");
        //stock.Price = 99;
        //Console.WriteLine("130");
        //stock.Price = 130;



    }

    static void InvokeSafely(LogHandler logHandler, string message)
    {
        LogHandler tempHandler = logHandler;
        if (tempHandler != null)
        {
            tempHandler(message);
        }
    }

    static void MultiDelegateExample()
    {
        Logger logger = new Logger();
        LogHandler logHandler = logger.LogToConsole;
        logHandler += logger.LogToFile;
        logHandler("Logging Multitask delegate");

        foreach (LogHandler handler in logHandler.GetInvocationList())
        {
            try
            {
                handler("Event occured with error handling");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }
        }

        logHandler -= logger.LogToFile;

        InvokeSafely(logHandler, "After removing File Logger");
    }

    public static void SortingCall()
    {
        Person[] people = {
        new Person{Name="John",Age=25},
        new Person{Name="Bob",Age=26},
        new Person{Name="Duke",Age=36},
        new Person{Name="Alice",Age=30},


        };
        PersonSorter sorter = new PersonSorter();
        sorter.Sort(people, PersonSorter.CompareByName);
        foreach (Person person in people)
        {
            Console.WriteLine($"{person.Name}, {person.Age}");
        }
    }
}

