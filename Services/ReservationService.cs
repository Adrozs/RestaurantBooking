using RestaurantBooking.Models;
using RestaurantBooking.Models.DTOs.ReservationDTOs;
using RestaurantBooking.Services.IServices;
using RestaurantBooking.Data.Repos.IRepos;
using RestaurantBooking.Data;
using RestaurantBooking.Models.DTOs.OrderDTOs;
using RestaurantBooking.Models.DTOs.DishDTOs;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace RestaurantBooking.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepo _resRepo;
        private readonly ITableRepo _tableRepo;
        private readonly ICustomerRepo _customerRepo;
        private readonly IDishRepo _dishRepo;
        private readonly BookingDbContext _context;

        public ReservationService(IReservationRepo resRepo, ITableRepo tableRepo, ICustomerRepo customerRepo, IDishRepo dishRepo, BookingDbContext context)
        {
            _resRepo = resRepo;
            _tableRepo = tableRepo;
            _customerRepo = customerRepo;
            _dishRepo = dishRepo;
            _context = context;
        }

        public async Task AddDishToReservationAsync(OrderDTO orderDto)
        {
            // Retriece dish and reservation
            var dish = await _dishRepo.GetDishByIdAsync(orderDto.DishId);
            if (dish == null)
                throw new InvalidOperationException("Dish was not found.");

            var res = await _resRepo.GetReservationByIdAsync(orderDto.ReservationId);
            if (res == null)
                throw new InvalidOperationException("Reservation was not found.");


            // Create new order and connect dish, reservation and potential special instructions together
            var newOrder = new Order
            {
                DishId = orderDto.DishId,
                Dish = dish,
                ReservationId = orderDto.ReservationId,
                Reservation = res,
                SpecialInstructions = orderDto.SpecialInstructions,
            };

            // Add the dish price to the total bill for the reservation
            res.TotalBill += dish.Price;

            res.Orders.Add(newOrder);


            try
            {
                // Add the order to the reservation
                await _resRepo.UpdateReservationAsync(res);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Order could not be added to reservation. Reason: {ex.Message}");

            }

        }

        public async Task CreateReservationAsync(CreateReservationDTO res)
        {
            // Check if table already is reserved
            if (!await _resRepo.IsTableAvailableAsync(res.TableId, res.ReservationTime, res.ReservationDurationMinutes))
                throw new InvalidOperationException("Table is not available at the requested time.");

            // Begin transaction to roll back changes in case something fails
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // Check if customer exists to connect reservation to
                var customer = await _customerRepo.GetCustomerByIdAsync(res.CustomerId);
                if (customer == null)
                    throw new InvalidOperationException("No matching customer was found.");

      
                // Check if table exists and update reserved time
                var table = await _tableRepo.GetTableByIdAsync(res.TableId);
                if (table == null)
                    throw new InvalidOperationException("No matching table was found.");

                if (table.Seats < res.Guests)
                    throw new InvalidOperationException($"Selected table has too few seats for the number of guests. Seats: {table.Seats}. Guests: {res.Guests}.");

                table.ReservedUntil = res.ReservationTime.AddMinutes(res.ReservationDurationMinutes);

                await _tableRepo.UpdateTableAsync(table);


                // Create reservation

                // If no duration was sent in then default duration of 2 hours is applied
                if (res.ReservationDurationMinutes == 0)
                    res.ReservationDurationMinutes = 120;

                var newReservation = new Reservation
                {
                    ReservationTime = res.ReservationTime,
                    ReservationDurationMinutes = res.ReservationDurationMinutes,
                    Guests = res.Guests,
                    TableId = res.TableId,
                    CustomerId = res.CustomerId,
                    TotalBill = 0M // Bill initialized at 0
                };

                await _resRepo.CreateReservationAsync(newReservation);

                await transaction.CommitAsync();

            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task DeleteReservationAsync(int resId)
        {
            var res = await _resRepo.GetReservationByIdAsync(resId);
            if (res == null)
                throw new InvalidOperationException("Reservation was not found.");

            await _resRepo.DeleteReservationAsync(res);
        }

        public async Task<IEnumerable<ReservationDTO>> GetAllReservationsAsync()
        {
            var reservations = await _resRepo.GetAllReservationsAsync();
            if (reservations == null)
                return null;


            return reservations.Select(r => new ReservationDTO
            {
                Id = r.Id,
                ReservationTime = r.ReservationTime,
                ReservationDurationMinutes= r.ReservationDurationMinutes,
                Guests = r.Guests,
                CustomerName = r.Customer.Name,
                TableId = r.TableId,
                CustomerId = r.CustomerId,
                TotalBill= r.TotalBill,
            });
        }

        public async Task<IEnumerable<ReservationDTO>> GetActiveReservationsAsync()
        {
            var reservations = await _resRepo.GetActiveReservationsAsync();
            if (reservations == null)
                return null;

            return reservations.Select(r => new ReservationDTO
            {
                Id = r.Id,
                ReservationTime = r.ReservationTime,
                ReservationDurationMinutes = r.ReservationDurationMinutes,
                Guests = r.Guests,
                CustomerName = r.Customer.Name,
                TableId = r.TableId,
                CustomerId = r.CustomerId,
                TotalBill = r.TotalBill,
            });
        }

        public async Task<ReservationAndDishesDTO> GetReservationByIdAsync(int resId)
        {
            var res = await _resRepo.GetReservationAndOrderedDishesByIdAsync(resId);
            if (res == null)
                return null;

            return new ReservationAndDishesDTO
            {
                Id=res.Id,
                ReservationTime = res.ReservationTime,
                ReservationDurationMinutes = res.ReservationDurationMinutes,
                Guests = res.Guests,
                CustomerName = res.Customer.Name,
                TableId = res.TableId,
                CustomerId = res.CustomerId,
                TotalBill = res.TotalBill,
                OrderedDishes = res.Orders.Select(o => new OrderedDishDTO
                {
                    DishId = o.Dish.Id,
                    DishName = o.Dish.Name,
                    Price = o.Dish.Price,
                    SpecialInstructions = o.SpecialInstructions
                }).ToList()
            };
        }

        public async Task UpdateReservationAsync(UpdateReservationDTO resDto)
        {
            // Get existing reservation
            var existingRes = await _resRepo.GetReservationByIdAsync(resDto.Id);
            if (existingRes == null)
                throw new InvalidOperationException("Reservation was not found.");

            // Update properties
            existingRes.ReservationTime = resDto.ReservationTime;
            existingRes.ReservationDurationMinutes = resDto.ReservationDurationMinutes;
            existingRes.Guests = resDto.Guests;
            existingRes.TotalBill = resDto.TotalBill;

            // Update foreign keys (if customer switches table or if a customer cancels and a new customer is put on the reservation or similar)

            if (existingRes.TableId != resDto.TableId)
            {
                existingRes.TableId = resDto.TableId;
                existingRes.Table = null; // Clear table entity EF core will assign it automatically when updated
            }

            if (existingRes.CustomerId != resDto.CustomerId)
            {
                existingRes.CustomerId = resDto.CustomerId;
                existingRes.Customer = null; // Clear customer entity
            }

            await _resRepo.UpdateReservationAsync(existingRes);
        }
    }
}
