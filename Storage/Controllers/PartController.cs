using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Storage.Repositories;

namespace Storage.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PartController : ControllerBase
    {
        private readonly PartRepository _partRepository;

        public PartController(
            PartRepository partRepository)
        {
            _partRepository = partRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetInfoByBarcodeAsync([FromQuery] string barcode)
        {
            var query = await _partRepository.GetInfoByBarcodeAsync(barcode);
            return Ok(query);
        }
    }
}