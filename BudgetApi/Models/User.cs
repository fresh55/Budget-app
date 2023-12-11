using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApi.Models
{
    public class User
    {
       public int UserId { get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }

    // Navigation properties
    public virtual ICollection<Transaction> Transactions { get; set; }
    public virtual ICollection<Budget> Budgets { get; set; }
}

    }
