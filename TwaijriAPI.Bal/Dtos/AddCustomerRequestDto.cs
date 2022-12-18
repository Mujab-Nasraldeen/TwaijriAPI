using FluentValidation;

namespace TwaijriAPI.Bal.Dtos;
public class AddCustomerRequestDto
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
}

#region Request Validation
public class AddCustomerRequestDtoValidator : AbstractValidator<AddCustomerRequestDto>
{
    public AddCustomerRequestDtoValidator()
    {
        RuleFor(p => p.Name).NotEmpty().WithMessage(p => "Required Field");
        RuleFor(p => p.PhoneNumber).MaximumLength(15).NotEmpty().WithMessage(p => "Required Field");
    }
}
#endregion
