using AutoMapper;
using eshopWebAPI.Dto.Product;
using eshopWebAPI.Interfaces;
using eshopWebAPI.Models;
using eshopWebAPI.Repositories;
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
        [ProducesResponseType(200, Type = typeof(IEnumerable<ProductDto>))]
        public async Task<IActionResult> GetProducts()
        {
            var products = _mapper.Map<List<ProductDto>>(await _productRepository.GetAllAsync());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(products);
        }


        [HttpGet("productId")]
        [ProducesResponseType(200, Type = typeof(ProductDto))]
        [ProducesResponseType(400, Type = typeof(ProductDto))]
        [ProducesResponseType(404, Type = typeof(ProductDto))]
        public async Task<IActionResult> GetProductById(string productId)
        {
            if (!await _productRepository.Exists(productId))
            {
                return NotFound();
            }
            var product = _mapper.Map<ProductDto>(await _productRepository.GetAsync(productId));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(product);
        }


        //Admin Create Product
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(CreateProductDto))]
        [ProducesResponseType(400, Type = typeof(CreateProductDto))]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto createProduct)
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
            await _productRepository.AddAsync(productMap);

            return NoContent();
        }
        //Admin Update Product
        [HttpPut("productId")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateProduct( string productId, [FromBody] UpdateProductDto updatedProduct)
        {
            if (updatedProduct == null)
            {
                return BadRequest(ModelState);
            }

            if (productId != updatedProduct.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await _productRepository.Exists(productId))
            {
                return NotFound();
            }
            var user = await _productRepository.GetAsync(productId);
            if (user == null)
            {
                return NotFound();
            }
            _mapper.Map(updatedProduct, user);
            await _productRepository.UpdateAsync(user);

            return NoContent();
        }

        //Admin Delete Product
        [HttpDelete("productId")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteProduct(string productId)
        {
            if (!await _productRepository.Exists(productId))
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _productRepository.DeleteAsync(productId);
            return NoContent();
        }

    }
}
