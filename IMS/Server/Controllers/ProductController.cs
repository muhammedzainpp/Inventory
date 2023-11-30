using IMS.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }
        [HttpGet("ByName")]
        public async Task<IActionResult> GetInventoryByName(string name = "")
        {
            var result = await _productRepository.GetProductByname(name);
            return Ok(result);
        }
    }
}
