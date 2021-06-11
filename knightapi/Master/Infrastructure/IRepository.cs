using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Master.Infrastructure
{
    public interface IRepository<T> where T : class, new()
    {
        IEnumerable<T> GetAll();
        T Get(Expression<Func<T, bool>> expression);
        IQueryable<T> GetMany(Expression<Func<T, bool>> expression);
        void Insert(T obj);
        void Update(T obj);
        void Remove(T obj);
        int Count();
        void Save();
    }
}
