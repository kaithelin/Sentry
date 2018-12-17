/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Concepts;
using Concepts.SignUps;
using Dolittle.Commands;

namespace Domain.SignUps
{
    public class AskToJoinTenant : ICommand
    {
        public SignUpId Id { get; set; }
        public UserId UserId { get; set; }
        public Email TenantOwnerEmail { get; set; }
    }
}