using API.Data;
using API.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Features.Products;

public record GetAllProductsQuery() : IRequest<IEnumerable<Product>>;

public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
{
    private readonly APIContext _apiContext;

    public GetAllProductsHandler(APIContext apiContext)
    {
        _apiContext = apiContext;
    }

    public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        return await _apiContext.Products.ToListAsync();
    }
}

