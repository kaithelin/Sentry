/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Commands.Handling;
using Dolittle.Domain;

namespace Domain.SignUps
{
    public class SignUpCommandHandler : ICanHandleCommands
    {
        readonly IAggregateRootRepositoryFor<SignUp> _repository;

        public SignUpCommandHandler(IAggregateRootRepositoryFor<SignUp> repository)
        {
            _repository = repository;
        }

        public void Handle(AskToJoinTenant cmd)
        {
            var askedToJoin = DateTime.UtcNow;

            var aggregateRoot = _repository.Get(cmd.Id.Value);
            aggregateRoot.AskedToJoin(cmd.Id, cmd.UserId, cmd.TenantOwnerEmail, askedToJoin);
        }

        public void Handle(SignUpTenant cmd)
        {
            var signedUp = DateTime.UtcNow;

            var aggregateRoot = _repository.Get(cmd.Id.Value);
            aggregateRoot.SignedUp(cmd.Id, cmd.OwnerUserId, cmd.OwnerEmail, cmd.TenantName, cmd.HomePage,cmd.CountryId,cmd.Country, signedUp);
        }
    }
}