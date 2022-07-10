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
using Pets.Megastore.Auth.Api.Exceptions;
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
            Exception error = exceptionFeature.Error;
            switch (error){
                case RestException:
                    await handleRestException(context, (RestException) error);
                    break;
                default:
                    await handleGenericException(context);
                    break;
            }
        }

        private static async Task handleRestException(HttpContext context, RestException error)
        {
            context.Response.StatusCode = error.Status;
            await context.Response.WriteAsync(error.Response.ToJson());
        }

        private static async Task handleGenericException(HttpContext context)
        {            
            ErrorResponseDto dto = new ErrorResponseDto{
                Message = MessagesUtils.INTERNAL_SERVER,
                Status = ((int)HttpStatusCode.InternalServerError),
                TimeStamp = DateTime.Now
            };
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync(dto.ToJson());
        }
    }
}