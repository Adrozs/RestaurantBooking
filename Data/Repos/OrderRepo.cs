//using Microsoft.EntityFrameworkCore;
//using RestaurantBooking.Data.Repos.IRepos;
//using RestaurantBooking.Models;
//using RestaurantBooking.Models.DTOs.OrderDTOs;

//namespace RestaurantBooking.Data.Repos
//{
//    public class OrderRepo : IOrderRepo
//    {
//        private readonly BookingDbContext _context;

//        public OrderRepo(BookingDbContext context)
//        {
//            _context = context;
//        }

//        public async Task CreateOrderAsync(OrderOLD order)
//        {
//            _context.Orders.Add(order);
//            await _context.SaveChangesAsync();
//        }

//        public async Task DeleteOrderAsync(OrderOLD order)
//        {
//            _context.Orders.Remove(order);
//            await _context.SaveChangesAsync();
//        }

//        public async Task<OrderOLD> GetOrderByIdAsync(int orderId)
//        {
//            return await _context.Orders.SingleOrDefaultAsync(o => o.Id == orderId);
//        }

//        public async Task UpdateOrderAsync(OrderOLD order)
//        {
//            _context.Update(order);
//            await _context.SaveChangesAsync();
//        }
//    }
//}
