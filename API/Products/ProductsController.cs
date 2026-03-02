using API.Products.Mappers;
using API.Products.Requests;
using API.Products.Requests.Create;
using Application.Products;
using Application.Products.Commands.CreateProduct;
using Application.Products.Commands.DeleteProduct;
using Application.Products.Commands.UpdateProduct;
using Application.Products.Queries.GetBrands;
using Application.Products.Queries.GetProduct;
using Application.Products.Queries.GetTypes;
using Application.Products.Queries.ListProducts;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Products
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductDto>>> GetProducts(
            [FromQuery] ProductParamsRequest param)
        {
            var products = await _mediator.Send(new ListProductsQuery(ProductSpecParamsMapper.ToParams(param)));
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
        public async Task<ActionResult<ProductDto>> CreateProduct(
            CreateProductRequest request,
            IValidator<CreateProductRequest> validator
        )
        {
            var validationResult = await validator.ValidateAsync(request); 
            if (!validationResult.IsValid)
            {
                // TODO: Find a better cleaner approach for this and remove this from the controller
                var problemDetails = new HttpValidationProblemDetails(validationResult.ToDictionary())
                {
                    Status = StatusCodes.Status400BadRequest,
                    Title = "Validation failed",
                    Detail = "One or more validation errors occured.",
                    Instance = "/api/products"
                };

                return new ObjectResult(problemDetails) { StatusCode = StatusCodes.Status400BadRequest };
            }
            
            var product = await _mediator.Send(new CreateProductCommand(
                request.Name, 
                request.Description, 
                request.Price, 
                request.PictureUrl, 
                request.Type, 
                request.Brand, 
                request.QuantityInStock
            ));
            return CreatedAtAction($"GetProduct", new { id = product.Id}, product);
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

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<string>>> GetBrands()
        {
            var brands = await _mediator.Send(new GetBrandsQuery());
            return Ok(brands);
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<string>>> GetTypes()
        {
            var types = await _mediator.Send(new GetTypesQuery()); 
            return Ok(types);
        }
    }
}
