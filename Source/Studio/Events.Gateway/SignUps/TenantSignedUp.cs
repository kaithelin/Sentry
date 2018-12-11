/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Events;

namespace Events.Gateway.SignUps
{
    public class TenantSignedUp : IEvent
    {
        public Guid Id { get; }
        public Guid OwnerId { get; }
        public string OwnerEmail { get; }
        public string TenantName { get; }
        public string HomePage { get; }
        public Guid CountryId { get; }
        public string Country { get; }
        public DateTime SignedUp { get; }

        public TenantSignedUp(Guid id, Guid ownerId, string ownerEmail, string tenantName, string homePage, Guid countryId, string country, DateTime signedUp)
        {
            Id = id;
            OwnerId = ownerId;
            OwnerEmail = ownerEmail;
            TenantName = tenantName;
            HomePage = homePage;
            CountryId = countryId;
            Country = country;
            SignedUp = signedUp;
        }
    }
}