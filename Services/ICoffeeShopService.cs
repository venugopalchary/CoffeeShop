using CoffeeShopAPI.Models.DTO;

namespace CoffeeShopAPI.Services
{
    public interface ICoffeeShopService
    {
        //public async Task<CoffeeShopDTO> CreateCoffeeShopAsync(CoffeeShopDTO coffeeShopDTO)
        Task<CoffeeShopDTO> CreateCoffeeShopAsync(CoffeeShopDTO coffeeShopDTO);

        Task<List<CoffeeShopDTO>> GetAllCoffeeShopAsync();

        Task<List<CoffeeShopDTO>> GetAllCoffeeShopByNameAsync(string names);

        Task<List<CoffeeShopDTO>> GetAllOpenedCoffeeShopAsync();

        Task<List<CoffeeShopDTO>> GetAllCoffeeShopByIdAsync(Guid Id);

        Task<CoffeeShopDTO> UpdateCoffeeShopAsync(CoffeeShopDTO coffeeShopDTO);

        Task<CoffeeShopDTO> DeleteCoffeeShopAsync(Guid guid);

    }
}
