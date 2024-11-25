using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CA_CatalogService.Application.Category.Queries.GetCategories;

namespace CA_CatalogService.Application.Products.Queries.GetProducts;
public class ProductDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? Image { get; set; }
    public CategoryDTO Category { get; set; } = new CategoryDTO();
    public decimal Price { get; set; }
    public Int64 Amount { get; set; }
}
