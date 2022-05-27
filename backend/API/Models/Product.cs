using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models;

public class Product : IEntity
{
    [Column("ProductID")]
    public int Id { get; set; }

    [MaxLength(50)]
    public string Name { get; set; } = default!;
}