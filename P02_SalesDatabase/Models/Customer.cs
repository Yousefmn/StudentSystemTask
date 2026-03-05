using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P02_SalesDatabase.Models;

public class Customer
{
    public int CustomerId { get; set; }

    [MaxLength(100)]
    public string Name { get; set; }

    [MaxLength(80)]
    [Unicode(false)]
    public string Email { get; set; }

    public string CreditCardNumber { get; set; }

    public ICollection<Sale> Sales { get; set; } = new List<Sale>();
}