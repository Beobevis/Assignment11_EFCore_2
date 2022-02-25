using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Assignment11_EFCore_2.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        
    }
    public class CategoryEditModel : CategoryCreateModel{ 
        public int Id { get; set; }
    }
    public class CategoryCreateModel
    {

        [Required, MaxLength(50)]
        public string? Name { get; set; }
        
    }

}
