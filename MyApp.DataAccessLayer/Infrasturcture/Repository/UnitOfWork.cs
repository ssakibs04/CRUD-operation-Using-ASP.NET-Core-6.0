using MyApp.DataAccessLayer.Infrasturcture.IRepository;
using MyAppWeb.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.DataAccessLayer.Infrasturcture.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDBContext _context;
        public ICategoryRepository Category { get; private set; }
        public UnitOfWork(ApplicationDBContext context) 
        {
            _context = context;
            Category = new CategoryRepository(context);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
