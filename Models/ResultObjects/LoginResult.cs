﻿namespace RestaurantBooking.Models.ResultObjects
{
    public class LoginResult
    {
        public bool Success {  get; set; }
        public string? ErrorMessage { get; set; }
        public User User { get; set; }
    }
}
