/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace Core
{
    public static class HttpRequestExtensions
    {
        public static StringValues GetEtag(this HttpRequest request)
        {
            StringValues values = "";
            request.Headers.TryGetValue("If-None-Match", out values);

            return values;
        }
    }
}