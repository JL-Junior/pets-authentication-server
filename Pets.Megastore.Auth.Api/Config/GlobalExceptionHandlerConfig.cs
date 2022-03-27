using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Pets.Megastore.Auth.Api.Models;
using Pets.Megastore.Auth.Api.Utils;

namespace Pets.Megastore.Auth.Api
{
    public static class GlobalExceptionHandlerConfig
    {
        private static readonly string CONTENT_TYPE = "application/json";
        public static void UseGlobalExceptionHandlers(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(builder => 
            {
                builder.Run(async context =>
                {
                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if(exceptionFeature == null) return;
                    context.Response.ContentType = CONTENT_TYPE;
                    await handleExceptions(exceptionFeature ,context);                    
                });
            });
        }

        private static async Task handleExceptions(IExceptionHandlerFeature exceptionFeature, HttpContext context)
        {
            var error = exceptionFeature.Error;
            await handleGenericException(context);
        }

        private static async Task handleGenericException(HttpContext context)
        {            
            ErrorResponseDto dto = new ErrorResponseDto{
                Error = MessagesUtils.INTERNAL_SERVER,
                Messages = new List<string>(){MessagesUtils.INTERNAL_SERVER}.ToArray(),
                Path = context.Request.Path,
                Status = ((int)HttpStatusCode.InternalServerError),
                TimeStamp = DateTime.Now
            };
            await context.Response.WriteAsync(await dto.ToJsonAsync());
            context.Response.StatusCode = 500;
        }
    }
}