namespace GenericsExample;
internal interface IRepository<T>
{
    void Add(T entity);
    void Delete(T entity);
}

internal class Product
{
    public int Id { get; }
    public string ProductName { get; set; } = "";
}

internal class Repository<T> : IRepository<T>
{
    public void Add(T entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(T entity)
    {
        throw new NotImplementedException();
    }
}
