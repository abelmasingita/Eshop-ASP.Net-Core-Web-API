using AutoMapper;
using eshopWebAPI.Dto;
using eshopWebAPI.Interfaces;
using eshopWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace eshopWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Product>))]
        public IActionResult GetProducts()
        {
            var products = _mapper.Map<List<ProductDto>>(_productRepository.GetProducts());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(products);
        }


        [HttpGet("productId")]
        [ProducesResponseType(200, Type = typeof(Product))]
        [ProducesResponseType(400, Type = typeof(Product))]
        [ProducesResponseType(404, Type = typeof(Product))]
        public IActionResult GetProductById(int productId)
        {
            if (!_productRepository.ProductExists(productId))
            {
                return NotFound();
            }

            var product = _mapper.Map<ProductDto>(_productRepository.GetProductById(productId));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(product);
        }


        //Admin Create Product
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult CreateProduct([FromBody] ProductDto createProduct)
        {
            if (createProduct == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productMap = _mapper.Map<Product>(createProduct);

            if (!_productRepository.ProductCreate(productMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully Created a Product");
        }


        //Admin Update Product
        [HttpPut("productId")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateProduct( int productId, [FromBody] ProductDto updatedProduct)
        {

            if(updatedProduct == null)
            {
                return BadRequest(ModelState);
            }
           /* if(productId != updatedProduct.Id)
            {
                return BadRequest(ModelState);
            }*/


            if (!_productRepository.ProductExists(productId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productMap = _mapper.Map<Product>(updatedProduct);
            if (!_productRepository.ProductUpdate(productMap))
            {
                ModelState.AddModelError("", "Something went wrong while Updating the Product");
                return StatusCode(500,ModelState);
            }
            return NoContent();
        }

        //Admin Delete Product
        [HttpDelete("productId")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteProduct(int productId)
        {

            if (!_productRepository.ProductExists(productId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productDelete = _productRepository.GetProductById(productId);
            if (!_productRepository.ProductDelete(productDelete))
            {
                ModelState.AddModelError("", "Something went wrong while Deleting the Product");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

    }
}
