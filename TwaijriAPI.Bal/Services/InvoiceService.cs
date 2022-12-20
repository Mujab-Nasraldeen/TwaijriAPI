using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TwaijriAPI.Bal.Dtos;
using TwaijriAPI.Dal;
using TwaijriAPI.Dal.Enums;
using TwaijriAPI.Dal.Models;

namespace TwaijriAPI.Bal.Services;

#region interface
public interface IInvoiceService
{
    Task<List<InvoiceResponseDto>> GetAllInvoices();
    List<InvoiceResponseDto> GetPaidInvoices();
    List<InvoiceResponseDto> GetNotPaidInvoices();
    Task<InvoiceResponseDto> GetInvoiceById(Guid id);
    Task<BaseResponse> AddInvoice(AddInvoiceRequestDto req);
    Task<BaseResponse> UpdateInvoice(UpdateInvoiceRequestDto req);
    Task<BaseResponse> DeleteInvoice(Guid id);
}
#endregion

#region Implementation
public class InvoiceService : IInvoiceService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public InvoiceService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<InvoiceResponseDto>> GetAllInvoices()
    {
        var invoices = await _unitOfWork.Invoice.GetAll()
            .Include(p => p.Customer)
            .ToListAsync();

        var response = _mapper.Map<List<InvoiceResponseDto>>(invoices);
        return response;
    }

    public List<InvoiceResponseDto> GetPaidInvoices()
    {
        var invoices = _unitOfWork.Invoice.GetMany(p => p.State == InvoiceState.Paid)
            .Include(p => p.Customer)
            .ToListAsync();


        var response = _mapper.Map<List<InvoiceResponseDto>>(invoices);
        return response;
    }

    public List<InvoiceResponseDto> GetNotPaidInvoices()
    {
        var invoices = _unitOfWork.Invoice.GetMany(p => p.State == InvoiceState.NotPaid)
            .Include(p => p.Customer)
            .ToListAsync();

        var response = _mapper.Map<List<InvoiceResponseDto>>(invoices);
        return response;
    }

    public async Task<InvoiceResponseDto> GetInvoiceById(Guid id)
    {
        var invoice = await _unitOfWork.Invoice.GetByIdAsync(id);

        var response = _mapper.Map<InvoiceResponseDto>(invoice);
        return response;
    }

    public async Task<BaseResponse> AddInvoice(AddInvoiceRequestDto req)
    {
        try
        {
            var invoice = _mapper.Map<AddInvoiceRequestDto, Invoice>(req);

            await _unitOfWork.Invoice.AddAsync(invoice);
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

    public async Task<BaseResponse> UpdateInvoice(UpdateInvoiceRequestDto req)
    {
        try
        {
            var invoice = _mapper.Map<UpdateInvoiceRequestDto, Invoice>(req);

            _unitOfWork.Invoice.UpdateAsync(invoice);
            await _unitOfWork.Commit();

            return new BaseResponse()
            {
                Status = true,
                Message = "Updated successfully"
            };
        }
        catch (Exception ex)
        {
            return new BaseResponse()
            {
                Status = false,
                Message = "Updated failed: " + ex.Message
            };
        }
    }

    public async Task<BaseResponse> DeleteInvoice(Guid id)
    {
        var invoice = await _unitOfWork.Invoice.GetByIdAsync(id);

        if(invoice is not null) 
        {
            _unitOfWork.Invoice.DeleteAsync(invoice);
            await _unitOfWork.Commit();

            return new BaseResponse()
            {
                Status = true,
                Message = "Deleted successfully"
            };
        }
        else
        {
            return new BaseResponse()
            {
                Status = false,
                Message = "Delete failed"
            };
        }
    }
}
#endregion
