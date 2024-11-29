using Domain.Entities;
using Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class CategoryRepository : ICategoryRepository
    {
        public Task<IEnumerable<Category>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
