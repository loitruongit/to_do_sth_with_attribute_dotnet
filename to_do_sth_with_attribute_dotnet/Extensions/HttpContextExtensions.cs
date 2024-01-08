using Serilog;
using System.Net;

namespace to_do_sth_with_attribute_dotnet.Extensions
{
    public static class HttpContextExtensions
    {
        /// <summary>
        /// Get client ip address
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public static IPAddress? GetClientIpAddress(this HttpContext httpContext)
        {
            try
            {
                if (httpContext.Request.Headers.ContainsKey("X-Forwarded-For"))
                {
                    string xForwardedForHeader = httpContext.Request.Headers["X-Forwarded-For"].ToString().Split(',').Select(s => s.Trim()).First(); //first because <client>, <proxy1>, <proxy2>
                    return IPAddress.Parse(xForwardedForHeader);
                }
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, $"Failed to get client ip address {ex.Message}");
            }

            return httpContext.Connection.RemoteIpAddress;
        }
    }
}
