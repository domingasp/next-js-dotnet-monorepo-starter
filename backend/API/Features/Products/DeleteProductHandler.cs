using API.Data;
using MediatR;

namespace API.Features.Products;

public record DeleteProductCommand(int Id) : IRequest<bool>;

public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
{
    private readonly APIContext _apiContext;

    public DeleteProductHandler(APIContext apiContext)
    {
        _apiContext = apiContext;
    }

    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _apiContext.Products.FindAsync(new object[] { request.Id }, cancellationToken);

        if (product != null)
        {
            _apiContext.Products.Remove(product);
            await _apiContext.SaveChangesAsync(cancellationToken);

            return true;
        }

        return false;
    }
}