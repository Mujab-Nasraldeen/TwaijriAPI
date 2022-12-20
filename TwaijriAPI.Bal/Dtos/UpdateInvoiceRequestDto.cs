using FluentValidation;

namespace TwaijriAPI.Bal.Dtos;
public class UpdateInvoiceRequestDto : AddInvoiceRequestDto
{
    public Guid Id { get; set; }
}

#region Request Validation
public class UpdateInvoiceRequestValidator : AbstractValidator<UpdateInvoiceRequestDto>
{
	public UpdateInvoiceRequestValidator()
	{
        RuleFor(p => p.Id).NotEmpty().WithMessage(p => "Required Field");
        RuleFor(p => p.Value).NotEmpty().WithMessage(p => "Required Field");
        RuleFor(p => p.State).NotEmpty().WithMessage(p => "Required Field");
        RuleFor(p => p.CustomerId).NotEmpty().WithMessage(p => "Required Field");
    }
}
#endregion
