using TwaijriAPI.Dal.Enums;

namespace TwaijriAPI.Bal.Dtos; 
public class InvoiceResponseDto
{
    public Guid CustomerId { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public Guid InvoiceId { get; set; }
    public decimal Value { get; set; }
    public InvoiceState State { get; set; }
}
