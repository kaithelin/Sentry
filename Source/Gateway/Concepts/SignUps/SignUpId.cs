/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Concepts;

namespace Concepts.SignUps
{
    public class SignUpId : ConceptAs<Guid>
    {
        public static readonly SignUpId Empty = Guid.Empty;
        public static implicit operator SignUpId(Guid value)
        {
            return new SignUpId { Value = value };
        }

        public static implicit operator SignUpId(string value)
        {
            return new SignUpId { Value = Guid.Parse(value) };
        }
    }
}