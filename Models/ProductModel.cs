using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Assignment11_EFCore_2.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Manufacturer { get; set; }
        public int CategoryId { get; set; }

    }
    public class ProductEditModel : ProductViewModel
    {
        
    }
    public class ProductCreateModel
    {

        [Required, MaxLength(50)]
        public string? Name { get; set; }
        [Required, MaxLength(100)]
        public string? Manufacturer { get; set; }
        public int CategoryId { get; set; }

    }

}
