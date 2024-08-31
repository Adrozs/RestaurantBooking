using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RestaurantBooking.Models.DTOs.TableDTOs;
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
                return BadRequest("Failed to create table: " + ex.Message);
            }
            

            return Ok("Successfully created table.");
        }

        [HttpGet("GetAllAvailableTables")]
        public async Task<ActionResult<TableDTO>> GetAvailableTablesAsync()
        {
            var availableTables = await _tableService.GetAvailableTablesAsync();

            if (availableTables.IsNullOrEmpty())
                return NotFound("No available tables were found.");

            return Ok(availableTables);
        }

        [HttpGet("GetAllTables")]
        public async Task<ActionResult<TableDTO>> GetAllTablesAsync()
        {
            var allTables = await _tableService.GetAllTablesAsync();

            if (allTables == null)
                return NotFound("No tables were found.");

            return Ok(allTables);
        }

        [HttpGet("GetTableById")]
        public async Task<ActionResult<TableDTO>> GetTableByIdAsync([FromQuery] int tableId) 
        {
            var table = await _tableService.GetTableByIdAsync(tableId);

            if (table == null)
                return NotFound("No matching table was found.");

            return Ok(table);
        }

        [HttpPost("UpdateTable")]
        public async Task<ActionResult<TableDTO>> UpdateTableAsync([FromBody] UpdateTableDTO table)
        {
            try
            {
                await _tableService.UpdateTableAsync(table);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

            return Ok("Table successfully updated.");
        }

        [HttpDelete("DeleteTable")]
        public async Task<ActionResult<TableDTO>> DeleteTableAsync([FromQuery] int tableId)
        {
            try
            {
                await _tableService.DeleteTableAsync(tableId);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Table successfully deleted.");
        }
    }
}
