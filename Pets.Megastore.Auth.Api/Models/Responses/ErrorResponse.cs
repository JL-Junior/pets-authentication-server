using System;

namespace Pets.Megastore.Auth.Api.Models
{
    public class ErrorResponseDto
    {
        public int Status { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Error { get; set; }
        public string Path { get; set; }
        public string[] Messages { get; set; }
    }
}