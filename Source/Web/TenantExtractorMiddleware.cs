/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityServer4.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Web
{
    /// <summary>
    /// 
    /// </summary>
    public class TenantExtractorMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="next"></param>
        public TenantExtractorMiddleware(
            RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="endpoints"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context, IEnumerable<Endpoint> endpoints)
        {
            var values = context.GetRouteData().Values;
            if (values.ContainsKey("tenant")&&
                values.ContainsKey("pathInfo"))
            {
                var tenant = values["tenant"].ToString();
                var pathInfo = values["pathInfo"];
                MyProfileService.Tenant = Guid.Parse(tenant);
            }

            await _next(context);
        }
    }
}