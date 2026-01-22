using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiFormApp.Models
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
