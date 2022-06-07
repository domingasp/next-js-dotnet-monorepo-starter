using API.Data;
using API.Models;
using MediatR;

namespace API.Features.Products.Create;

public record CreateProductCommand(CreateProductDTO DTO) : IRequest<int>;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly APIContext _apiContext;

    public CreateProductHandler(APIContext apiContext)
    {
        _apiContext = apiContext;
    }

    public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = MapDTOToProduct(request.DTO);

        await _apiContext.Products.AddAsync(product, cancellationToken);
        await _apiContext.SaveChangesAsync(cancellationToken);
        return product.Id;
    }

    private static Product MapDTOToProduct(CreateProductDTO DTO)
    {
        return new Product { Name = DTO.Name };
    }
}