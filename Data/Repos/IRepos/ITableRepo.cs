using RestaurantBooking.Models;

namespace RestaurantBooking.Data.Repos.IRepos
{
    public interface ITableRepo
    {
        public Task CreateTableAsync(Table table);
        public Task<IEnumerable<Table>> GetAllTablesAsync();
        public Task<IEnumerable<Table>> GetAllAvailableTablesAsync();
        public Task<Table> GetTableByIdAsync(int tableId);
        public Task<Table> GetTableByTableNumberAsync(int tableNumber);
        public Task UpdateTableAsync(Table table);
        public Task DeleteTableAsync(Table table);
    }
}
