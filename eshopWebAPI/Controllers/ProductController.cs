﻿using AutoMapper;
using eshopWebAPI.Dto;
using eshopWebAPI.Interfaces;
using eshopWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace eshopWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
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
                return BadRequest();
            }

            return Ok(products);
        }


        [HttpGet("productId")]
        [ProducesResponseType(200, Type = typeof(Product))]
        [ProducesResponseType(400)]
        public IActionResult GetProductById(int productId)
        {
            if (!_productRepository.ProductExists(productId))
            {
                return NotFound();
            }

            var product = _mapper.Map<ProductDto>(_productRepository.GetProductById(productId));
            /*if (!ModelState.IsValid)
            {
                return BadRequest();
            }*/
            return Ok(product);
        }

        [HttpPost]
        [ProducesResponseType(201)]
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
                ModelState.AddModelError("","Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully Created a Product");
        }
    }
}
