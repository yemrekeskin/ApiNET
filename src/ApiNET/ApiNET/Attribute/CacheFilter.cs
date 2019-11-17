using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNET.Attribute
{
    /// <summary>
    /// https://www.c-sharpcorner.com/article/implementing-caching-in-web-api/
    /// </summary>
    public class CacheFilter 
        : ActionFilterAttribute
    {
        public int TimeDuration { get; set; }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            context.HttpContext.Response.Headers.Add(HeaderNames.CacheControl, "public,must-revalidate,max-age=100");

            base.OnActionExecuted(context);
        }

        //public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        //{
        //    actionExecutedContext.Response.Headers.CacheControl = new CacheControlHeaderValue
        //    {
        //        MaxAge = TimeSpan.FromSeconds(TimeDuration),
        //        MustRevalidate = true,
        //        Public = true
        //    };
        //}
    }
}
