using API.Data;
using API.Models;
using FluentValidation;
using MediatR;

namespace API.Features.Products.Create;

public record CreateProductCommand(CreateProductDto Dto) : IRequest<int>;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly APIContext _apiContext;

    public CreateProductHandler(APIContext apiContext)
    {
        _apiContext = apiContext;
    }

    public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = MapDTOToProduct(request.Dto);

        await _apiContext.Products.AddAsync(product, cancellationToken);
        await _apiContext.SaveChangesAsync(cancellationToken);
        return product.Id;
    }

    private static Product MapDTOToProduct(CreateProductDto Dto)
    {
        return new Product { Name = Dto.Name };
    }
}

public class Validator : AbstractValidator<CreateProductDto>
{
    public Validator()
    {
        RuleFor(x => x.Name).NotNull().MaximumLength(50).Matches(@"^\S+$");
    }
}