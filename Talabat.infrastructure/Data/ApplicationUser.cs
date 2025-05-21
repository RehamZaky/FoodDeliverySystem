using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Infrastructure.Data
{
    public class ApplicationUser : IdentityUser
    {

        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Gender { get; set; }
        public String? RefreshToken {  get; set; }
        public DateTime? RefreshTokenExpiryTime {  get; set; }
        public DateTime CreateAt {  get; set; } = DateTime.Now;
        public DateTime? UpdateAt {  get; set; }

    }
}
