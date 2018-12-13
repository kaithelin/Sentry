/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Events;

namespace Events.SignUps
{
    public class AskedToJoinTenant : IEvent
    {
        public Guid Id { get; }
        public Guid UserId { get; }
        public DateTime AskedToJoin { get; }
        public string TenantOwnerEmail { get; }

        public AskedToJoinTenant(Guid id, Guid userId, string tenantOwnerEmail, DateTime askedToJoin)
        {
            Id = id;
            UserId = userId;
            TenantOwnerEmail = tenantOwnerEmail;
            AskedToJoin = askedToJoin;
        }
    }
}