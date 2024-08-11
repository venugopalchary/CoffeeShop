using CoffeeShopAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CoffeeShopAPI.DBLayer.Repository
{
    public class CoffeeShopRepository : ICoffeeShopRepository
    {
        private readonly CoffeeShopDbContext _coffeeShopDbContext;
        private DbSet<CoffeeShop> _coffeeShopSet;
       

        public CoffeeShopRepository(CoffeeShopDbContext coffeeShopDbContext) 
        {
            _coffeeShopDbContext = coffeeShopDbContext;
            _coffeeShopSet = coffeeShopDbContext.Set<CoffeeShop>();
            
        }

        public async Task<CoffeeShop> CreateCoffeeShopAsync(CoffeeShop dbCoffeeShop)
        {
            _coffeeShopSet.Add(dbCoffeeShop);
            await _coffeeShopDbContext.SaveChangesAsync();
            return dbCoffeeShop;
        }

        public async Task<bool> DeleteCoffeeShopAsync(CoffeeShop dbCoffeeShop)
        {
            _coffeeShopSet.Remove(dbCoffeeShop);
            await _coffeeShopDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<CoffeeShop>> GetAllAsync()
        {
            return await _coffeeShopSet.ToListAsync();
        }

        public async Task<List<CoffeeShop>> GetAllByFilterAsync(Expression<Func<CoffeeShop, bool>> filter, bool useNoTracking = false)
        {
            if (useNoTracking)
                return await _coffeeShopSet.AsNoTracking().Where(filter).ToListAsync();
            else
                return await _coffeeShopSet.Where(filter).ToListAsync();
        }

        public async Task<CoffeeShop> UpdateCoffeeShopAsync(CoffeeShop dbCoffeeShop)
        {
            _coffeeShopDbContext?.Update(dbCoffeeShop);
            await _coffeeShopDbContext?.SaveChangesAsync();
            return dbCoffeeShop;
        }

       
    }
}
