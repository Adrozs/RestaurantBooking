using RestaurantBooking.Models.DTOs.TableDTOs;

namespace RestaurantBooking.Services.IServices
{
    public interface ITableService
    {
        public Task CreateTableAsync(CreateTableDTO table);
        public Task<IEnumerable<TableDTO>> GetAllTablesAsync();
        public Task<IEnumerable<TableDTO>> GetAvailableTablesAsync();
        public Task<TableDTO> GetTableByIdAsync(int tableId);
        public Task UpdateTableAsync(UpdateTableDTO table);
        public Task DeleteTableAsync(int tableId);
        public Task<List<AvailableTableTimesDTO>> GetAvailableTableTimesAsync(AvailableTableTimesReqDTO reqDto);

    }
}
