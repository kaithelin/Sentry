/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Concepts.IdentityResources;
using Dolittle.Commands;

namespace Domain.Management.IdentityResources
{

    /// <summary>
    /// Represents an intent to enable an identity resource
    /// </summary>
    public class EnableIdentityResource : ICommand
    {
        /// <summary>
        /// Gets or sets the name of the identity resource
        /// </summary>
        public Name Name { get; set; }
    }
}