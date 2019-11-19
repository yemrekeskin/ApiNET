using Microsoft.AspNetCore.Mvc.Filters;

namespace ApiNET.Attribute
{
    /// <summary>
    /// https://www.radenkozec.com/asp-net-web-api-gzip-compression-actionfilter/
    /// </summary>
    public class DeflateCompression
        : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            //var content = context.HttpContext.Response.Body;
            //var bytes = content?.ReadByte();
            //var zlibbedContent = bytes == null ? new byte[0] : CompressionHelper.DeflateByte(bytes);

            //context.HttpContext.Response.Body = new ByteArrayContent(zlibbedContent);
            //context.HttpContext.Response.Headers.Remove("Content-Type");
            //context.HttpContext.Response.Headers.Add("Content-encoding", "deflate");
            //context.HttpContext.Response.Headers.Add("Content-Type", "application/json");

            base.OnActionExecuted(context);
        }
    }
}