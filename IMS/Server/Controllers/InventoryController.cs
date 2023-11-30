using Domain;
using IMS.Application.Repositories;
using IMS.Application.Repositories.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryRepository _inventoryrepository;

        public InventoryController(IInventoryRepository inventoryrepository)
        {
            _inventoryrepository = inventoryrepository;
        }
        [HttpGet("ByName")]
        public async Task<IActionResult> GetInventoryByName(string name = "")
        {
            var result = await _inventoryrepository.GetInventoriesByName(name);
            return Ok(result);
        }
        [HttpPost("AddInventory")]
        public async Task<ActionResult> AddInventory(InvetoryDto inventory)
        {
            try
            {
                var result = await _inventoryrepository.AddInventory(inventory);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ById")]
        public async Task<IActionResult> GetInventoryById(int id)
        {
            var result = await _inventoryrepository.GetInvetoryById(id);
            return Ok(result);
        }




    }
}