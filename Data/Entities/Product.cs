using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Assignment11_EFCore_2.Data.Entities;

    public class Product:BaseEntity
    {
    [Required, MaxLength(50)]
    public string? Name { get; set; }
    [Required, MaxLength(100)]
    public string? Manufacturer { get; set; }

    //Relationship
    [Required]
    public int CategoryId  { get; set; }

    [ForeignKey("CategoryId")]
    public virtual Category? Categories { get; set;}

    }

