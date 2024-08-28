using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RestaurantBooking.Models.DTOs.DishDTOs;
using RestaurantBooking.Services.IServices;

namespace RestaurantBooking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DishController : ControllerBase
    {
        private readonly IDishService _dishService;

        public DishController(IDishService dishService)
        {
            _dishService = dishService;
        }

        [HttpPost("CreateDish")]
        public async Task<ActionResult> CreateDishAsync([FromBody] CreateDishDTO dish)
        {
            try
            {
                await _dishService.CreateDishAsync(dish);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


            return Ok("Dish created successfully.");
        }

        [HttpGet("GetAllDishes")]
        public async Task<ActionResult> GetAllDishesAsync()
        {
           var dishes = await _dishService.GetAllDishesAsync();

            if (dishes.IsNullOrEmpty())
                return NotFound("No dishes were found");
                
            return Ok(dishes);
        }

        [HttpGet("GetAvailableDishes")]
        public async Task<ActionResult> GetAvailableDishesAsync()
        {
            var dishes = await _dishService.GetAvailableDishesAsync();

            if (dishes.IsNullOrEmpty())
                return NotFound("No available dishes found.");

            return Ok(dishes);
        }

        [HttpGet("GetDishById")]
        public async Task<ActionResult> GetDishByIdAsync([FromQuery] int dishId)
        {
            var dish = await _dishService.GetDishByIdAsync(dishId);

            if (dish == null)
                return NotFound("No matching dish found.");

            return Ok(dish);
        }

        [HttpPost("UpdateDish")]
        public async Task<ActionResult> UpdateDishAsync([FromBody] DishDTO dish)
        {
            try
            {
                await _dishService.UpdateDishAsync(dish);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Dish successfully updated.");
        }

        [HttpDelete("DeleteDish")]
        public async Task<ActionResult> DeleteDishAsync([FromQuery] int dishId)
        {
            try
            {
                await _dishService.DeleteDishAsync(dishId);
            }
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message); 
            }

            return Ok("Dish successfully deleted.");
        }
    }
}
