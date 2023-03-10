using CustomerStorage.Services.Services.Interfaces;
using CustomerStorage.ViewModels.CustomerModels;
using Microsoft.AspNetCore.Mvc;

namespace CustomersStorage.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(CustomerCreateModel model)
        {
            if (ModelState.IsValid)
            {
                await _customerService.AddAsync(model);
                return Ok();
            }
            else
            {
                return BadRequest(ModelState.IsValid);
            }
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList()
        {
            var result = await _customerService.GetListAsync();
            return Ok(result);
        }

        [HttpGet("GetById/{customerId}")]
        public async Task<IActionResult> GetById(int customerId)
        {
            var result = await _customerService.ReadByIdAsync(customerId);
            return Ok(result);
        }

        [HttpPost("GetByFilter")]
        public async Task<IActionResult> GetByFilter(CustomersSampleRequestModel model)
        {
            var result = await _customerService.GetByFilter(model);
            return Ok(result);
        }

        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(CustomerUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                await _customerService.UpdateAsync(model);
                return Ok();
            }
            else
            {
                return BadRequest(ModelState.IsValid);
            }
        }

        [HttpGet("Remove/{customerId}")]
        public async Task<IActionResult> Remove(int customerId)
        {
            await _customerService.RemoveAsync(customerId);
            return Ok();
        }

        [HttpGet("GetAllNames")]
        public async Task<IActionResult> GetAllNames()
        {
            var allNames = await _customerService.GetAllCustomersNames();
            return Ok(allNames);
        }
    }
}
