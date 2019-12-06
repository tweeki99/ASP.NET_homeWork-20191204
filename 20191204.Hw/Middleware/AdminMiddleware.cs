using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _20191204.Hw.Middleware
{
    public class AdminMiddleware
    {
        private readonly RequestDelegate requestDelegate;

        public AdminMiddleware(RequestDelegate requestDelegate)
        {
            this.requestDelegate = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            
            var authToken = context.Request.Path.Value;
            var path = context.Request.Path.ToString();
            string[] words = path.Split('/');

            var adm = context.Session.GetString("AdminIsActive");
            if (!words[1].ToLower().StartsWith("admin"))
            {
                await requestDelegate.Invoke(context);
            }
            else
            {

                if(!context.Session.Keys.Contains("AdminIsActive"))
                {
                    context.Response.Redirect($"/Auth/Index");
                }
                else await requestDelegate.Invoke(context);
            }
        }
    }
}
