using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Assignment11_EFCore_2.Data.Entities;

public class Category : BaseEntity
{
    [Required, MaxLength(50)]
    public string? Name { get; set; }

    //Relationship
    
    public ICollection<Product>? Products { get; set; }
}

