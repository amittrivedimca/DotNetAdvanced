using Application.CartAL;
using AutoMapper;
using Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class ApplicationManager : IApplicationManager
    {
        private readonly Lazy<ICartProvider> _lazyCartService;

        public ApplicationManager(IMapper mapper, IRepositoryManager repositoryManager)
        {
            _lazyCartService = new Lazy<ICartProvider>(() => new CartProvider(mapper, repositoryManager));
        }

        public ICartProvider CartService
        {
            get
            {
                return _lazyCartService.Value;
            }
        }
    }
}
