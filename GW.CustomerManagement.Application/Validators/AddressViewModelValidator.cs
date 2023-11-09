using FluentValidation;
using GW.CustomerManagement.Application.ViewModels;

namespace GW.CustomerManagement.Application.Validators;

public class AddressViewModelValidator : AbstractValidator<AddressViewModel>
{
    public AddressViewModelValidator()
    {
        RuleFor(r => r.Street).NotEmpty().MaximumLength(255);
        RuleFor(r => r.City).NotEmpty().MaximumLength(255);
        RuleFor(r => r.State).NotEmpty().MaximumLength(255);
        RuleFor(r => r.Number).NotEmpty().MaximumLength(32);
        RuleFor(r => r.PostalCode).NotEmpty().MaximumLength(9);
    }
}
