
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace QueryIt
{
    public class EmployeeDb : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
    }
    // Covariance - out T
    public interface IReadonlyRepository<out T> : IDisposable
    {
        T FindById(int id);
        IQueryable<T> FindAll();
    }
    // Contravariance - in T
    public interface IWriteOnlyRepository<in T> : IDisposable
    {
        void Add(T newEntity);
        void Delete(T entity);
        int Commit();
    }
    public interface IRepository<T> : IReadonlyRepository<T>, IWriteOnlyRepository<T>, IDisposable
    {

    }

    public class SqlRepository<T> : IRepository<T> where T : class, IEntity
    {
        DbContext _context;
        DbSet<T> _set;
        public SqlRepository(DbContext ctx)
        {
            _context = ctx;
            _set = _context.Set<T>();
        }

        public void Add(T newEntity)
        {
            if (newEntity.IsValid())
            {
                _set.Add(newEntity);
            }
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _set.Remove(entity);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IQueryable<T> FindAll()
        {
            return _set;
        }

        public T FindById(int id)
        {
            return _set.Find(id);
        }
    }
}
