using AutoMapper;
using eshopWebAPI.Contracts;
using eshopWebAPI.Data.Dto.Order;
using eshopWebAPI.Dto.Product;
using eshopWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eshopWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IMapper _mapper;

        public OrderController(IOrdersRepository ordersRepository, IMapper mapper)
        {
            _ordersRepository = ordersRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<OrderDto>))]
        public async Task<IActionResult> GetOrders()
        {
            var orders = _mapper.Map<List<OrderDto>>(await _ordersRepository.GetAllAsync());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(orders);
        }


        [HttpGet("orderId")]
        [ProducesResponseType(200, Type = typeof(ProductDto))]
        [ProducesResponseType(400, Type = typeof(ProductDto))]
        [ProducesResponseType(404, Type = typeof(ProductDto))]
        public async Task<IActionResult> GetOrderById(string orderId)
        {
            if (!await _ordersRepository.Exists(orderId))
            {
                return NotFound();
            }
            var order = _mapper.Map<OrderDto>(await _ordersRepository.GetAsync(orderId));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(order);
        }


        
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(CreateOrderDto))]
        [ProducesResponseType(400, Type = typeof(CreateOrderDto))]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto createOrder)
        {
            if (createOrder == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var order = _mapper.Map<Order>(createOrder);
            await _ordersRepository.AddAsync(order);

            return NoContent();
        }
     
        [HttpPut("orderId")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateOrder(string orderId, [FromBody] UpdateOrderDto updateOrderDto)
        {
            if (updateOrderDto == null)
            {
                return BadRequest(ModelState);
            }

            if (orderId != updateOrderDto.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await _ordersRepository.Exists(orderId))
            {
                return NotFound();
            }
            var order = await _ordersRepository.GetAsync(orderId);
            if (order == null)
            {
                return NotFound();
            }
            _mapper.Map(updateOrderDto, order);
            await _ordersRepository.UpdateAsync(order);

            return NoContent();
        }

      
        [HttpDelete("orderId")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteOrder(string orderId)
        {
            if (!await _ordersRepository.Exists(orderId))
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _ordersRepository.DeleteAsync(orderId);
            return NoContent();
        }
    }
}
