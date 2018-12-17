/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using System.Linq;
using Concepts.Users.Management;
using Dolittle.Applications;
using Dolittle.Queries;
using Dolittle.ReadModels;
using Dolittle.Tenancy;

namespace Read.Users.Management
{

    public class AllUserInvitations : IQueryFor<UserInvitation>
    {
        private readonly IReadModelRepositoryFor<UserInvitation> _userInvitations;
        public TenantId TenantId { set; private get; }
        public Application ApplicationId { get; set; }

        public AllUserInvitations(IReadModelRepositoryFor<UserInvitation> userInvitations)
        {
            _userInvitations = userInvitations;
        }

        public IQueryable<UserInvitation> Query => _userInvitations.Query.Where(w=>w.TenantId == TenantId && w.ApplicationId == ApplicationId);
    }

    public class UserInvitation : IReadModel
    {
        public UserInvitationId Id { get; set; }
        public TenantId TenantId { get; set; }        
        public Application ApplicationId { get; set; }
        public Email Email{ get; set; }
        public DateTime Invited { get; set; }
        public DateTime ValidTo { get; set; }
        public UserInvitationStatus Status { get; set; }
    }

    public enum UserInvitationStatus
    {
        UserInvitaitionReceived = 0,
        UserInvitationIsNotValid = 1,
        UserDeniedInvitaition = 2,
        UserAcceptedInvitation = 3,
        UserInvitationManuallyCanceled
    }
}