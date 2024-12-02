using Application.CategoryAL;
using Domain.RepositoryInterfaces;

namespace Application
{
    public class ApplicationManager : IApplicationManager
    {
        private readonly IMapper _mapper;
        private ICategoryRepository _categoryRepository;
        private readonly Lazy<ICategoryProvider> lazyCategoryProvider = new Lazy<ICategoryProvider>();

        public ApplicationManager(IMapper mapper, IRepositoryManager repositoryManager)
        {
            _mapper = mapper;
            _categoryRepository = repositoryManager.CategoryRepository;
            lazyCategoryProvider = new Lazy<ICategoryProvider>(() => new CategoryProvider(mapper, repositoryManager));
        }

        public ICategoryProvider CategoryProvider => lazyCategoryProvider.Value;
    }
}
