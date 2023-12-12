using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApi.Models
{
    public class Budget
    {
    public int BudgetId { get; set; }
    public decimal Amount { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public required string Description { get; set; }

    // Foreign Key
    public int UserId { get; set; }

    // Navigation property
    public virtual required User User { get; set; }
    }
}