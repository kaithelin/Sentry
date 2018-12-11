/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Concepts;

namespace Concepts.SignedUp
{
    public class HomePage : ConceptAs<string>
    {
        public static readonly HomePage NotSet = string.Empty;

        public static implicit operator HomePage(string homepage)
        {
            return new HomePage { Value = homepage.ToLower().Trim() };
        }
    }
}