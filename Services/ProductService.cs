using Assignment11_EFCore_2.Data.Entities;
using Assignment11_EFCore_2.Data;
using Assignment11_EFCore_2.Data.Repository;

namespace Assignment11_EFCore_2.Services
{
    public interface IProductService : IGenericService<Product>
    {
        
    }
    public class ProductService : GenericService<Product>, IProductService
    {
       
        public ProductService(IProductRepository product) : base(product)
        {
            // Không cần implement vì đã có 5 phương thức của Generic Service            
        }
    }
}
