using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Jwt
{
   public interface IAccessToken
    {
        DateTime Expiration { get; set; }
        string Token { get; set; }
    }
}
