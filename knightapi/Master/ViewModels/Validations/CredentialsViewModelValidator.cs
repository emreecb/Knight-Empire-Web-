using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Master.ViewModels.Validations
{
    public class CredentialsViewModelValidator : AbstractValidator<CredentialsViewModel>
    {
        public CredentialsViewModelValidator()
        {
            RuleFor(vm => vm.UserName).NotEmpty().WithMessage("Kullanıcı Adı boş olamaz");
            RuleFor(vm => vm.Password).NotEmpty().WithMessage("Şifre boş olamaz");
            RuleFor(vm => vm.Password).Length(6, 12).WithMessage("Şifre 6 ile 12 karakter arasında olmalıdır");
        }
    }
}
