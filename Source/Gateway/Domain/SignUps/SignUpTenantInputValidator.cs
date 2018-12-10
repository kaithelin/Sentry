/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.SignUps
{
    public class SignUpTenantInputValidator : CommandInputValidatorFor<SignUpTenant>
    {
        public SignUpTenantInputValidator()
        {
            RuleFor(_ => (Guid) _.Id)
                .NotEmpty().WithMessage("A Tenant id is required");

        }
    }
}