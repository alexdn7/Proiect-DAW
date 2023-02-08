using Microsoft.AspNetCore.Http;
using Proiect_DAW.Helpers.JwtUtils;
using System.Threading.Tasks;
using Proiect_DAW.Services.Users;
using System;
using System.Linq;

namespace Proiect_DAW.Helpers.MiddleWare
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _nextRequestDelegate;

        public JwtMiddleware(RequestDelegate requestDelegate)
        {
            _nextRequestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext httpContext, IUserService usersService, IJwtUtils jwtUtils)
        {
            var token = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split("").Last();
            var userId = jwtUtils.ValidateJwtToken(token);
            if (userId != Guid.Empty)
            {
                httpContext.Items["Editor"] = usersService.GetById(userId);
            }
            await _nextRequestDelegate(httpContext);
        }
    }
}
