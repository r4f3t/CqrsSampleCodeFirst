using CqrsSampleFirst.Application;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CqrsSampleFirst.WebApi
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUserId()
        {
            string id;
            try
            {
                id = _httpContextAccessor.HttpContext?.User?.FindFirstValue("Id");
            }
            catch
            {
                id = string.Empty;
            }
            return id;
        }
    }
}
