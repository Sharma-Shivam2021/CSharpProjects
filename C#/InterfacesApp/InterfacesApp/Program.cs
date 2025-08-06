/*
 * Decoupling: The Application class depends on the 
 * ILogger interface rather than specific implementations
 * like FileLogger or DatabasLogger.
 * This means you ca easily switch the logging mechanism without changing
 * the Application class  
 */

//public interface ILogger
//{
//    void Log(string message);
//}

//public class FileLogger : ILogger
//{
//    public void Log(string message)
//    {
//        // @ sign is used to denote a verbatim string literally
//        string directoryPath = @"C:\Logs";
//        string filePath = System.IO.Path.Combine(directoryPath, "log.txt");
//        if (!Directory.Exists(directoryPath))
//        {
//            Directory.CreateDirectory(directoryPath);
//        }

//        File.AppendAllText(filePath, message + "\n");
//    }
//}

//public class DatabaseLogger : ILogger
//{
//    public void Log(string msg)
//    {
//        // Implement the logic to log a messsage to a database
//        Console.WriteLine($"Logging to databse: {msg}");
//    }
//}


//public class Application
//{
//    private readonly ILogger _logger;

//    public Application(ILogger logger)
//    {
//        _logger = logger;
//    }

//    public void DoWork()
//    {
//        _logger.Log("Work Started");
//        // Do the work
//        _logger.Log("Work completed");
//    }
//}

//using static System.Net.Mime.MediaTypeNames;

//ILogger fileLogger = new FileLogger();
//Application app = new Application(fileLogger);
//app.DoWork();

//ILogger dbLogger = new DatabaseLogger();
//app = new Application(dbLogger);
//app.DoWork();

using System.Drawing;

internal class Program
{

    static void Main(string[] args)
    {
        MultiFunctionPrinter printer = new MultiFunctionPrinter();
        printer.Print();
        printer.Scan();
    }
}

public interface IPrintable
{
    void Print();
}

public interface IScannable
{
    void Scan();
}

public class MultiFunctionPrinter : IPrintable, IScannable
{
    public void Print()
    {
        Console.WriteLine("Printing Document");
        //throw new NotImplementedException();
    }

    public void Scan()
    {
        Console.WriteLine("Scanning Document");
        //throw new NotImplementedException();
    }
}