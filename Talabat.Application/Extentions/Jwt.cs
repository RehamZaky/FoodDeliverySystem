using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Application.xtentions
{
    public class Jwt
    {
        public string Issuer { get; set; }
        public string SecretKey { get; set; }
        public string Audience { get; set; }
        public int DurationInDays { get; set; }
    }
}
