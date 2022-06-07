using API.Data;
using API.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API.Features.Products;

public record GetProductsQuery() : IRequest<IEnumerable<Product>>;

public class GetProductsHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
{
    private readonly APIContext _apiContext;

    public GetProductsHandler(APIContext apiContext)
    {
        _apiContext = apiContext;
    }

    public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        return await _apiContext.Products.ToListAsync();
    }
}

