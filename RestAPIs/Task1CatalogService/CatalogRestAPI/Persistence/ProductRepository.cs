using Domain.RepositoryInterfaces;
using Persistence.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class ProductRepository : IProductRepository
    {
        private readonly CatalogDB _catalogDB;
        public ProductRepository(CatalogDB catalogDB)
        {
            _catalogDB = catalogDB;
        }
    }
}
