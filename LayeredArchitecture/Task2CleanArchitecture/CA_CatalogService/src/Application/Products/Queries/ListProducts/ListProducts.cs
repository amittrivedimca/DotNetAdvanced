using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CA_CatalogService.Application.Common.Mappings;
using CA_CatalogService.Application.Products.Queries.GetProducts;

namespace CA_CatalogService.Application.Products.Queries.ListProducts;

public record ListProductsQuery : IRequest<IList<ProductShortInfoDTO>>
{   
    public string? Name { get; set; }
}

public class ListProductQueryHandler : IRequestHandler<ListProductsQuery, IList<ProductShortInfoDTO>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public ListProductQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IList<ProductShortInfoDTO>> Handle(ListProductsQuery request, CancellationToken cancellationToken)
    {
        var list = (_context.Products
            .Where(p => string.IsNullOrEmpty(request.Name) || p.Name.Contains(request.Name))
            .OrderBy(x => x.Name));
        //var data = list.ToList();
        var list2 = await list.ProjectToListAsync<ProductShortInfoDTO>(_mapper.ConfigurationProvider);
        return list2;
    }
}
