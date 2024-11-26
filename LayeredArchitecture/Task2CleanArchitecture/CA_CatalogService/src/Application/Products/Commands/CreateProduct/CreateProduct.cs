using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CA_CatalogService.Domain.Entities;

namespace CA_CatalogService.Application.Products.Commands.CreateProduct;
public record CreateProductCommand : IRequest<int>
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? Image { get; set; }
    public int CategoryId { get; set; }
     
    public decimal Price { get; set; }
    public int Amount { get; set; }
}

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateProductCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var entity = new Product()
        {
            Name = request.Name,
            Description = request.Description,
            Image = request.Image,
            CategoryId = request.CategoryId,
            Price = request.Price,
            Amount = request.Amount,
        };                

        _context.Products.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
