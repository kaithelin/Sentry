/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;

namespace Read.Management
{
    /// <summary>
    /// Represents the base configuration of an external authority
    /// </summary>
    public class ExternalAuthority
    {
        /// <summary>
        /// Gets or sets a unique identifier for the instance of an <see cref="ExternalAuthority"/>
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the type
        /// </summary>
        public Guid Type { get; set; }

        /// <summary>
        /// Gets or sets the display name of the authority
        /// </summary>
        /// <remarks>
        /// This will be displayed to the user when an application is asking to be logged in
        /// </remarks>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the Url for the logo that will be displayed alongside the authority displayname
        /// </summary>
        /// <remarks>
        /// This will be displayed to the user when an application is asking to be logged in
        /// </remarks>
        public string LogoUrl { get; set; }

        /// <summary>
        /// Gets or sets the secret key used to verify signatures
        /// </summary>
        public string Secret { get; set; }
    }   
}