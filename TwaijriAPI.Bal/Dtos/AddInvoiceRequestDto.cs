using FluentValidation;

namespace TwaijriAPI.Bal.Dtos;
public class AddInvoiceRequestDto
{
    public decimal Value { get; set; }
    public string State { get; set; }
    public Guid CustomerId { get; set; }
}

#region Request Validation
public class AddInvoiceRequestDtoAbstractValidator : AbstractValidator<AddInvoiceRequestDto>
{
    public AddInvoiceRequestDtoAbstractValidator()
    {
        RuleFor(p => p.Value).NotEmpty().WithMessage(p => "Required Field");
        RuleFor(p => p.State).NotEmpty().WithMessage(p => "Required Field");
        RuleFor(p => p.CustomerId).NotEmpty().WithMessage(p => "Required Field");
    }
}
#endregion
