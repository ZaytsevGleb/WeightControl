using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;
using WeightControl.Application.Common.Interfaces;

namespace WeightControl.Infrastructure.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor accessor;
        public CurrentUserService(IHttpContextAccessor accessor)
        {
            this.accessor = accessor;
        }

        public int UserId
        {
            get { return Convert.ToInt32(accessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value); }
        }
    }
}
