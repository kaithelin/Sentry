/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Events;

namespace Events.SignUps
{
    public class TenantCreated : IEvent
    {
        public Guid Id { get; }
        public Guid OwnerId { get; }
        public string OwnerEmail { get; }
        public Guid TenantId { get; }
        public string TenantName { get; }
        public string HomePage { get; }
        public Guid CountryId { get; }
        public string Country { get; }
        public DateTime Created { get; }

        public TenantCreated(Guid id, Guid ownerId, string ownerEmail, Guid tenantId, string tenantName,
            string homePage, Guid countryId, string country, DateTime created)
        {
            Id = id;
            OwnerId = ownerId;
            OwnerEmail = ownerEmail;
            TenantId = tenantId;
            TenantName = tenantName;
            HomePage = homePage;
            CountryId = countryId;
            Country = country;
            Created = created;
        }
    }
}
