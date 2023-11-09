using FluentValidation;
using GW.CustomerManagement.Application.ViewModels;

namespace GW.CustomerManagement.Application.Validators;

public class UpdateNameViewModelValidator : AbstractValidator<UpdateNameViewModel>
{
    public UpdateNameViewModelValidator()
    {
        RuleFor(r => r.FirstName).NotEmpty().MaximumLength(255);
        RuleFor(r => r.LastName).NotEmpty().MaximumLength(255);
    }
}
