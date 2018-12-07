/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Concepts;
using Concepts.SignedUp;
using Dolittle.Commands;

namespace Domain.SignUps
{
    public class SignUpTenant : ICommand
    {
        public SignUpId Id { get; set; }
        public TenantName TenantName { get; set; }
        public HomePage HomePage { get; set; }
        public UserId OwnerUserId { get; set; }
        public Email OwnerEmail { get; set; }
        public CountryId CountryId { get; set; }
        public Country Country { get; set; }
    }
}