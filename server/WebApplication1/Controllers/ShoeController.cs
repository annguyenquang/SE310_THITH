using Microsoft.AspNetCore.Mvc;
using WebApplication1.Core.Entities;
using WebApplication1.Model;
using WebApplication1.Service;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ShoeController(IShoeService _shoeService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllShoe()
        {
            return Ok(await _shoeService.GetAllShoeAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetShoeById(Guid id)
        {
            return Ok(await _shoeService.GetShoeById(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateShoe([FromBody] CreateShoe shoe)
        {
            return Ok(await _shoeService.CreateShoe(shoe));
        }
        [HttpPost]
        public async Task<IActionResult> UpdateShoe([FromBody] Shoe shoe)
        {
            return Ok(await _shoeService.UpdateShoe(shoe));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShoe(Guid id)
        {
            return Ok(await _shoeService.DeleteShoe(id)); 
        }
    }
}
