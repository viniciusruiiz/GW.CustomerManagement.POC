using FluentValidation;
using GW.CustomerManagement.Application.ViewModels;

namespace GW.CustomerManagement.Application.Validators;

public class CreateCustomerViewModelValidator : AbstractValidator<CreateCustomerViewModel>
{
    public CreateCustomerViewModelValidator()
    {
        RuleFor(r => r.FirstName).NotEmpty().MaximumLength(255);
        RuleFor(r => r.LastName).NotEmpty().MaximumLength(255);
        RuleFor(r => r.CPF).NotEmpty().MaximumLength(14);
        RuleFor(r => r.RG).NotEmpty().MaximumLength(12);
        RuleFor(r => r.Address.Street).NotEmpty().MaximumLength(255);
        RuleFor(r => r.Address.City).NotEmpty().MaximumLength(255);
        RuleFor(r => r.Address.State).NotEmpty().MaximumLength(255);
        RuleFor(r => r.Address.Number).NotEmpty().MaximumLength(32);
        RuleFor(r => r.Address.PostalCode).NotEmpty().MaximumLength(9);
    }
}
