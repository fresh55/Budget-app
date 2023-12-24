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
    public ICollection<Transaction> Transactions { get; set; }
    public ICollection<Budget> Budgets { get; set; }

    public User()
    {
        Transactions = new List<Transaction>();
        Budgets = new List<Budget>();
    }
}

    }
