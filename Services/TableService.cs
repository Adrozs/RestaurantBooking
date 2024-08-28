using AutoMapper;
using RestaurantBooking.Data.Repos.IRepos;
using RestaurantBooking.Models;
using RestaurantBooking.Models.DTOs.TableDTOs;
using RestaurantBooking.Services.IServices;

namespace RestaurantBooking.Services
{
    public class TableService : ITableService
    {
        private readonly ITableRepo _tableRepo;

        public TableService(ITableRepo tableRepo)
        {
            _tableRepo = tableRepo;
        }

        public async Task CreateTableAsync(CreateTableDTO tableDto)
        {
            // Make sure table number isn't already taken
            var existingTable = await _tableRepo.GetTableByTableNumberAsync(tableDto.TableNumber);
            if (existingTable != null)
                throw new InvalidOperationException("Table number already taken.");

            // Map dto to object
            var table = new Table
            {
                Seats = tableDto.Seats,
                TableNumber = tableDto.TableNumber,
            };

            await _tableRepo.CreateTableAsync(table);
        }

        public async Task DeleteTableAsync(int tableId)
        {
            var table = await _tableRepo.GetTableByIdAsync(tableId);

            if (table == null)
                throw new ArgumentException("No matching user found.");

            await _tableRepo.DeleteTableAsync(table);
        }

        public async Task<IEnumerable<TableDTO>> GetAvailableTablesAsync()
        {
            var availableTables = await _tableRepo.GetAvailableTablesAsync();

            // Return mapped dto 
            return availableTables.Select(t => new TableDTO
            {
                Id = t.Id,
                TableNumber = t.TableNumber,
                Seats = t.Seats,
                ReservedUntil = t.ReservedUntil
            }).ToList();
        }

        public async Task<IEnumerable<TableDTO>> GetAllTablesAsync()
        {
            var allTables = await _tableRepo.GetAllTablesAsync();

            if (allTables == null)
                return null;

            // Return mapped dto 
            return allTables.Select(t => new TableDTO
            {
                Id= t.Id,
                TableNumber = t.TableNumber,
                Seats = t.Seats,
                ReservedUntil = t.ReservedUntil
            }).ToList();
        }

        public async Task<TableDTO> GetTableByIdAsync(int tableId)
        {
            var table = await _tableRepo.GetTableByIdAsync(tableId);

            if (table == null)
                return null;
            
            // Map and return table dto
            return new TableDTO
            {
                Id = table.Id,
                TableNumber = table.TableNumber,
                Seats = table.Seats,
                ReservedUntil = table.ReservedUntil
            };
        }

        public async Task UpdateTableAsync(UpdateTableDTO tableDto)
        {
            // Make sure table number isn't already taken
            var existingTable = await _tableRepo.GetTableByTableNumberAsync(tableDto.TableNumber);
            if (existingTable != null)
                throw new InvalidOperationException("Table number already taken.");

            // Get table
            var table = await _tableRepo.GetTableByIdAsync(tableDto.Id);

            if (table == null)
                throw new InvalidOperationException("Table was not found.");

            // Update properties
            table.TableNumber = tableDto.TableNumber;
            table.Seats = tableDto.Seats;
            table.ReservedUntil = tableDto.ReservedUntil;

            await _tableRepo.UpdateTableAsync(table);
        }
    }
}
