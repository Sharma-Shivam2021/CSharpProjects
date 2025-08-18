using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsExample;

internal interface IEntity
{
    int Id { get; }
}

//internal class Repository<T> where T : IEntity
//{
//    private readonly List<T> values = [];

//    public void Add(T entity)
//    {
//        values.Add(entity);
//    }
//}
