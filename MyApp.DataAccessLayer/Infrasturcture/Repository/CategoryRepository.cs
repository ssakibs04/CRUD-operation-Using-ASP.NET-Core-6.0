using MyApp.DataAccessLayer.Infrasturcture.IRepository;
using MyApp.Models;
using MyAppWeb.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.DataAccessLayer.Infrasturcture.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository

    {
        private ApplicationDBContext _context;
        public CategoryRepository(ApplicationDBContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Category category)
        {
            _context.categories.Update(category);
        }
    }
}
