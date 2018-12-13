/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/

using System;
using Dolittle.Concepts;
using FluentValidation;

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
    public class SignUpIdInputValidator : AbstractValidator<SignUpId>
    {
        public SignUpIdInputValidator()
        {
            RuleFor(_ => (Guid)_)
                .NotEmpty().WithMessage("SignUpId cannot be blank");
        }
    }

    public static class SignUpIdValidatorExtensions
    {
        public static IRuleBuilderOptions<T, SignUpId> MustBeValidSignUpId<T>(this IRuleBuilder<T, SignUpId> ruleBuilder)
        {
            ruleBuilder.NotNull().WithMessage("SignUpId is required");
            return ruleBuilder.SetValidator(new SignUpIdInputValidator());
        }
    }
}