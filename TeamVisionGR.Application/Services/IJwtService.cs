using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;

namespace TeamVisionGR.Application.Services
{
    public interface IJwtService
    {
        void AddJwtAuthentication(IServiceCollection services);
    }
}