using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Application.Response
{
    public class ApiResponse<T>
    {
        public bool IsSuccess { get; set; }
        public List<string> Errors { get; set; }
        public string Message { get; set; }
        public string Code { get; set; }
        public T Data { get; set; }

        public ApiResponse(List<string> errors, string message)
        {
            Errors = errors;
            IsSuccess = false;
            Message = message;
        }
        public ApiResponse(T data, string code, string message = null)
        {
            Data = data;
            IsSuccess = true;
            Code = code;
            Message = message;
        }

        public ApiResponse(string message, string code, List<string> errors = null)
        {
            Code = code;
            IsSuccess = false;
            Message = message;
            Errors = errors;
        }
    }
}
