using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRestfulSwaggerService.Services
{
    public class SecurityService
    {

        public bool IsAuthValidated(string username, string password)
        {
            var res = username == "Johan" && password == "Perez";
            return res;
        }
    }
}
