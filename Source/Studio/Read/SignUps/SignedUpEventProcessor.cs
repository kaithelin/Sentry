﻿/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Dolittle.Events.Processing;
using Dolittle.ReadModels;
using Events.Gateway.SignUps;

namespace Read.SignUps
{
    public class SignedUpEventProcessor : ICanProcessEvents
    {
        private readonly IReadModelRepositoryFor<SignUp> _repository;


        public SignedUpEventProcessor(IReadModelRepositoryFor<SignUp> repository)
        {
            _repository = repository;
        }

        [EventProcessor("69bae5c5-73af-4605-aabf-9a413c7a8241")]
        public void Process(TenantSignedUp @event)
        {
            try
            {
                //var signUp = _repository.GetById(@event.Id);
                //if (signUp != null)

                _repository.Insert(new SignUp { Id = @event.Id, OwnerEmail = @event.OwnerEmail, HomePage = @event.HomePage, SignedUp = @event.SignedUp });

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }

    public class SignUp : IReadModel
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }
        public string OwnerEmail { get; set; }
        public string TenantName { get; set; }
        public string HomePage { get; set; }
        public Guid CountryId { get; set; }
        public string Country { get; set; }
        public DateTime SignedUp { get; set; }

        public SignUp(Guid id, Guid ownerId, string ownerEmail, string tenantName, string homePage, Guid countryId,
            string country, DateTime signedUp)
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

        public SignUp()
        {
        }
    }
}