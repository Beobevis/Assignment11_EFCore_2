using Assignment11_EFCore_2.Data.Entities;

namespace Assignment11_EFCore_2.Data.Repository
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        //Có đỦ 5 phương thức của IGenericRepository vơi kiểU dữ liệu Category
        Task<IEnumerable<Category>> FilterAsync();
    }
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(MyDbContext context) : base(context)
        {
            // Không cần implement vì đã có 5 phương thức của Generic Repository      
            
        }
        public Task<IEnumerable<Category>> FilterAsync()
            {
                throw new NotImplementedException();
            }
    }
}
