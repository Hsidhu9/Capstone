﻿using ShiftPicker.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShiftPicker.Data.Services
{
    /// <summary>
    /// Abstraction of User Service
    /// </summary>
    public interface IUserService
    {
        void ActivateUser(UserModel userModel);
        void AddUser(UserModel user);
        void DeactivateUser(UserModel userModel);
        Task<List<UserModel>> GetAllEmployees();
        Task<UserModel> GetUserByUsername(string username);
        Task<List<UserModel>> GetAllSupervisors();
        Task<UserModel> GetUser(int Id);
        Task<UserModel> GetUserByIdAsync(int Id);
        void UpdateUser(UserModel user);
        UserModel GetUserById(int Id);
    }
}