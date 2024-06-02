using System;
using System.Collections.Generic;
using System.Text;

namespace PIS.Common
{
    public class HttpRequestResponse<T>
    {
        public T Result { get; set; }
        public List<ErrorMessage> ErrorMessages { get; set; }

        public HttpRequestResponse() 
        {

            ErrorMessages= new List<ErrorMessage>();
        }
        public HttpRequestResponse(T result) : this()
        {
            Result = result;
        }

        public HttpRequestResponse<T> AddErrorMessage(string message)
        {
            ErrorMessages.Add(new ErrorMessage(message));
            return this;
        }

        public HttpRequestResponse<T> AddErrorMessages(List<ErrorMessage> messages)
        {
            ErrorMessages = messages;
            return this;
        }
    }
}
