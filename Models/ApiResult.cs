using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiFormApp.Models
{
    //public class ApiResult<T>
    //{
    //    public T Data { get; set; } = default!;
    //    public bool IsSuccess { get; set; }
    //    public string? Error { get; set; }
    //}
    public class ApiResult<T>
    {
        public T Data { get; set; } = default!;
        public bool IsSuccess { get; set; }
    }
}
