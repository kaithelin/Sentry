/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Applications;
using Dolittle.Commands;
using Dolittle.Tenancy;

namespace Domain.Applications.Tenants
{
    public class AssociateTenantWithApplication : ICommand
    {
        public TenantId Tenant { get; set; }
        public Application Application { get; set; }      
    }
}