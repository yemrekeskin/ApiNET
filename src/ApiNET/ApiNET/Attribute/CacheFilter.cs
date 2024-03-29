﻿using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Net.Http.Headers;

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
    }
}