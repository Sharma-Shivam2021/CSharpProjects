// 1.  Declaration
namespace DelegateApp;

public delegate void Notify(string message);

public delegate void LogHandler(string message);

public class Logger
{
    public void LogToConsole(string message)
    {
        Console.WriteLine("Console Log: " + message);
    }

    public void LogToFile(string message)
    {
        string directoryPath = @"C:\Logs";
        string filePath = Path.Combine(directoryPath, "log.txt");
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }
        File.AppendAllText(filePath, message);
        Console.WriteLine("Logged in file");
    }
    static void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }

    static void BubbleSort(int[] arr)
    {
        int n = arr.Length;
        bool swapped;

        for (int i = 0; i < n - 1; i++)
        {
            swapped = false;
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    swap(ref arr[j], ref arr[j + 1]);
                    swapped = true;
                }
            }
            if (!swapped)
            {
                break;
            }
        }
    }

    private static void swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }
}

