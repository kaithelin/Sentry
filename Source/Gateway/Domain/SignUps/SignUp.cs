/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Concepts;
using Concepts.SignUps;
using Dolittle.Domain;
using Dolittle.Runtime.Events;
using Events.SignUps;

namespace Domain.SignUps
{
    public class SignUp : AggregateRoot
    {
        public SignUp(EventSourceId id) : base(id)
        {
            // todo: tenant id is owned by studio
        }
        public void AskedToJoin(SignUpId id, UserId userId, Email userEmail, Email tenantOwnerEmail, DateTime askedToJoin)
        {
            // TODO: rename from AskedToJoinTenant to askToJoinTentant
            Apply(new AskedToJoinTenant( id, userId, userEmail,tenantOwnerEmail, askedToJoin));
        }
        public void SignedUp(SignUpId id, UserId ownerId, Email ownerEmail, TenantName tenantName, HomePage homePage, CountryId countryId, Country country, DateTime signedUp)
        {
            Apply(new TenantSignedUp(id, ownerId, ownerEmail, tenantName, homePage, countryId, country, signedUp));
            // studio Apply(new TenantCreated(id, ownerId, ownerEmail, tenantId, tenantName, homePage, countryId, country, signedUp));
        }
    }
}