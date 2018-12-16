/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using Concepts;
using Concepts.SignUps;
using Dolittle.Commands.Validation;

namespace Domain.SignUps
{
    public class SignUpTenantInputValidator : CommandInputValidatorFor<SignUpTenant>
    {
        public SignUpTenantInputValidator()
        {
            RuleFor(_ => _.Id).MustBeValidSignUpId();
            RuleFor(_ => _.TenantName).MustBeValidTenantName();
            RuleFor(_ => _.HomePage).MustBeValidHomePage();
            RuleFor(_ => _.OwnerUserId).MustBeValidUserId();
            RuleFor(_ => _.OwnerEmail).MustBeValidEmail();
            RuleFor(_ => _.CountryId).MustBeValidCountryId();
            RuleFor(_ => _.Country).MustBeValidCountryName();            
        }
    }
}