using Master.ViewModels.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Attributes;

namespace Master.ViewModels
{
    [Validator(typeof(ChangePasswordViewModelValidator))]
    public class ChangePasswordViewModel
    {
        public string UserName { get; set; }
        public string oldPassword { get; set; }
        public string newPassword { get; set; }
    }
}
