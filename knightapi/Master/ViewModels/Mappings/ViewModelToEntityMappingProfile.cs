using AutoMapper;
using Master.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Master.ViewModels.Mappings
{
    public class ViewModelToEntityMappingProfile : Profile
    {
        public ViewModelToEntityMappingProfile()
        {
            CreateMap<RegistrationViewModel, AppUser>().ForMember(au => au.UserName, map => map.MapFrom(vm => vm.Email));
        }
    }
}
