using ShopsWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsWebApi.Dependencies.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
