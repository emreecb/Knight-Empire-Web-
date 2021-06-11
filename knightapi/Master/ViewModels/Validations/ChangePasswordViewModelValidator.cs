using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using System.Threading.Tasks;

namespace Master.ViewModels.Validations
{
    public class ChangePasswordViewModelValidator : AbstractValidator<ChangePasswordViewModel>
    {
        public ChangePasswordViewModelValidator()
        {
            RuleFor(vm => vm.UserName).NotEmpty().WithMessage("Kullanıcı Adı boş olamaz");
            RuleFor(vm => vm.newPassword).NotEmpty().WithMessage("Şifre boş olamaz");
            RuleFor(vm => vm.newPassword).Length(6, 12).WithMessage("Şifre 6 ile 12 karakter arasında olmalıdır");
        }
    }
}
