using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations;

namespace CA_CatalogService.Application.Products.Commands.UpdateProduct;
public record UpdateProductCommand : IRequest<int>
{
    public int Id { get; set; }

    [StringLength(50)]
    [Required]
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? Image { get; set; }
    public int CategoryId { get; set; }
     
    public decimal Price { get; set; }
    public int Amount { get; set; }
}

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, int>
{
    private readonly IApplicationDbContext _context;

    public UpdateProductCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Products
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Name = request.Name;
        entity.Description = request.Description;
        entity.Image = request.Image;
        entity.CategoryId = request.CategoryId;
        entity.Price = request.Price;
        entity.Amount = request.Amount;

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
