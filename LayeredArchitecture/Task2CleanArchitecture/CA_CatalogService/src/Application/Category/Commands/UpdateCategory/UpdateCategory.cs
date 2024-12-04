using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CA_CatalogService.Application.Category.Queries.GetCategories;
using CA_CatalogService.Domain.Entities;

namespace CA_CatalogService.Application.Category.Commands.UpdateCategory;
public record UpdateCategoryCommand : IRequest
{
    public int Id { get; set; }
    [StringLength(50)]
    [Required]
    public string Name { get; set; } = string.Empty;    
}

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Categories
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Name = request.Name;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
