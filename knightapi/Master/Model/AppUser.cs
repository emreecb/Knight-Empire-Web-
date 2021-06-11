using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Master.Model
{
    public partial class AppUser : IdentityUser
    {
        // Extended Properties
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public long? FacebookId { get; set; }
        public string PictureUrl { get; set; }
        public string RolesId { get; set; }
        public DateTime DogumTarihi { get; set; }
    }
}
