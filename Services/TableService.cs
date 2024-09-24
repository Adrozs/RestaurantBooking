using AutoMapper;
using Microsoft.IdentityModel.Tokens;
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

            // Map dto to object
            var table = new Table
            {
                Seats = tableDto.Seats,
                ReservedUntil = DateTime.MinValue,
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
                Seats = table.Seats,
                ReservedUntil = table.ReservedUntil
            };
        }

        public async Task UpdateTableAsync(UpdateTableDTO tableDto)
        {
            // Not using table number anymore
            // Make sure table number isn't already taken
            //var existingTable = await _tableRepo.GetTableByTableNumberAsync(tableDto.TableNumber);
            //if (existingTable != null)
            //    throw new InvalidOperationException("Table number already taken.");

            // Get table
            var table = await _tableRepo.GetTableByIdAsync(tableDto.Id);

            if (table == null)
                throw new InvalidOperationException("Table was not found.");

            // Update properties
            table.Seats = tableDto.Seats;
            table.ReservedUntil = tableDto.ReservedUntil;

            await _tableRepo.UpdateTableAsync(table);
        }

        public async Task<List<AvailableTableTimesDTO>> GetAvailableTableTimesAsync(AvailableTableTimesReqDTO reqDto)
        {
            var tables = await _tableRepo.GetAvailableTableTimesAsync(reqDto.SelectedDate, reqDto.NumberOfGuests);

            if (tables.IsNullOrEmpty())
                throw new InvalidOperationException("No available tables were found.");

            return tables;
        }

    }
}
