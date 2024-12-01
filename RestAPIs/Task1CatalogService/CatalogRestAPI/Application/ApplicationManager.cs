using AppCategoryProvider = Application.CategoryProvider;
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
        private readonly IMapper _mapper;
        private ICategoryRepository _categoryRepository;
        private readonly Lazy<AppCategoryProvider.ICategoryProvider> lazyCategoryProvider = new Lazy<AppCategoryProvider.ICategoryProvider>();

        public ApplicationManager(IMapper mapper, IRepositoryManager repositoryManager)
        {
            _mapper = mapper;
            _categoryRepository = repositoryManager.CategoryRepository;
            lazyCategoryProvider = new Lazy<AppCategoryProvider.ICategoryProvider>(() => new AppCategoryProvider.CategoryProvider(mapper, repositoryManager));
        }

        public AppCategoryProvider.ICategoryProvider CategoryProvider => lazyCategoryProvider.Value;
    }
}
