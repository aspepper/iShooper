using System;
using System.Runtime.Serialization;

namespace Ishooper.Infra.CustomExceptions
{

    [Serializable]
    public class UserCustomException : Exception
    {
        public UserCustomException()
        {
        }

        public UserCustomException(string message) : base(message)
        {
        }

        public UserCustomException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UserCustomException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
