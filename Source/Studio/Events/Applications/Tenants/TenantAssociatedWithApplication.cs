/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Dolittle.Applications;
using Dolittle.Events;
using Dolittle.Tenancy;

namespace Events.Applications.Tenants
{
    /// <summary>
    /// The event that gets applied when a <see cref="TenantId"/> is associated with an <see cref="Application"/>
    /// </summary>
    public class TenantAssociatedWithApplication : IEvent
    {
        /// <summary>
        /// Initializes a new instance of <see cref="TenantAssociatedWithApplication"/>
        /// </summary>
        /// <param name="tenant">Tenant to associate</param>
        /// <param name="application">Application to associate with</param>
        public TenantAssociatedWithApplication(Guid tenant, Guid application)
        {
            Tenant = tenant;
            Application = application;
        }

        /// <summary>
        /// Gets the unique identifier for the tenant
        /// </summary>
        public Guid Tenant { get; }

        /// <summary>
        /// Gets the unique identifier for the application
        /// </summary>
        public Guid Application { get; }       
    }
}