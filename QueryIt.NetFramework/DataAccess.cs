
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

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(
        //        @"Server=PF0S793ASUNKUM\\MSSQLSERVER17;Database=PeopleDB;User Id=sa;Password=Admin123;
        //        Trusted_Connection=True;MultipleActiveResultSets=true;");
        //}
    }
    public interface IRepository<T> : IDisposable
    {
        void Add(T newEntity);
        void Delete(T entity);
        T FindById(int id);
        IQueryable<T> FindAll();
        int Commit();
    }

    public class SqlRepository<T> : IRepository<T> where T : class
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
            _set.Add(newEntity);
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
