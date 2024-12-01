using Domain.Entities;
using Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CatalogDB _catalogDB;
        public CategoryRepository(CatalogDB catalogDB) {
            _catalogDB = catalogDB;
        }

        public IEnumerable<Category> GetAll()
        {
            return _catalogDB.Categories;
        }
    }
}
