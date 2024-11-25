using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CA_CatalogService.Application.Products.Queries.GetProducts;
using CA_CatalogService.Domain.Entities;

namespace CA_CatalogService.Application.Products.Queries.ListProducts;
public class ProductShortInfoDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Product, ProductShortInfoDTO>();
        }
    }
}
