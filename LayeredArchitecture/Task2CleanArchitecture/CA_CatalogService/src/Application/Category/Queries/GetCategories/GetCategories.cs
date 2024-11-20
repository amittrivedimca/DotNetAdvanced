using CA_CatalogService.Application.Common.Mappings;

namespace CA_CatalogService.Application.Category.Queries.GetCategories;

public record GetCategoriesQuery : IRequest<IList<CategoryDTO>>
{
    //public int Id { get; init; }
    //public int PageNumber { get; init; } = 1;
    //public int PageSize { get; init; } = 10;
}

public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, IList<CategoryDTO>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCategoriesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IList<CategoryDTO>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var list = (_context.Categories
            .OrderBy(x => x.Name));
        var data = list.ToList();
        var list2 = await list.ProjectToListAsync<CategoryDTO>(_mapper.ConfigurationProvider);
        return list2;
    }
}

