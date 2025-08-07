
namespace DelegateApp;

// Using the Generic Delegate EventHandler<TEventArgs>


//public delegate void TemperatureChangeHandler(string message);

public class TemperatureChangedEventArgs : EventArgs
{
    public int Temperature { get; }
    public TemperatureChangedEventArgs(int temperature)
    {
        Temperature = temperature;
    }
}

public class TemperatureMonitor
{
    //public event TemperatureChangeHandler? OnTemperatureChanged;

    public event EventHandler<TemperatureChangedEventArgs>? TemperatureChanged;

    private int _temperature;

    public int Temperature
    {
        get { return _temperature; }
        set
        {
            if (_temperature !=value)
            {
                _temperature = value;
                OnTemperatureChanged(new TemperatureChangedEventArgs(_temperature));
            }
        }
    }

    protected virtual void OnTemperatureChanged(TemperatureChangedEventArgs e)
    {
        TemperatureChanged?.Invoke(this,e);
    }
}

public class TemperatureAlert
{
    public void OnTemperatureChanged(object sender,TemperatureChangedEventArgs e)
    {
        Console.WriteLine($"Alert - temperature is {e.Temperature} sent by {sender}");
    }
}

public class CoolingAlert
{
    public void OnTemperatureChanged(object sender, TemperatureChangedEventArgs e)
    {
        Console.WriteLine($"Temp Cooling Alert - temperature is {e.Temperature} sent by {sender}");
    }
}