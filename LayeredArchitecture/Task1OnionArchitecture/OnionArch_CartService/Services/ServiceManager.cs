using Domain.RepositoryInterfaces;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICartService> _lazyCartService;

        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _lazyCartService = new Lazy<ICartService>(() => new CartService(repositoryManager));
        }

        public ICartService CartService
        {
            get
            {
                return _lazyCartService.Value;
            }
        }
    }
}
