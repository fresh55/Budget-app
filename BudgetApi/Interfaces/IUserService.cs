using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetApi.Models;

namespace BudgetApi.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> CreateUserAsync(User user);
          Task<User> CreateUserWithDetailsAsync(string username, string email);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
    }
}