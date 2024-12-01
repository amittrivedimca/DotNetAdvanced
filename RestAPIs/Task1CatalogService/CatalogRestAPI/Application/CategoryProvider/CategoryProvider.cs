using Domain.Entities;
using Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CategoryProvider
{
    public class CategoryProvider : ICategoryProvider
    {
        private readonly IMapper _mapper;
        private ICategoryRepository _categoryRepository;

        public CategoryProvider(IMapper mapper, IRepositoryManager repositoryManager)
        {
            _mapper = mapper;
            _categoryRepository = repositoryManager.CategoryRepository;
        }

        public IEnumerable<CategoryDTO> GetAll()
        {
            var list = _categoryRepository.GetAll();            
            return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(list);
        }
    }
}
