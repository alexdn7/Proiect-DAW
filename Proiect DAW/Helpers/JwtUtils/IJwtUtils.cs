using Proiect_DAW.Models;
using System;

namespace Proiect_DAW.Helpers.JwtUtils
{
    public interface IJwtUtils
    {
        string GenerateJwtToken(User user);

        Guid ValidateJwtToken(string token);

    }
}
