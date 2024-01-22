using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Storage.Repositories;

namespace Storage.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductRepository _productRepository;

        public ProductController(
            ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsWithPartAndCell()
        {
            var query = await _productRepository.GetProductsWithPartAndCell();
            return Ok(query);
        }
    }
}