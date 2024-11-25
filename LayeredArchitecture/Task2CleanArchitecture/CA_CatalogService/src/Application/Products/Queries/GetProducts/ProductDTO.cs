using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CA_CatalogService.Application.Category.Queries.GetCategories;
using CA_CatalogService.Domain.Entities;

namespace CA_CatalogService.Application.Products.Queries.GetProducts;
public class ProductDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? Image { get; set; }
    public int CategoryId { get; set; }
    //public CategoryDTO Category { get; set; } = new CategoryDTO();
    public decimal Price { get; set; }
    public int Amount { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Product, ProductDTO>();
        }
    }
}
