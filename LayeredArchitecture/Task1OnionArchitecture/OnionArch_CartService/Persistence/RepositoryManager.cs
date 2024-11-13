using Domain.RepositoryInterfaces;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<ICartRepository> lazyCartRepository = new Lazy<ICartRepository>();

        public RepositoryManager()
        {
            lazyCartRepository = new Lazy<ICartRepository>(() => new CartRepository());
        }

        public ICartRepository CartRepository => lazyCartRepository.Value;
    }
}
