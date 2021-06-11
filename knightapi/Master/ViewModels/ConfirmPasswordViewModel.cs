using Master.ViewModels.Validations;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Master.ViewModels
{
    [Validator(typeof(ConfirmPasswordViewModelValidator))]
    public class ConfirmPasswordViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }

}
