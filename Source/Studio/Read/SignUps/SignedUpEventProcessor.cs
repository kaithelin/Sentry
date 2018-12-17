/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Dolittle.Events.Processing;
using Events.Gateway.SignUps;

namespace Read.SignUps
{
    public class SignedUpEventProcessor : ICanProcessEvents
    {
        public SignedUpEventProcessor()
        {
        }

        [EventProcessor("a530802d-7bd1-4f49-954a-591eecc0cd91")]
        public void Process(TenantSignedUp @event)
        {
            // Joho
            Console.WriteLine("Joho");
        }
    }
}