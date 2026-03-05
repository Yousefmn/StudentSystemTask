using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P02_SalesDatabase.Models;

public class Store
{
    public int StoreId { get; set; }

    [MaxLength(80)]
    public string Name { get; set; }

    public ICollection<Sale> Sales { get; set; } = new List<Sale>();
}