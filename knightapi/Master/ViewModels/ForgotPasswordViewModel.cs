using Master.ViewModels.Validations;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Master.ViewModels
{
    [Validator(typeof(ForgotPasswordViewModelValidator))]
    public class ForgotPasswordViewModel
    {
        public string Email { get; set; }
    }
}
