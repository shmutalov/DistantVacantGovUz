using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DistantVacantGovUz.Enums;

namespace DistantVacantGovUz.Http
{
    public static class HttpEngineFactory
    {
        public static IHttpEngine GetHttpEngine(HttpRequestsType engineType)
        {
            switch (engineType)
            {
                case HttpRequestsType.Curl:
                    return new CurlHttpEngine();
                case HttpRequestsType.Net:
                    return new NetHttpEngine();
                default:
                    throw new ArgumentOutOfRangeException(nameof(engineType), engineType, null);
            }
        }
    }
}
