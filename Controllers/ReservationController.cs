using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RestaurantBooking.Models.DTOs.OrderDTOs;
using RestaurantBooking.Models.DTOs.ReservationDTOs;
using RestaurantBooking.Services.IServices;

namespace RestaurantBooking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _resService;

        public ReservationController(IReservationService resService)
        {
            _resService = resService;
        }

        [HttpPost("OrderDish")]
        public async Task<ActionResult> AddDishToReservationAsync(OrderDTO orderDto)
        {
            try
            {
                await _resService.AddDishToReservationAsync(orderDto);
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to order dish: " + ex.Message);
            }

            return Ok("Dish successfully ordered and added to reservation.");
        }


        [HttpPost("CreateReservation")]
        public async Task<ActionResult> CreateReservationAsync(CreateReservationDTO resDto)
        {
            try
            {
                await _resService.CreateReservationAsync(resDto);
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to create reservation: " + ex.Message);
            }

            return Ok("Successfully created reservation.");
        }

        [HttpGet("GetAllReservations")]
        public async Task<ActionResult<IEnumerable<ReservationDTO>>> GetAllReservationsAsync()
        {
            try
            {
                var resList = await _resService.GetAllReservationsAsync();
                if (resList.IsNullOrEmpty())
                    return NotFound("No reservations were found.");

                return Ok(resList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetActiveReservations")]
        public async Task<ActionResult<IEnumerable<ReservationDTO>>> GetActiveReservationsAsync()
        {
            try
            {
                var resList = await _resService.GetActiveReservationsAsync();
                if (resList.IsNullOrEmpty())
                    return NotFound("No active reservations were found.");

                return Ok(resList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetReservationById")]
        public async Task<ActionResult<ReservationAndDishesDTO>> GetReservationByIdAsync([FromQuery] int resId)
        {
            try
            {
                var res = await _resService.GetReservationByIdAsync(resId);
                if (res == null)
                    return NotFound("Reservation was not found.");

                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateReservation")]
        public async Task<ActionResult> UpdateReservationAsync([FromBody] UpdateReservationDTO resDto)
        {
            try
            {
                await _resService.UpdateReservationAsync(resDto);
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to update reservation: " + ex.Message);
            }

            return Ok("Successfully updated reservation");
        }

        [HttpDelete("DeleteReservation")]
        public async Task<ActionResult> DeleteReservationAsync(int resId)
        {
            try
            {
                await _resService.DeleteReservationAsync(resId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Successfully deleted reservation.");
        }
    }
}
