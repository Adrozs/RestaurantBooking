﻿using RestaurantBooking.Data.Repos.IRepos;
using RestaurantBooking.Models;
using RestaurantBooking.Models.DTOs.DishDTOs;
using RestaurantBooking.Services.IServices;

namespace RestaurantBooking.Services
{
    public class DishService : IDishService
    {
        private readonly IDishRepo _dishRepo;

        public DishService(IDishRepo dishRepo)
        {
            _dishRepo = dishRepo;
        }

        public async Task CreateDishAsync(CreateDishDTO dish)
        {
            var newDish = new Dish
            {
                Name = dish.Name,
                Description = dish.Description,
                Price = dish.Price,
                IsAvailable = dish.IsAvailable,
                MealType = dish.MealType,
            };

            await _dishRepo.CreateDishAsync(newDish);
        }

        public async Task DeleteDishAsync(int dishId)
        {
            var dish = await _dishRepo.GetDishByIdAsync(dishId);
            if (dish == null)
                throw new InvalidOperationException("Dish was not found.");

            await _dishRepo.DeleteDishAsync(dish);
        }

        public async Task<IEnumerable<DishDTO>> GetAllDishesAsync()
        {
            var dishes = await _dishRepo.GetAllDishesAsync();
            if (dishes == null)
                return null;

            return dishes.Select(d => new DishDTO
            {
                Id = d.Id,
                Name = d.Name,
                Description = d.Description,
                Price = d.Price,
                IsAvailable = d.IsAvailable,
                MealType = d.MealType
            });
        }

        public async Task<IEnumerable<DishDTO>> GetAvailableDishesAsync()
        {
            var dishes = await _dishRepo.GetAvailableDishesAsync();
            if (dishes == null)
                return null;

            return dishes.Select(d => new DishDTO
            {
                Id = d.Id,
                Name = d.Name,
                Description = d.Description,
                Price = d.Price,
                IsAvailable = d.IsAvailable,
                MealType = d.MealType
            });
        }

        public async Task<DishDTO> GetDishByIdAsync(int dishId)
        {
            var dish = await _dishRepo.GetDishByIdAsync(dishId);
            if (dish == null)
                return null;

            var dishDto = new DishDTO
            {
                Id = dish.Id,
                Name = dish.Name,
                Description = dish.Description,
                Price = dish.Price,
                IsAvailable = dish.IsAvailable,
                MealType = dish.MealType
            };

            return dishDto;
        }

        public async Task UpdateDishAsync(DishDTO dish)
        {
            var existingDish = await _dishRepo.GetDishByIdAsync(dish.Id);
            if (existingDish == null)
                throw new InvalidOperationException("Dish was not found.");

            existingDish.Name = dish.Name;
            existingDish.Description = dish.Description;
            existingDish.Price = dish.Price;
            existingDish.IsAvailable = dish.IsAvailable;
            existingDish.MealType = dish.MealType;

            await _dishRepo.UpdateDishAsync(existingDish);
        }
    }
}
