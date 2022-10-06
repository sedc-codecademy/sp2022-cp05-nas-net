using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator.InterfaceModels.Models.User
{
    public class AuthenticateUserDto
    {
        public string LoginProvider { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
