using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MVC.Core;

public class FakeDbSet<TEntity> : IQueryable<TEntity>, IEnumerable<TEntity>, IEnumerable, IQueryable, IListSource where TEntity : class
{
    public Type ElementType => throw new NotImplementedException();

    public Expression Expression => throw new NotImplementedException();

    public IQueryProvider Provider => throw new NotImplementedException();

    public bool ContainsListCollection => throw new NotImplementedException();

    public IEnumerator<TEntity> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    public IList GetList()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}
