using System.Collections.Generic;
using System.Linq;

namespace TaskManagement.API.Base
{
    public class BaseResponse<T> where T : new()
    {
        public BaseResponse()
        {
            Errors = new List<ErrorModel>();
            Data = new T();
        }

        public bool IsSuccess => !Errors?.Any() ?? false;

        public T Data { get; set; }

        public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>();

        public BaseResponse<T> SetErrorWithCustomMessage(string message = null, string code = null, string outerMessage = null)
        {
            Errors.Add(new ErrorModel(code, message, outerMessage));
            return this;
        }

        public BaseResponse<T> SetError(IEnumerable<string> errors)
        {
            Errors.AddRange(errors.Select(x => new ErrorModel() {Message = x}));
            return this;
        }

        public BaseResponse<T> SetData(T data)
        {
            this.Data = data;
            return this;
        }
    }
    public class ErrorModel
    {
        public ErrorModel()
        {
        }

        public ErrorModel(string code = null, string message = null, string outerMessage = null)
        {
            Code = code;
            Message = message;
            OuterMessage = outerMessage;
        }

        public string Code { get; set; }
        public string Message { get; set; }
        public string OuterMessage { get; set; }
    }

    public class ErrorModel<T>
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public string OuterMessage { get; set; }
        public T Data { get; set; }
    }
}
