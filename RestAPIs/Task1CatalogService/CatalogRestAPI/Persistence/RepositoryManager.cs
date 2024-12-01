using Domain.RepositoryInterfaces;
using Persistence.DB;
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

        public RepositoryManager(CatalogDB catalogDB)
        {
            lazyCategoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(catalogDB));
        }

        public ICategoryRepository CategoryRepository => lazyCategoryRepository.Value;
    }
}
