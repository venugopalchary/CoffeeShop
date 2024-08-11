using AutoMapper;
using CoffeeShopAPI.DBLayer.Repository;
using CoffeeShopAPI.Models;
using CoffeeShopAPI.Models.DTO;

namespace CoffeeShopAPI.Services
{
    public class CoffeeShopService : ICoffeeShopService
    {
        private readonly IMapper _mapper;
        private readonly ICoffeeShopRepository _coffeeShopRepository;

        public CoffeeShopService(IMapper mapper, ICoffeeShopRepository coffeeShopRepository)
        {
            _mapper = mapper;
            _coffeeShopRepository = coffeeShopRepository;
        }

        public async Task<CoffeeShopDTO> CreateCoffeeShopAsync(CoffeeShopDTO coffeeShopDTO)
        {
            var coffeeShop = _mapper.Map<CoffeeShop>(coffeeShopDTO);
            var resultCoffeeShop = await _coffeeShopRepository.CreateCoffeeShopAsync(coffeeShop);
            return _mapper.Map<CoffeeShopDTO>(resultCoffeeShop);
        }

        public async Task<bool?> DeleteCoffeeShopAsync(CoffeeShopDTO coffeeShopDTO)
        {
            var coffeeShop = _mapper.Map<CoffeeShop>(coffeeShopDTO);
            var resultCoffeeShop = await _coffeeShopRepository.DeleteCoffeeShopAsync(coffeeShop);
            return resultCoffeeShop;
        }

        public async Task<CoffeeShopDTO> UpdateCoffeeShopAsync(CoffeeShopDTO coffeeShopDTO)
        {
            ArgumentNullException.ThrowIfNull(coffeeShopDTO, nameof(coffeeShopDTO));

            var existingCoffeeShop = await _coffeeShopRepository.GetAllByFilterAsync(c => c.Id == coffeeShopDTO.Id, true);

            if (existingCoffeeShop == null)
            {
                throw new Exception($"CoffeeShop not found with this Id: {coffeeShopDTO.Id}");
            }

            var coffeeShopUpdate = _mapper.Map<CoffeeShop>(coffeeShopDTO);

            var updatedCoffeeShop =  await _coffeeShopRepository.UpdateCoffeeShopAsync(coffeeShopUpdate);

            return _mapper.Map<CoffeeShopDTO>(updatedCoffeeShop);
        }

        public async Task<CoffeeShopDTO> DeleteCoffeeShopAsync(Guid guid)
        {
            ArgumentNullException.ThrowIfNull(guid, nameof(guid));

            var existingCoffeeShop = await _coffeeShopRepository.GetAllByFilterAsync(c => c.Id == guid, true);

            if (existingCoffeeShop == null)
            {
                throw new Exception($"CoffeeShop not found with this Id: {guid}");
            }

            var coffeeShop =  existingCoffeeShop.FirstOrDefault(x => x.Id == guid);
            coffeeShop.IsActive = false;

            var deletedCoffeeShop = await _coffeeShopRepository.UpdateCoffeeShopAsync(coffeeShop);

            return _mapper.Map<CoffeeShopDTO>(deletedCoffeeShop);
        }

        public async Task<List<CoffeeShopDTO>> GetAllCoffeeShopAsync()
        {
            var resultCoffeeShops = await _coffeeShopRepository.GetAllAsync();
            var coffeeShopDTOs = _mapper.Map<List<CoffeeShopDTO>>(resultCoffeeShops);
            return coffeeShopDTOs;
        }

        public async Task<List<CoffeeShopDTO>> GetAllCoffeeShopByNameAsync(string names)
        {
            ArgumentNullException.ThrowIfNull(names, nameof(names));

            var existingCoffeeShop = await _coffeeShopRepository.GetAllByFilterAsync(c => c.CoffeeShopName == names && c.IsActive, true);

            if (existingCoffeeShop == null)
            {
                throw new Exception($"CoffeeShop not found with the name: {names}");
            }

            return _mapper.Map<List<CoffeeShopDTO>>(existingCoffeeShop);
        }

        public async Task<List<CoffeeShopDTO>> GetAllCoffeeShopByIdAsync(Guid Id)
        {
            ArgumentNullException.ThrowIfNull(Id, nameof(Id));

            var existingCoffeeShop = await _coffeeShopRepository.GetAllByFilterAsync(c => c.Id == Id && c.IsActive, true);

            if (existingCoffeeShop == null)
            {
                throw new Exception($"CoffeeShop not found with the name: {Id}");
            }

            return _mapper.Map<List<CoffeeShopDTO>>(existingCoffeeShop);
        }

        public async Task<List<CoffeeShopDTO>> GetAllOpenedCoffeeShopAsync()
        {
            var openedCoffeeShop = await _coffeeShopRepository.GetAllByFilterAsync(c => c.IsOpen == true && c.IsActive, true);

            if (openedCoffeeShop == null)
            {
                throw new Exception($"CoffeeShop not found with the Open");
            }

            return _mapper.Map<List<CoffeeShopDTO>>(openedCoffeeShop);

        }
    }
}
