using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CA_CatalogService.Application.Category.Queries.GetCategories;
using CA_CatalogService.Domain.Entities;

namespace CA_CatalogService.Application.Category.Commands.CreateCategory;
public record CreateCategoryCommand : IRequest<int>
{
    [StringLength(50)]
    [Required]
    public string Name { get; set; } = string.Empty;
    public string? Image { get; set; }
    public CategoryDTO? ParentCategory { get; private set; }
}

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = new ItemCategory()
        {
            Name = request.Name,
            Image = request.Image,            
        };       

        if(request.ParentCategory != null)
        {
            entity.ParentCategory = new ItemCategory()
            {
                Id = request.ParentCategory.Id,
                Name = request.ParentCategory.Name,
                Image = request.ParentCategory.Image
            };
        }

        _context.Categories.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
