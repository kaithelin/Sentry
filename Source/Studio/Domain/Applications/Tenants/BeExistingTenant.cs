/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Commands.Validation;
using Dolittle.Tenancy;

namespace Domain.Applications.Tenants
{
    public delegate bool BeExistingTenant(TenantId tenant);
}