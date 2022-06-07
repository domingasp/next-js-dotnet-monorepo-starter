using API.Features.Products.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Features.Products;

[Route("api/products")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly ISender _mediator;

    public ProductsController(ISender mediator) => _mediator = mediator;

    [HttpGet]
    [Route("getall")]
    public async Task<ActionResult> GetAll()
    {
        var products = await _mediator.Send(new GetAllProductsQuery());

        return Ok(products);
    }

    [HttpPost]
    [Route("create")]
    public async Task<ActionResult> Create(CreateProductDTO DTO)
    {
        var createdId = await _mediator.Send(new CreateProductCommand(DTO));

        return Ok(createdId);
    }
}