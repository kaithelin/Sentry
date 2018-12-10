/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Concepts;

namespace Concepts.SignedUp
{
    public class Country : ConceptAs<string>
    {
        public static readonly Country NotSet = string.Empty;

        public static implicit operator Country(string country)
        {
            return new Country { Value = country };
        }
    }
}
