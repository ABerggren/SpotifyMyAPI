﻿using System.Runtime.Serialization;
using System;
using SpotifyMyAPI.Web.Http;

namespace SpotifyMyAPI.Web
{
    [Serializable]
    public class APIUnauthorizedException : APIException
    {
        public APIUnauthorizedException(IResponse response) : base(response) { }

        public APIUnauthorizedException() { }

        public APIUnauthorizedException(string message) : base(message) { }

        public APIUnauthorizedException(string message, Exception innerException) : base(message, innerException) { }

        protected APIUnauthorizedException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
