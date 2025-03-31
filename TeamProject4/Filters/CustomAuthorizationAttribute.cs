using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims; // ĐÃ THÊM NAMESPACE
using static Team_Project_4.Models.AuthorizationModel;

namespace Team_Project_4.Filters
{
    public class CustomAuthorizationAttribute : Attribute, IAuthorizationFilter
    {
        private readonly UserRole _requiredRole;

        public CustomAuthorizationAttribute(UserRole requiredRole)
        {
            _requiredRole = requiredRole;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

            if (!user.Identity.IsAuthenticated)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            // LẤY ROLE TỪ CLAIM
            var userRoleClaim = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
            if (userRoleClaim == null)
            {
                context.Result = new ForbidResult();
                return;
            }

            // CHUYỂN ĐỔI ROLE TỪ STRING SANG ENUM
            if (!Enum.TryParse<UserRole>(userRoleClaim.Value, out var userRole))
            {
                context.Result = new ForbidResult();
                return;
            }

            // SO SÁNH ROLE VỚI ROLE YÊU CẦU
            if (userRole != _requiredRole)
            {
                context.Result = new ForbidResult();
                return;
            }
        }
    }
}