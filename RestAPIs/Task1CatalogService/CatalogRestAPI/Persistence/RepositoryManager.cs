using Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<ICategoryRepository> lazyCategoryRepository = new Lazy<ICategoryRepository>();

        public RepositoryManager()
        {
            lazyCategoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository());
        }

        public ICategoryRepository CategoryRepository => lazyCategoryRepository.Value;
    }
}
