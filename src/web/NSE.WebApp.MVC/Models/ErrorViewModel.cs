using System.Collections.Generic;

namespace NSE.WebApp.MVC.Models
{
    public class ErrorViewModel
    {
        public int ErrorCode { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }

    }

    public class ResponseResult
    {
        public string Title { get; set; }
        public int Status { get; set; }
        public ResponseErrorMessage Errors { get; set; }
    }

    public class ResponseErrorMessage
    {
        public List<string> Messages { get; set; }
    }
}
