using AutoMapper;
using CoffeeShopAPI.Models;
using CoffeeShopAPI.Models.DTO;
using CoffeeShopAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CoffeeShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize]
    public class CoffeeShopController : ControllerBase
    {
        private readonly ILogger<CoffeeShopController> _logger;
        private readonly IMapper _mapper;
        private readonly ICoffeeShopService _coffeeShopService;
        private APIResponse _apiResponse;
        public CoffeeShopController(ILogger<CoffeeShopController> logger, IMapper mapper, ICoffeeShopService coffeeShopService)
        {
            _logger = logger;
            _mapper = mapper;
            _coffeeShopService = coffeeShopService;
            _apiResponse = new();
        }

        
        [HttpGet]
        //[HttpGet("All")]
        [Route("All")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public  async Task<ActionResult<APIResponse>> GetAllCoffeeShops()
        {
            try
            {
                var coffeeShops = await _coffeeShopService.GetAllCoffeeShopAsync();
                _apiResponse.Data = coffeeShops;
                _apiResponse.Status = true;
                _apiResponse.StatusCode = HttpStatusCode.OK;
                //OK - 200 - Success
                return Ok(_apiResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError("GetAllCoffeeShops  : "+ ex.Message);
                _apiResponse.Errors.Add(ex.Message);
                _apiResponse.StatusCode = HttpStatusCode.InternalServerError;
                _apiResponse.Status = false;
                return _apiResponse;
            }
            
        }

        [HttpGet]
        //[HttpGet("GetCoffeeShopById/{Id:guid")]
        [Route("{Id:guid}", Name = "GetCoffeeShopById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetCoffeeShop(Guid Id)
        {
            try
            {
                var coffeeShops = await _coffeeShopService.GetAllCoffeeShopByIdAsync(Id);
                _apiResponse.Data = coffeeShops;
                _apiResponse.Status = true;
                _apiResponse.StatusCode = HttpStatusCode.OK;
                //OK - 200 - Success
                return Ok(_apiResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError($"CoffeeShop not found with the name: {Id}", ex.Message);
                _apiResponse.Errors.Add(ex.Message);
                _apiResponse.StatusCode = HttpStatusCode.InternalServerError;
                _apiResponse.Status = false;
                return _apiResponse;
            }


        }

        [HttpGet]
        //[HttpGet("GetOpenedAllCoffeeShop")]
        [Route("GetOpenedAllCoffeeShop")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetCurrentOpenedCoffeeShops()
        {
            try
            {
                var coffeeShops = await _coffeeShopService.GetAllOpenedCoffeeShopAsync();
                _apiResponse.Data = coffeeShops;
                _apiResponse.Status = true;
                _apiResponse.StatusCode = HttpStatusCode.OK;
                //OK - 200 - Success
                return Ok(_apiResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError("CoffeeShop not found with the Open status : "+ ex.Message);
                _apiResponse.Errors.Add(ex.Message);
                _apiResponse.StatusCode = HttpStatusCode.InternalServerError;
                _apiResponse.Status = false;
                return _apiResponse;
            }
        }

        [HttpGet]
        //[HttpGet("GetCoffeeShopByName/shopName")]
        [Route("{shopName}", Name = "GetCoffeeShopByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetCurrentOpenedCoffeeShopByName( string shopName)
        {
            try
            {
                var coffeeShops = await _coffeeShopService.GetAllCoffeeShopByNameAsync(shopName);
                _apiResponse.Data = coffeeShops;
                _apiResponse.Status = true;
                _apiResponse.StatusCode = HttpStatusCode.OK;
                //OK - 200 - Success
                return Ok(_apiResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError($"CoffeeShop not found with the name :  {shopName}", ex.Message);
                _apiResponse.Errors.Add(ex.Message);
                _apiResponse.StatusCode = HttpStatusCode.InternalServerError;
                _apiResponse.Status = false;
                return _apiResponse;
            }
        }

        [HttpPost]
        //[HttpPost("CreateCoffeeShop")]
        [Route("CreateCoffeeShop")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CreateCoffeeShop(CoffeeShopDTO coffeeShop)
        {
            try
            {
                var coffeeShops = await _coffeeShopService.CreateCoffeeShopAsync(coffeeShop);
                _apiResponse.Data = coffeeShops;
                _apiResponse.Status = true;
                _apiResponse.StatusCode = HttpStatusCode.OK;
                //OK - 200 - Success
                return Ok(_apiResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError("Unable to create CoffeeShop "+ex.Message);
                _apiResponse.Errors.Add(ex.Message);
                _apiResponse.StatusCode = HttpStatusCode.InternalServerError;
                _apiResponse.Status = false;
                return _apiResponse;
            }
        }

        [HttpPut]
        [Route("UpdateCoffeeShop")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> UpdateCoffeeShop(CoffeeShopDTO coffeeShop)
        {
            try
            {
                var coffeeShops = await _coffeeShopService.UpdateCoffeeShopAsync(coffeeShop);
                _apiResponse.Data = coffeeShops;
                _apiResponse.Status = true;
                _apiResponse.StatusCode = HttpStatusCode.OK;
                //OK - 200 - Success
                return Ok(_apiResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError("Unable to Update CoffeeShop :"+ ex.Message);
                _apiResponse.Errors.Add(ex.Message);
                _apiResponse.StatusCode = HttpStatusCode.InternalServerError;
                _apiResponse.Status = false;
                return _apiResponse;
            }
        }

    }
}
