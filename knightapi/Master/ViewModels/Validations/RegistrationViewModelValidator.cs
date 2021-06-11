using FluentValidation;

namespace Master.ViewModels.Validations
{
    public class RegistrationViewModelValidator : AbstractValidator<RegistrationViewModel>
    {
        public RegistrationViewModelValidator()
        {
            RuleFor(vm => vm.Email).NotEmpty().WithMessage("Email boş olamaz");
            RuleFor(vm => vm.Password).NotEmpty().WithMessage("Şifre boş olamaz");
            RuleFor(vm => vm.FirstName).NotEmpty().WithMessage("Ad boş olamaz");
            RuleFor(vm => vm.LastName).NotEmpty().WithMessage("Soyad boş olamaz");
        }
    }
}
