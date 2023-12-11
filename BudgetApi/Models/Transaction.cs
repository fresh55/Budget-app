using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApi.Models
{
    public class Transaction
    {
    public int TransactionId { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public required string Description { get; set; }
    public TransactionType Type { get; set; }

    // Foreign Key
    public int UserId { get; set; }
    public int CategoryId { get; set; }

    // Navigation properties
    public virtual required User User { get; set; }
    public virtual required Category Category { get; set; }
    }
}