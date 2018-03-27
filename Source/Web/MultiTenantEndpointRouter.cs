/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using IdentityServer4.Configuration;
using IdentityServer4.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Web
{
    /// <summary>
    /// 
    /// </summary>
    public class MultiTenantEndpointRouter : IEndpointRouter
    {
        internal static Type OriginalEndpointRouterType = null;
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceProvider"></param>
        public MultiTenantEndpointRouter(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <inheritdoc/>
        public IEndpointHandler Find(HttpContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            var originalPath = context.Request.Path.ToString();
            var slashIndex = originalPath.Substring(1).IndexOf("/")+1;
            var newPath = originalPath.Substring(slashIndex);
            context.Request.Path = new PathString(newPath);            
            var originalRouter = _serviceProvider.GetService(OriginalEndpointRouterType) as IEndpointRouter;
            return originalRouter.Find(context);
        }
    }
}