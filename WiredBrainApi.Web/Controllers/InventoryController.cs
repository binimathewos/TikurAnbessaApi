using Microsoft.AspNetCore.Mvc;
using WiredBrainApi.Services;

namespace WiredBrainApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly ILogger<InventoryController> _logger;
        private readonly IInventoryService _inventoryService;

        public InventoryController(IInventoryService inventoryService, ILogger<InventoryController> logger)
        {
            _inventoryService = inventoryService;
            _logger = logger;
        }

        [HttpGet("/{id}")]
        public ActionResult<LocationInventory> Get(int id)
        {
            _logger.LogInformation($"Location Inventory endpoint called - Location Id: {id}");
            var inventory = _inventoryService.GetLocationInventory(id);
            if (inventory == null)
            {
                return NotFound();
            }

            return inventory;
        }
    }
}
