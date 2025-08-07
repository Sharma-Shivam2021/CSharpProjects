

namespace DelegateApp;

public delegate void StockPriceChangedHandler(string message);
public class Stock
{
    public event StockPriceChangedHandler? OnStockPriceChanged;

    private decimal _price;
    private decimal _threshold;

    public decimal Price
    {
        get => _price;
        set
        {
            _price = value;
            if (_price < _threshold)
            {
                RaiseStockPriceChangedEvent("Stock price is below threshold!");
            }
        }
    }

    public decimal Threshold { get => _threshold; set => _threshold = value; }
    protected virtual void RaiseStockPriceChangedEvent(string message)
    {
        OnStockPriceChanged?.Invoke(message);
    }
}

public class StockAlert
{
    public void OnStockPriceChanged(string message)
    {
        Console.WriteLine("Stock Alert: " + message);
    }
}

