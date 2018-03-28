/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Autofac;
using Dolittle.Collections;
using Dolittle.DependencyInversion.Autofac;
using Dolittle.Runtime.Events.Coordination;
using IdentityModel.Client;
using IdentityServer4;
using IdentityServer4.Hosting;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;

namespace Web
{
    /// <summary>
    /// 
    /// </summary>
    public class MyProfileService : IProfileService
    {
        internal static Guid Tenant;
        /// <summary>
        /// 
        /// </summary>
        public MyProfileService()
        {
            var i=0;
            i++;

        }

        /// <inheritdoc/>
        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            context.AddRequestedClaims(context.IssuedClaims);
            context.AddRequestedClaims(context.Subject.Claims);
            context.AddRequestedClaims(new [] {  new Claim("nationalsociety", "sweden")});

            return Task.CompletedTask;
        }


        /// <inheritdoc/>
        public Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;
            return Task.CompletedTask;
        }
    }
}