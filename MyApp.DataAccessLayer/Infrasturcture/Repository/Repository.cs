using Microsoft.EntityFrameworkCore;
using MyApp.DataAccessLayer.Infrasturcture.IRepository;
using MyAppWeb.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.DataAccessLayer.Infrasturcture.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDBContext _Context;
        private DbSet<T> _dbSet;
        public Repository(ApplicationDBContext dbContext)
        {
            _Context = _Context;
            _dbSet = _Context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }
        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }
        public void DeleteRange(IEnumerable<T> entity)
        {
            _dbSet.RemoveRange(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetT(Expression<Func<T, bool>> Predicate)
        {
            return _dbSet.Where(Predicate).FirstOrDefault();



        }
    }
}
