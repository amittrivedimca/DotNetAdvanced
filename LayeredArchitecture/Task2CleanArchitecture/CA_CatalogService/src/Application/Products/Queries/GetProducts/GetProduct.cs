using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CA_CatalogService.Application.Common.Mappings;

namespace CA_CatalogService.Application.Products.Queries.GetProducts;
public record GetProductQuery : IRequest<ProductDTO>
{
    public int Id { get; init; }
    //public int PageNumber { get; init; } = 1;
    //public int PageSize { get; init; } = 10;
}

public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductDTO>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetProductQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ProductDTO> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var list = (_context.Products
            .Where( p => p.Id == request.Id)
            .OrderBy(x => x.Name));
        //var data = list.ToList();
        var list2 = await list.ProjectToListAsync<ProductDTO>(_mapper.ConfigurationProvider);
        return list2.First();
    }
}
