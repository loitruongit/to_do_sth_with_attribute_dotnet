using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace to_do_sth_with_attribute_dotnet.AuthorizationFilters
{
    public class DenyAllAuthorizationAttribute : TypeFilterAttribute
    {
        public DenyAllAuthorizationAttribute() : base(typeof(DenyAllAuthorizationFilter))
        {
        }

        private class DenyAllAuthorizationFilter : IAuthorizationFilter
        {
            public void OnAuthorization(AuthorizationFilterContext context)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status403Forbidden);
            }
        }
    }
}
