using Microsoft.AspNetCore.Mvc;
using RestaurantBooking.Models.DTOs;
using RestaurantBooking.Services.IServices;

namespace RestaurantBooking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TableController : ControllerBase
    {
        private readonly ITableService _tableService;

        public TableController(ITableService tableService)
        {
            _tableService = tableService;
        }

        [HttpPost("CreateTable")]
        public async Task<ActionResult<TableDTO>> CreateTableAsync([FromBody] CreateTableDTO table)
        {
            try
            {
                await _tableService.CreateTableAsync(table);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            

            return Ok();
        }


        [HttpDelete("DeleteTable")]
        public async Task<ActionResult<TableDTO>> DeleteTableAsync([FromQuery] int tableId)
        {
            await _tableService.DeleteTableAsync(tableId);

            // Error handling ?

            return Ok();
        }

        [HttpGet("GetAllAvailableTables")]
        public async Task<ActionResult<TableDTO>> GetAllAvailableTablesAsync()
        {
            var availableTables = await _tableService.GetAllAvailableTablesAsync();

            if (availableTables == null)
                return NotFound();

            return Ok(availableTables);
        }

        [HttpGet("GetAllTables")]
        public async Task<ActionResult<TableDTO>> GetAllTablesAsync()
        {
            var allTables = await _tableService.GetAllTablesAsync();

            if (allTables == null)
                return NotFound();

            return Ok(allTables);
        }

        [HttpGet("GetTableById")]
        public async Task<ActionResult<TableDTO>> GetTableByIdAsync([FromQuery] int tableId) 
        {
            var table = await _tableService.GetTableByIdAsync(tableId);

            if (table == null)
                return NotFound();

            return Ok(table);
        }

        [HttpPost("UpdateTable")]
        public async Task<ActionResult<TableDTO>> UpdateTableAsync([FromBody] TableDTO table)
        {
            try
            {
                await _tableService.UpdateTableAsync(table);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

            return Ok();
        }
    }
}
