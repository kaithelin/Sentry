/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Web
{
    /// <summary>
    /// Represents a middleware that is aware of tenancy in the URLs coming in
    /// </summary>
    /// <remarks>
    /// IdentityServer is built to represent a single tenant - or rather, it seems to be very
    /// agnostic towards being tenant aware in the sense that we need it to be.
    /// 
    /// Luckily, under the hood in IdentityServer the PathBase of a request is used actively.
    /// For instance when generating the discovery document, it uses PathBase as prefix.
    /// So for the /.well-known/openid-configuration route it exposes, it uses PathBase to prefix.
    /// 
    /// This middleware supports paths that start with a Guid in the Path and then change the request
    /// path to not have the Guid but then moves the Guid into the PathBase. The Guid represents
    /// the unique identifier of the tenant.
    /// 
    /// Tenant in this context is the tenant owning the application / client. 
    /// </remarks>
    public class TenantMiddleware
    {
        readonly Regex _guidRegex = new Regex(@"^(\{{0,1}([0-9a-fA-F]){8}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){12}\}{0,1})$");
        readonly RequestDelegate _next;

        /// <summary>
        /// 
        /// </summary>
        /// /// <param name="_next"></param>
        public TenantMiddleware(RequestDelegate _next)
        {
            this._next = _next;
        }

        /// <summary>
        /// The method that gets invoked by the ASP.NET pipeline
        /// </summary>
        /// <param name="context"><see cref="HttpContext"/> for the request</param>
        public async Task Invoke(HttpContext context)
        {
            var segments = context.Request.Path.Value.Split('/');
            if (segments.Length > 1)
            {
                var tenantSegment = segments[1];
                var isGuid = _guidRegex.IsMatch(tenantSegment);
                if (isGuid)
                {
                    context.Request.PathBase = new PathString($"/{tenantSegment}");
                    var remainingSegments = new List<string>(segments);
                    remainingSegments.RemoveRange(0,2);
                    context.Request.Path = $"/{string.Join('/',remainingSegments)}";
                }
            }
            await _next(context);
        }
    }
}