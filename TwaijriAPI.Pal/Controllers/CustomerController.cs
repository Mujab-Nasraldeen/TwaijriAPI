using Microsoft.AspNetCore.Mvc;
using TwaijriAPI.Bal.Dtos;
using TwaijriAPI.Bal.Services;
using TwaijriAPI.Pal.Contracts;

namespace TwaijriAPI.Pal.Controllers;
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;

	public CustomerController(ICustomerService customerService)
	{
		_customerService = customerService;
	}

    [HttpGet(ApiRoute.Customer.GetAllCustomers)]
    public async Task<IActionResult> GetAllCustomers()
    {
        try
        {
            var customers = await _customerService.GetAllCustomers();
            return Ok(customers);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost(ApiRoute.Customer.AddCustomer)]
    public async Task<IActionResult> AddCustomer([FromBody] AddCustomerRequestDto req)
    {
        try
        {
            var customer = await _customerService.AddCustomer(req);
            return Ok(customer);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
