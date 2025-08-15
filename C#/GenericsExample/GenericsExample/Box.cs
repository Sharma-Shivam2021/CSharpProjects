namespace GenericsExample;

internal class Box<T>
{
    public T Content { get; set; }

    public string Log()
    {
        return $"Box contains: {Content}";
    }
}
