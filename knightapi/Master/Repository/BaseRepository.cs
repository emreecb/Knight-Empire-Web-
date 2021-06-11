using Master.Infrastructure;
using Master.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Master.Repository
{
    public class BaseRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, new()

    {

        private readonly MasterContext _context;

        public BaseRepository(MasterContext context)
        {
            _context = context;
        }

        public int Count()
        {
            return _context.Set<TEntity>().Count();
        }

        public void Remove(TEntity entity)
        {
            if (entity != null)
            {
                var deleted = _context.Entry(entity);
                deleted.State = EntityState.Deleted;
                Save();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> expression)
        {
            return _context.Set<TEntity>().FirstOrDefault(expression);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().Select(x => x);
        }

        public IQueryable<TEntity> GetMany(Expression<Func<TEntity, bool>> expression)
        {
            return _context.Set<TEntity>().Where(expression);
        }

        public void Insert(TEntity obj)
        {
            _context.Set<TEntity>().Add(obj);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            _context.Set<TEntity>().Update(obj);
            Save();
        }
    }
}
