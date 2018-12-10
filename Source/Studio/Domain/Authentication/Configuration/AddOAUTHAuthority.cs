/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Dolittle.Applications;
using Dolittle.Commands;

namespace Domain.Authentication.Configuration
{
    public class AddOAUTHAuthority : ICommand
    {
        public Application Application { get; set; }

        public Guid Id { get; set; }
        public string ClientId { get; set; }
        public string AuthorityUrl { get; set; }
        public Guid Type { get; set; }
        public string DisplayName { get; set; }        
    }
}