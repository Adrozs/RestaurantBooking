using RestaurantBooking.Models;
using RestaurantBooking.Models.DTOs.ReservationDTOs;
using RestaurantBooking.Services.IServices;
using RestaurantBooking.Data.Repos.IRepos;

namespace RestaurantBooking.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepo _resRepo;

        public ReservationService(IReservationRepo resRepo)
        {
            _resRepo = resRepo;   
        }

        public async Task CreateReservationAsync(CreateReservationDTO resDto)
        {
            var newReservation = new Reservation
            {
                ReservationTime = resDto.ReservationTime,
                Guests = resDto.Guests,
                TableId = resDto.TableId,
                CustomerId = resDto.CustomerId,
            };

            await _resRepo.CreateReservationAsync(newReservation);
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
                Guests = r.Guests,
                TableId = r.TableId,
                CustomerId = r.CustomerId,
            });
        }

        public async Task<ReservationDTO> GetReservationByIdAsync(int resId)
        {
            var res = await _resRepo.GetReservationByIdAsync(resId);
            if (res == null)
                return null;

            return new ReservationDTO 
            { 
                Id = res.Id, 
                ReservationTime = res.ReservationTime, 
                Guests = res.Guests,
                TableId = res.TableId,
                CustomerId = res.CustomerId                
            };
        }

        public async Task UpdateReservationAsync(ReservationDTO resDto)
        {
            var res = await _resRepo.GetReservationByIdAsync(resDto.Id);
            if (res == null)
                throw new InvalidOperationException("Reservation was not found.");

            await _resRepo.UpdateReservationAsync(res);
        }
    }
}
