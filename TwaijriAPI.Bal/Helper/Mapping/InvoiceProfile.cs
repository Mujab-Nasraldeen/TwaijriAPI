using AutoMapper;
using TwaijriAPI.Bal.Dtos;
using TwaijriAPI.Dal.Models;

namespace TwaijriAPI.Bal.Helper.Mapping;
public class InvoiceProfile : Profile
{
	public InvoiceProfile()
	{
        #region Add Invoice Request
        CreateMap<AddInvoiceRequestDto, Invoice>();
        #endregion

        #region Update Invoice Request
        CreateMap<UpdateInvoiceRequestDto, Invoice>();
        #endregion

        #region Invoice Response
        CreateMap<Invoice, InvoiceResponseDto>()
            .ForMember(p => p.InvoiceId, opt => opt.MapFrom(x => x.Id))
            .ForMember(p => p.Value, opt => opt.MapFrom(x => x.Value))
            .ForMember(p => p.State, opt => opt.MapFrom(x => x.State))
            .ForMember(p => p.CustomerId, opt => opt.MapFrom(x => x.Customer.Id))
            .ForMember(p => p.Name, opt => opt.MapFrom(x => x.Customer.Name))
            .ForMember(p => p.PhoneNumber, opt => opt.MapFrom(x => x.Customer.PhoneNumber));
        #endregion

        #region Add Customer Request
        CreateMap<AddCustomerRequestDto, Customer>();
        #endregion

        #region Customer Response
        CreateMap<Customer, CustomerResponseDto>();
        #endregion
    }
}
