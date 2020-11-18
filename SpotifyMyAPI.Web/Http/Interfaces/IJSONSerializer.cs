﻿using System.Threading.Tasks;

namespace SpotifyMyAPI.Web.Http
{
    public interface IJSONSerializer
    {
        void SerializeRequest(IRequest request);
        IAPIResponse<T> DeserializeResponse<T>(IResponse response);
    }
}
