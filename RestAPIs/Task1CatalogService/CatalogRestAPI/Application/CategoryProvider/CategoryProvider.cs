using Domain.Entities;
using Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CategoryProvider
{
    public class CategoryProvider
    {
        private readonly IMapper _mapper;
        private ICategoryRepository _categoryRepository;
        public CategoryProvider(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllAsync()
        {
            var list = await _categoryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(list);
        }
    }
}
