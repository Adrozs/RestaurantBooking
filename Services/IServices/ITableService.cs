using RestaurantBooking.Models.DTOs;

namespace RestaurantBooking.Services.IServices
{
    public interface ITableService
    {
        public Task CreateTableAsync(CreateTableDTO table);
        public Task<IEnumerable<TableDTO>> GetAllTablesAsync();
        public Task<IEnumerable<TableDTO>> GetAllAvailableTablesAsync();
        public Task<TableDTO> GetTableByIdAsync(int tableId);
        public Task UpdateTableAsync(TableDTO table);
        public Task DeleteTableAsync(int tableId);
    }
}
