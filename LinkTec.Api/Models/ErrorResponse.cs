using System.Collections.Generic;

namespace LinkTec.Api.Models
{
    public class ErrorResponse
    {
        public bool Success { get; set; }

        public List<string> Errors { get; set; }
    }
}
