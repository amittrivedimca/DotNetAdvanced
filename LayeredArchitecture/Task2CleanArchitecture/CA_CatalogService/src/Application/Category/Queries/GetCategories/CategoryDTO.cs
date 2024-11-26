using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CA_CatalogService.Domain.Entities;

namespace CA_CatalogService.Application.Category.Queries.GetCategories;

public class CategoryDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Image { get; set; }
    public CategoryDTO? ParentCategory { get; private set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<ItemCategory, CategoryDTO>();
        }
    }
}
