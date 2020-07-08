using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Ishooper.Infra.Models
{
    public class ApiError
    {
        [JsonProperty("status_code")]
        [DisplayName]
        public string StatusCode { get; private set; }

        [JsonProperty("errors", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public List<string> Errors { get; private set; }
        [JsonProperty("log_id")]
        public string LogId { get; private set; }

        [JsonProperty("error_detail")]
        public object ErrorDetail { get; private set; }

        public ApiError(string statusCode)
        {
            StatusCode = statusCode;
        }

        public ApiError(string statusCode, List<string> errors)
            : this(statusCode)
        {
            Errors = errors;
        }

        public ApiError(string statusCode, string message, string logId, object detail = null)
            : this(statusCode)
        {
            List<string> list = new List<string>
            {
                message
            };
            Errors = list;
            LogId = logId;
            ErrorDetail = detail;
        }

        public ApiError(string statusCode, string message)
            : this(statusCode)
        {
            List<string> list = new List<string>
            {
                message
            };
            Errors = list;
        }
    }

    public class BadRequestError : ApiError
    {
        public BadRequestError()
            : base(HttpStatusCodes.Status400BadRequest.ToString())
        {
        }

        public BadRequestError(List<string> errors)
            : base(HttpStatusCodes.Status400BadRequest.ToString(), errors)
        {
        }

        public BadRequestError(string message)
            : base(HttpStatusCodes.Status400BadRequest.ToString(), message)
        {
        }
    }

    public class NotFoundError : ApiError
    {
        public NotFoundError()
            : base(HttpStatusCodes.Status404NotFound.ToString())
        {
        }

        public NotFoundError(string message, string logId)
            : base(HttpStatusCodes.Status404NotFound.ToString(), message, logId)
        {
        }
    }

    public class UnprocessableEntityError : ApiError
    {
        public UnprocessableEntityError()
            : base(HttpStatusCodes.Status422UnprocessableEntity.ToString())
        {
        }

        public UnprocessableEntityError(string logId)
            : base(HttpStatusCodes.Status422UnprocessableEntity.ToString(), logId)
        {
        }

        public UnprocessableEntityError(string message, string logId)
            : base(HttpStatusCodes.Status422UnprocessableEntity.ToString(), message, logId)
        {
        }
        public UnprocessableEntityError(string message, string logId, object detail)
           : base(HttpStatusCodes.Status422UnprocessableEntity.ToString(), message, logId, detail)
        {
        }
    }


    public class InternalServerError : ApiError
    {
        public InternalServerError()
            : base(HttpStatusCodes.Status500InternalServerError.ToString())
        {
        }

        public InternalServerError(string logId)
            : base(HttpStatusCodes.Status500InternalServerError.ToString(), logId)
        {
        }

        public InternalServerError(string message, string logId)
            : base(HttpStatusCodes.Status500InternalServerError.ToString(), message, logId)
        {
        }
    }
}
