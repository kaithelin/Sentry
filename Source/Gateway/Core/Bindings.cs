/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System.Security.Claims;
using Dolittle.DependencyInversion;
using Read.Tenants;

namespace Core
{
    /// <summary>
    /// 
    /// </summary>
    public class Bindings : ICanProvideBindings
    {
        /// <inheritdoc/>
        public void Provide(IBindingProviderBuilder builder)
        {
            builder.Bind<ClaimsPrincipal>().To(()=> new ClaimsPrincipal(new ClaimsIdentity()));
            builder.Bind<ITenantConfiguration>().To<TenantTestConfiguration>();
        }
    }
}