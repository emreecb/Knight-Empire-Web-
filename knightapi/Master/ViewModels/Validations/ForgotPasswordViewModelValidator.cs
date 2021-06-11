using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Master.ViewModels.Validations
{
    public class ForgotPasswordViewModelValidator : AbstractValidator<ForgotPasswordViewModel>
    {
        public ForgotPasswordViewModelValidator()
        {
            RuleFor(vm => vm.Email).NotEmpty().WithMessage("Email boş olamaz");
        }
    }


}
