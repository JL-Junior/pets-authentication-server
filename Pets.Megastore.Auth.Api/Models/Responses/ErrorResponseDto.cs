using System;
using System.Text.Json.Serialization;

namespace Pets.Megastore.Auth.Api.Models
{
    public class ErrorResponseDto
    {
        public int Status { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Message { get; set; }
    }
}