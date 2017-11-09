using System;
using System.Net;

namespace VoiceTextWebAPI.Client
{
    public class VoiceTextException : InvalidOperationException
    {
        public HttpStatusCode StatusCode { get; set; }

        public VoiceTextException()
            : base()
        {
        }

        public VoiceTextException(string message, HttpStatusCode statusCode)
            : base(message)
        {
            this.StatusCode = statusCode;
        }
    }
}
