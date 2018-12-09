/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Dolittle.Events;
using Dolittle.Tenancy;

namespace Events.Tenants.Registration
{
    /// <summary>
    /// The event that gets applied when a <see cref="Tenant"/> is created
    /// </summary>
    public class TenantCreated : IEvent
    {
        /// <summary>
        /// Initializes a new instance of <see cref="TenantCreated"/>
        /// </summary>
        /// <param name="tenant">The unique identifier for tenant</param>
        /// <param name="name">Name of the tenant</param>
        public TenantCreated(Guid tenant, string name)
        {
            Tenant = tenant;
            Name = name;
        }

        /// <summary>
        /// Gets the global unique identifier for the tenant
        /// </summary>
        public Guid Tenant { get; }

        /// <summary>
        /// Gets the name of the tenant
        /// </summary>
        public string Name { get; }
    }
}