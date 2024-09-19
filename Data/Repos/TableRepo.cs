using Microsoft.EntityFrameworkCore;
using RestaurantBooking.Data.Repos.IRepos;
using RestaurantBooking.Models;

namespace RestaurantBooking.Data.Repos
{
    public class TableRepo : ITableRepo
    {
        private readonly BookingDbContext _context;

        public TableRepo(BookingDbContext context)
        {
            _context = context;            
        }

        public async Task CreateTableAsync(Table table)
        {
            await _context.AddAsync(table);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTableAsync(Table table)
        {
            _context.Tables.Remove(table);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Table>> GetAvailableTablesAsync()
        {
            // Return all tables where the current time is more than the reserved time
            return await _context.Tables.Where(t => DateTime.Now > t.ReservedUntil).ToListAsync();
        }

        public async Task<IEnumerable<Table>> GetAllTablesAsync()
        {
            return await _context.Tables.ToListAsync();
        }

        public async Task<Table> GetTableByIdAsync(int tableId)
        {
            return await _context.Tables.SingleOrDefaultAsync(t => t.Id == tableId);
        }

        //public async Task<Table> GetTableByTableNumberAsync(int tableNumber)
        //{
        //    return await _context.Tables.SingleOrDefaultAsync(t => t.TableNumber == tableNumber); 
        //}

        public async Task UpdateTableAsync(Table table)
        {
            _context.Tables.Update(table);
            await _context.SaveChangesAsync();  
        }

        public async Task ReserveUntilAsync(Table table, DateTime resTime)
        {
            table.ReservedUntil = resTime;
            
            _context.Update(table);
            await _context.SaveChangesAsync();
        }
    }
}
