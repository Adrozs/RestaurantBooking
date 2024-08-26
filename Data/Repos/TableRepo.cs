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
            // if existing table isn't null throw exception (this should never happen, hence the exception
            if (await _context.Tables.AnyAsync(t => t.Id == table.Id))
                throw new ArgumentException("Failed to create table, table already exists.");

            await _context.AddAsync(table);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteTableAsync(Table table)
        {
            _context.Tables.Remove(table);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Table>> GetAllAvailableTablesAsync()
        {
            return await _context.Tables.Where(t => t.IsReserved == false).ToListAsync();
        }

        public async Task<IEnumerable<Table>> GetAllTablesAsync()
        {
            return await _context.Tables.ToListAsync();
        }

        public async Task<Table> GetTableByIdAsync(int tableId)
        {
            return await _context.Tables.SingleOrDefaultAsync(t => t.Id == tableId);
        }

        public async Task<Table> GetTableByTableNumberAsync(int tableNumber)
        {
            return await _context.Tables.SingleOrDefaultAsync(t => t.TableNumber == tableNumber); 
        }

        public async Task UpdateTableAsync(Table table)
        {
            _context.Tables.Update(table);
            await _context.SaveChangesAsync();  
        }
    }
}
