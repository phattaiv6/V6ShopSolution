using System;
using System.Collections.Generic;
using System.Text;

namespace V6shopSolution.ViewModel.Common
{
    public class ApiErrorResult<T> : ApiResult<T>
    {
        public string[] ValidationErrors { get; set; }

        public ApiErrorResult()
        {
        }

        public ApiErrorResult(string message) //hiển thị 1 lỗi
        {
            IsSuccessed = false;
            Message = message;
        }

        public ApiErrorResult(string[] validationErrors) //hiển thị nhiều lỗi cùng lúc
        {
            IsSuccessed = false;
            ValidationErrors = validationErrors;
        }
    }
}
