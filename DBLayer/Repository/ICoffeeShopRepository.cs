using CoffeeShopAPI.Models;
using System.Linq.Expressions;

namespace CoffeeShopAPI.DBLayer.Repository
{
    public interface ICoffeeShopRepository
    {
       
        Task<List<CoffeeShop>> GetAllAsync();
        Task<List<CoffeeShop>> GetAllByFilterAsync(Expression<Func<CoffeeShop, bool>> filter, bool useNoTracking = false);
        //Task<List<T>> GetOpenAllCoffeeShops();

        Task<CoffeeShop> CreateCoffeeShopAsync(CoffeeShop dbCoffeeShop);
        Task<CoffeeShop> UpdateCoffeeShopAsync(CoffeeShop dbCoffeeShop);

        Task<bool> DeleteCoffeeShopAsync(CoffeeShop dbCoffeeShop);
    }
}
