using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApi.Models
{
    public class Category
    {
    
    public int CategoryId { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }

    // Navigation properties
    public virtual required ICollection<Transaction> Transactions { get; set; }
    }
}