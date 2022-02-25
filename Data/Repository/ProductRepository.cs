using Assignment11_EFCore_2.Data.Entities;

namespace Assignment11_EFCore_2.Data.Repository
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        //Có đỦ 5 phương thức của IGenericRepository vơi kiểU dữ liệu Category
        Task<IEnumerable<Product>> FilterAsync();
    }
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(MyDbContext context) : base(context)
        {
            // Không cần implement vì đã có 5 phương thức của Generic Repository      
            
        }
        public Task<IEnumerable<Product>> FilterAsync()
            {
                throw new NotImplementedException();
            }
    }
}
