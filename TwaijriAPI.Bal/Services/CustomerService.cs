using AutoMapper;
using TwaijriAPI.Bal.Dtos;
using TwaijriAPI.Dal;
using TwaijriAPI.Dal.Models;

namespace TwaijriAPI.Bal.Services;

#region Interface
public interface ICustomerService
{
    Task<List<CustomerResponseDto>> GetAllCustomers();
    Task<BaseResponse> AddCustomer(AddCustomerRequestDto req);
}
#endregion

#region Implementation
public class CustomerService : ICustomerService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CustomerService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<CustomerResponseDto>> GetAllCustomers()
    {
        var customers = await _unitOfWork.Customer.GetAllAsync();

        var response = _mapper.Map<List<Customer>, List<CustomerResponseDto>>((List<Customer>)customers);
        return response;
    }

    public async Task<BaseResponse> AddCustomer(AddCustomerRequestDto req)
    {
        try
        {
            var customer = _mapper.Map<AddCustomerRequestDto, Customer>(req);

            await _unitOfWork.Customer.AddAsync(customer);
            await _unitOfWork.Commit();

            return new BaseResponse()
            {
                Status = true,
                Message = "Saved successfully"
            };
        }
        catch (Exception ex)
        {
            return new BaseResponse()
            {
                Status = false,
                Message = "Save failed: " + ex.Message
            };
        }
    }
}
#endregion
