using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNET
{
    public class JwtTokenConfiguration
    {
        public string Issuer { get; set; }

        public string Audience { get; set; }

        public SigningCredentials SigningCredentials { get; set; }

        public DateTime? EndDate { get; set; }

        public DateTime? StartDate { get; set; }
    }
}
