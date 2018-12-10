/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.Applications.Tenants
{
    public class AssociateTenantWithApplicationBusinessRules : CommandBusinessValidatorFor<AssociateTenantWithApplication>
    {
        public AssociateTenantWithApplicationBusinessRules(BeExistingTenant beExistingTenant, Messages messages)
        {
            RuleFor(_ => _.Tenant).Must(_ => beExistingTenant(_)).WithMessage(messages.TenantDoesNotExist);
        }
    }
}