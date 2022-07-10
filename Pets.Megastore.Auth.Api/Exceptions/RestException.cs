using System;
using Pets.Megastore.Auth.Api.Models;

namespace Pets.Megastore.Auth.Api.Exceptions
{
    public class RestException : Exception
    {
        public int Status { get; set; }
        public ErrorResponseDto Response {get;set;}
        public RestException(String message): base(message){
        }

        public RestException(String message, int status, ErrorResponseDto response): base(message){
            this.Status = status;
            Response = response;
        }

        public static RestException Unauthorized(String message){
            return generateRestException(401, message);
        }

        public static RestException BadRequest(String message){
            return generateRestException(400, message);
        }

        private static RestException generateRestException(int status, String message){
                return new RestException(
                message, 
                status,
                new ErrorResponseDto(){
                    Message = message,
                    Status = status,
                    TimeStamp = DateTime.Now
                });
        }

    }
}