/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Dolittle.Events.Processing;
using Dolittle.ReadModels;
using Events.Users.Management;

namespace Read.Users.Management
{
    public class UserInvitationEventProcessor : ICanProcessEvents
    {
        private readonly IReadModelRepositoryFor<UserInvitation> _repository;

        public UserInvitationEventProcessor(IReadModelRepositoryFor<UserInvitation> repository)
        {
            _repository = repository;
        }

        [EventProcessor("e85c1fed-a30d-caf5-ec54-eef851e712ac")]
        public void Process(UserInvited @event)
        { 
            
        }

        [EventProcessor("be81f685-47f0-4842-9bfa-27412e46c7c5")]
        public void Process(UserInvitationCancelled @event)
        {
        }
    }
}