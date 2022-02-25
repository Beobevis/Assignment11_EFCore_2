using Assignment11_EFCore_2.Data.Entities;
using Assignment11_EFCore_2.Data;
using Assignment11_EFCore_2.Data.Repository;

namespace Assignment11_EFCore_2.Services
{
    public interface ICategoryService : IGenericService<Category>
    {
        
    }
    public class CategoryService : GenericService<Category>, ICategoryService
    {
       
        public CategoryService(ICategoryRepository category) : base(category)
        {
            // Không cần implement vì đã có 5 phương thức của Generic Service            
        }
    }
}
