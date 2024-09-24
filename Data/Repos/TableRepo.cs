using Microsoft.EntityFrameworkCore;
using RestaurantBooking.Data.Repos.IRepos;
using RestaurantBooking.Models;
using RestaurantBooking.Models.DTOs.TableDTOs;

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

        public async Task<List<AvailableTableTimesDTO>> GetAvailableTableTimesAsync(DateTime selectedDate, int guests)
        {
            int startTime = 12;
            int endTime = 22;
            var availableTablesList = new List<AvailableTableTimesDTO>();
            
            // Iterate over each hour and save available tables
            for (int i = startTime; i <= endTime; i++)
            {
                // Create a new DateTime for the current hour being checked
                DateTime currentHour = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, i, 0, 0);

                // Find the first available table that has enough or more seats and is free at the hour we're checking
                var table = await _context.Tables.FirstOrDefaultAsync(t => 
                    t.Seats >= guests && 
                    t.ReservedUntil == null || t.ReservedUntil < currentHour);

                // If null skip
                if (table != null)
                {
                    // Add table id and the available time to the list
                    availableTablesList.Add(new AvailableTableTimesDTO {
                        Id = table.Id,
                        AvailableTime = currentHour,
                    });

                }

            }

            return availableTablesList;
        }
    }
}
