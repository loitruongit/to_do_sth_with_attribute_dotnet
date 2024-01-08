using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using to_do_sth_with_attribute_dotnet.Extensions;

namespace to_do_sth_with_attribute_dotnet.ActionFilters
{
    public class CheckHeaderForActionFilter : ActionFilterAttribute
    {
        private readonly AppSettings _appSettings;
        private readonly ILogger<CheckHeaderForActionFilter> _logger;

        public CheckHeaderForActionFilter(AppSettings appSettings, ILogger<CheckHeaderForActionFilter> logger)
        {
            _appSettings = appSettings;
            _logger = logger;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            context.HttpContext.Request.Headers.TryGetValue("ApiKey", out StringValues apiKeys);
            context.HttpContext.Request.Headers.TryGetValue("AccessKey", out StringValues accessKeys);

            var secretKeyFromRequest = apiKeys.FirstOrDefault();
            var accessKeyFromRequest = accessKeys.FirstOrDefault();

            var secretKeyFromConfig = _appSettings.SystemInfo.SecretKey;
            var accessKeyFromConfig = _appSettings.SystemInfo.AccessKey;

            var remoteIp = context.HttpContext.GetClientIpAddress();
            _logger.LogWarning("Remote IpAddress: {RemoteIp}", remoteIp);

            if (secretKeyFromRequest != secretKeyFromConfig)
            {
                _logger.LogWarning("Forbidden Request from IP: {RemoteIp} - {ApiKey}", remoteIp, secretKeyFromRequest);
                context.Result = new StatusCodeResult(StatusCodes.Status403Forbidden);
                return;
            }

            if (accessKeyFromRequest != accessKeyFromConfig)
            {
                _logger.LogWarning("Forbidden Request from IP: {RemoteIp} - {AccessKey}", remoteIp, accessKeyFromRequest);
                context.Result = new StatusCodeResult(StatusCodes.Status403Forbidden);
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}
