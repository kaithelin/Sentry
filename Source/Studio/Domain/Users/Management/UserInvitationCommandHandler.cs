/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Commands.Handling;
using Dolittle.Domain;

namespace Domain.Users.Management
{
    public class UserInvitationCommandHandler : ICanHandleCommands
    {
        readonly IAggregateRootRepositoryFor<UserInvitation> _aggregateRootRepoForUserInvitation;

        public UserInvitationCommandHandler(
            IAggregateRootRepositoryFor<UserInvitation> aggregateRootRepoForUserInvitation
        )
        {
             _aggregateRootRepoForUserInvitation = aggregateRootRepoForUserInvitation;
        }

        public void Handle(InviteUser cmd)
        {

        }
    }
}
