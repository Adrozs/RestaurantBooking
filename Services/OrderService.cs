//using RestaurantBooking.Data.Repos.IRepos;
//using RestaurantBooking.Models;
//using RestaurantBooking.Models.DTOs.OrderDTOs;
//using RestaurantBooking.Services.IServices;

//namespace RestaurantBooking.Services
//{
//    public class OrderService : IOrderService
//    {
//        private readonly IOrderRepo _orderRepo;
//        private readonly IDishRepo _dishRepo;
//        private readonly IReservationRepo _resRepo;

//        public OrderService(IOrderRepo orderRepo, IDishRepo dishRepo, IReservationRepo resRepo)
//        {
//            _orderRepo = orderRepo;
//            _dishRepo = dishRepo;
//            _resRepo = resRepo;
//        }


//        public async Task CreateOrderAsync(CreateOrderDTO orderDto)
//        {
//            var res = await _resRepo.GetReservationByIdAsync(orderDto.ReservationId);

//            var newOrder = new OrderOLD
//            {
//                ReservationId = orderDto.ReservationId,
//                Reservation = res,
//                TotalBill = 0M // Bill initialized as 0
//            };

//            await _orderRepo.CreateOrderAsync(newOrder);
//        }

//        public Task DeleteOrderAsync(int orderId)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<OrderDTO> GetOrderByIdAsync(int orderId)
//        {
//            throw new NotImplementedException();
//        }

//        public Task UpdateOrderAsync(OrderDTO order)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
