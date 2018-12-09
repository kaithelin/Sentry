/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Dolittle.Events;
using Dolittle.Runtime.Tenancy;

namespace Events.Tenancy.Registration
{
    /// <summary>
    /// The event that gets applied when a <see cref="Tenant"/> is created
    /// </summary>
    public class TenantCreated : IEvent
    {
        public TenantCreated(Guid tenantId)
        {
            TenantId = tenantId;
        }

        /// <summary>
        /// Gets the global unique identifier for the tenant
        /// </summary>
        public Guid TenantId { get; }       
    }
}