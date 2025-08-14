using Microsoft.Extensions.Configuration;
using System.IO;
using System.Windows;


namespace CurrencyConverter_Static
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IConfiguration? Configuration { get; private set; }
        public App()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("E:\\C# Apps\\C#\\CurrencyConverter_Static\\CurrencyConverter_Static\\appsettings.json", optional: false, reloadOnChange: true);
            Configuration = builder.Build();

            AppDomain.CurrentDomain.SetData("DataDirectory",
                Path.Combine(Directory.GetCurrentDirectory(),
                "Database"));
        }
    }
}
