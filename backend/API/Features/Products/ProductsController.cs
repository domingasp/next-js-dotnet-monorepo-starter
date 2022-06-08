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
    public async Task<IActionResult> GetAll()
    {
        var products = await _mediator.Send(new GetAllProductsQuery());

        return Ok(products);
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> Create(CreateProductDto Dto)
    {
        var createdId = await _mediator.Send(new CreateProductCommand(Dto));

        return Ok(createdId);
    }

    [HttpDelete]
    [Route("delete")]
    public async Task<IActionResult> Delete(int Id)
    {
        var deleted = await _mediator.Send(new DeleteProductCommand(Id));
        if (!deleted)
        {
            return NotFound();
        }

        return Ok();
    }
}