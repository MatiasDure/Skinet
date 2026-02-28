using API.Products.Requests;
using Application.Products;
using Application.Products.Commands.CreateProduct;
using Application.Products.Commands.DeleteProduct;
using Application.Products.Commands.UpdateProduct;
using Application.Products.Queries.GetProduct;
using Application.Products.Queries.ListProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Products
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductDto>>> GetProducts()
        {
            var products = await _mediator.Send(new ListProductsQuery());
            return Ok(products);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            var product = await _mediator.Send(new GetProductQuery(id));

            if(product == null) return NotFound();
            
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> CreateProduct(CreateProductCommand command)
        {
            var product = await _mediator.Send(command);
            return Created($"api/products/{product.Id}", product);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ProductDto>> UpdateProduct(int id, UpdateProductRequest request)
        {
            var product = await _mediator.Send(new UpdateProductCommand(
                id, 
                request.Name, 
                request.Description, 
                request.Price, 
                request.PictureUrl, 
                request.Type, 
                request.Brand, 
                request.QuantityInStock
            ));

            if(product == null) return NotFound();

            return Ok(product);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            await _mediator.Send(new DeleteProductCommand(id));
            return NoContent();
        }
    }
}
